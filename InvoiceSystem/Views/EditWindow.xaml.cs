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
        public AppController Controller { get; set; }
        public EditWindow(AppController controller)
        {
            try
            {
                InitializeComponent();
                this.Controller = controller;
                dgItem.ItemsSource = Controller.Items.Items;
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
        private void UpdateInvoiceList()
        {
            dgItem.ItemsSource = Controller.Items.Items;
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
            Controller.Items.CreateItem(Controller.Items.ActiveItem.ItemID, itemCode, itemDescription, itemPrice);
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
                SaveItemChanges();
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
                Controller.Items.ActiveItem = (Models.Item)dgItem.SelectedItem;
                SetActiveItem();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
    }
}