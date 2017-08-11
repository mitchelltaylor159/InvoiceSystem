using InvoiceSystem.Controllers;
using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AppController Controller { get; set; }
        /// <summary>
        /// Sets initial conditions for the main window
        /// </summary>
        /// <param name="controller"></param>
        public MainWindow(AppController controller)
        {
            InitializeComponent();
            this.Controller = controller;
            WarnLabel.Visibility = Visibility.Hidden;
            WarnDeleteLabel.Visibility = Visibility.Hidden;
            DateWarningLabel.Visibility = Visibility.Hidden;

        }
        /// <summary>
        /// Loads the Invoice Selected into the MainWindow and populates the datagrid, combobox, date, Invoice number
        /// </summary>
        public void LoadActiveInvoice()
        {

            try
            {
                if (Controller.Invoices.ActiveInvoice.InvoiceNumber != null)
                {
                    InvoiceNumTextBox.Text = Controller.Invoices.ActiveInvoice.InvoiceNumber;
                }
                else
                {
                    InvoiceNumTextBox.Text = "TBD";
                }
                if (Controller.Invoices.ActiveInvoice.InvoiceDate != null && Controller.Invoices.ActiveInvoice.InvoiceDate > new DateTime(0))
                {
                    CurrentDate.SelectedDate = Controller.Invoices.ActiveInvoice.InvoiceDate;
                }
                SelectedItemCombo.ItemsSource = Controller.Items.Items;

                for (int i = 0; i < Controller.InvoiceItems.InvoiceItems.Count(); i++ )
                {
                    Controller.InvoiceItems.InvoiceItems.ElementAt(i).LineItem = Controller.Items.SearchSingle(Controller.InvoiceItems.InvoiceItems.ElementAt(i).ItemID);
                }
                DataGridList.ItemsSource = Controller.InvoiceItems.InvoiceItems;
                ToggleInvoiceItemOptions(false);
                ToggleInvoiceOptions(false);
                EditInvoiceButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Enables all the buttons on the mainwindow
        /// </summary>
        /// <param name="enable"></param>
        public void ToggleInvoiceOptions(bool enable = true)
        {
            try
            {
                CurrentDate.IsEnabled = enable;
                AddLineButton.IsEnabled = enable;
                EditInvoiceButton.IsEnabled = enable;
                SaveInvoiceButton.IsEnabled = enable;
                DeleteInvoiceButton.IsEnabled = enable;
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Enables or dissables buttons so that they cannot be pressed
        /// </summary>
        /// <param name="enable"></param>
        public void ToggleInvoiceItemOptions(bool enable = true)
        {
            try
            {
                SelectedItemCombo.IsEnabled = enable;
                QuantityBox.IsEnabled = enable;
                DeleteLineButton.IsEnabled = enable;
                UpdateLineButton.IsEnabled = enable;
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        /// <summary>
        /// Updates the Quantity Textbox  and ComboBox 
        /// </summary>
        public void updateInvoiceItemFields()
        {
            try
            {

                if (Controller.InvoiceItems.ActiveInvoiceItem != null)
                {
                    QuantityBox.Text = Controller.InvoiceItems.ActiveInvoiceItem.Quantity.ToString();
                    SelectedItemCombo.SelectedItem = Controller.Items.Items.Where(m => m.ItemID == Controller.InvoiceItems.ActiveInvoiceItem.ItemID).Single();
                }
                else
                {
                    QuantityBox.Text = "";
                    SelectedItemCombo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Opens the edit items page for adding items or deleting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.Edit();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Opens the search page for finding invoices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.Search();
            }
            catch (Exception ex)
            {
                //Controller.Handler
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Creates a new Invoice if there is not one loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.Invoices.ActiveInvoice = new Invoice();
                Controller.InvoiceItems.LoadInvoiceItems(Controller.Invoices.ActiveInvoice);
                LoadActiveInvoice();
                ToggleInvoiceOptions();
                ToggleInvoiceItemOptions();
                //need to figure out how to add new item to current invoice 
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        private void EditInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToggleInvoiceOptions();
                ToggleInvoiceItemOptions();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Saved the current invoice with everything currently in the DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentDate.SelectedDate == null)
                {
                    DateWarningLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    DateWarningLabel.Visibility = Visibility.Hidden;
                    Controller.Invoices.ActiveInvoice.InvoiceDate = (DateTime)CurrentDate.SelectedDate;
                    Controller.Invoices.ActiveInvoice.ListItems = Controller.InvoiceItems.InvoiceItems;
                    Controller.Invoices.ActiveInvoice.Save();
                    Controller.InvoiceItems.SaveInvoiceItems(Controller.Invoices.ActiveInvoice);
                    Controller.Invoices.LoadInvoices();
                    Controller.Invoices.SetActiveInvoice(Controller.Invoices.ActiveInvoice.InvoiceID);
                    LoadActiveInvoice();
                }
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Deletes the current invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.Invoices.ActiveInvoice.Delete();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        /// <summary>
        /// Changing selected item in combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Update the active item in controller
                try
                {
                    Controller.InvoiceItems.ActiveInvoiceItem = (InvoiceItem)DataGridList.SelectedItem;
                }
                catch
                {
                    Controller.InvoiceItems.ActiveInvoiceItem = null;
                }
                updateInvoiceItemFields();

            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        private void SelectedItemCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Controller.Items.ActiveItem = (Item)((ComboBox)sender).SelectedItem;
        }
        /// <summary>
        /// Adds a new item to the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLineButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedItemCombo.SelectedItem != null && QuantityBox.Text != "")
                {
                    WarnLabel.Visibility = Visibility.Hidden;
                    WarnDeleteLabel.Visibility = Visibility.Hidden;
                    int quantity = Convert.ToInt32(QuantityBox.Text);
                    bool exists = false;
                    for (int i = 0; i < Controller.InvoiceItems.InvoiceItems.Count(); i++)
                    {
                        if (Controller.InvoiceItems.InvoiceItems.ElementAt(i).ItemID == Controller.Items.ActiveItem.ItemID)
                        {
                            Controller.InvoiceItems.InvoiceItems.ElementAt(i).Quantity = quantity;
                            DataGridList.Items.Refresh();
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        Controller.InvoiceItems.AddInvoiceItem(Controller.Invoices.ActiveInvoice, Controller.Items.ActiveItem, quantity);
                        Controller.InvoiceItems.ActiveInvoiceItem.LineItem = Controller.Items.SearchSingle(Controller.Items.ActiveItem.ItemID);
                        DataGridList.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Updates the quantity of a particular item if it already exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateLineButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGridList.Items.Count == 0)
                {

                }
                else
                {
                    if (SelectedItemCombo.SelectedItem == null || QuantityBox.Text == "")
                    {
                        WarnLabel.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        WarnLabel.Visibility = Visibility.Hidden;
                        WarnDeleteLabel.Visibility = Visibility.Hidden;
                        int quantity = Convert.ToInt32(QuantityBox.Text);
                        Controller.InvoiceItems.ActiveInvoiceItem.Quantity = quantity;
                        Controller.InvoiceItems.ActiveInvoiceItem.ItemID = Controller.Items.ActiveItem.ItemID;
                        Controller.InvoiceItems.ActiveInvoiceItem.LineItem = Controller.Items.SearchSingle(Controller.Items.ActiveItem.ItemID);
                        DataGridList.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
        /// <summary>
        /// Deletes the line currently selected in the DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteLineButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(DataGridList.SelectedIndex != -1)
                {
                    WarnDeleteLabel.Visibility = Visibility.Hidden;
                    Controller.InvoiceItems.InvoiceItems.Remove(Controller.InvoiceItems.ActiveInvoiceItem);
                    Controller.InvoiceItems.ActiveInvoiceItem = null;
                    DataGridList.Items.Refresh();

                }
                else
                {
                    WarnDeleteLabel.Visibility = Visibility.Visible;
                }

            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
    }
}
