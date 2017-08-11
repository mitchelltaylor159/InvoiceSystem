using InvoiceSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InvoiceSystem.Views
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {

        /// <summary>
        /// Main controller get and set to allow use of other controllers and models
        /// </summary>
        public AppController Controller { get; set; }

        /// <summary>
        /// A flag whether to edit/save changes or to add a new item.
        /// </summary>
        public bool Edit { get; set; }

        /// <summary>
        /// Edit Window initialization
        /// </summary>
        /// <param name="controller"></param>
        public EditWindow(AppController controller)
        {
            try
            {
                InitializeComponent(); //Initialize the window
                this.Controller = controller; //Set app controller to this window's controller
                UpdateItemList(); //Update the data
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        /// <summary>
        /// Clears and re-sets the item databox
        /// </summary>
        private void UpdateItemList()
        {
            dgItem.SelectedIndex = -1; //Unselects DataGrid
            dgItem.ItemsSource = Controller.Items.Items; //Update the DataGrid
            
            // Update the ComboBox on the Main page
            Controller.MainView.SelectedItemCombo.ItemsSource = Controller.Items.Items;
            Controller.MainView.SelectedItemCombo.Items.Refresh();

            this.Edit = false;
        }

        /// <summary>
        /// Set Active item
        /// </summary>
        private void SetActiveItem()
        {
            txtItemCode.Text = Controller.Items.ActiveItem.ItemCode;
            txtItemDescription.Text = Controller.Items.ActiveItem.ItemDescription;
            txtItemPrice.Text = Controller.Items.ActiveItem.ItemPrice.ToString();
        }

        /// <summary>
        /// Try exception handling of item changes and then save them
        /// </summary>
        private void SaveItemChanges()
        {
            string itemCode = txtItemCode.Text;
            string itemDescription = txtItemDescription.Text;
            decimal.TryParse(txtItemPrice.Text, out decimal itemPrice);
            int? id = null;
            if (this.Edit)
            {
                id = Controller.Items.ActiveItem.ItemID;
            }
            Controller.Items.CreateItem(id, itemCode, itemDescription, itemPrice);
        }

        /// <summary>
        /// Clears the text boxes
        /// </summary>
        private void ClearTextBoxes()
        {
            txtItemCode.Text = ""; //Clear text box
            txtItemDescription.Text = ""; //Clear text box
            txtItemPrice.Text = ""; //Clear text box
        }

        /// <summary>
        /// Clicking Save will save the text box changes to the active item which will then reflect in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveItemChanges(); //Save the item
                Controller.Items.LoadItems(); //Load the items again with the changes in the database
                UpdateItemList(); //Updates datagrid
                ClearTextBoxes(); //Clear text boxes
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        /// <summary>
        /// Close cancels all and closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Close the window
                this.Close();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        /// <summary>
        /// When a user chooses a selection item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //If the selected index goes back to unselected, don't update the active item
                if (dgItem.SelectedIndex != -1)
                {
                    Controller.Items.ActiveItem = (Models.Item)dgItem.SelectedItem;
                    SetActiveItem();
                }
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        /// <summary>
        /// Only allows numbers and decimal to be input
        /// </summary>
        /// <param name="sender">sent object</param>
        /// <param name="e">key argument</param>
        private void txtItemPriceInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //If key is Alpha then don't let it be entered
                if (e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.OemComma)
                {
                    //If key is not a period, delete, or back key then don't input
                    if (e.Key != Key.OemPeriod || e.Key != Key.Delete || e.Key != Key.Back)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        private void btnNewItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgItem.SelectedIndex = -1;
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
    }
}