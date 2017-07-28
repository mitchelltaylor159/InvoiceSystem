using InvoiceSystem.Controllers;
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
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        /// <summary>
        /// Access to the shared resources.
        /// </summary>
        public AppController Controller { get; set; }

        /// <summary>
        /// A list of strings to represent greater, less, equal
        /// </summary>
        public IEnumerable<string> GLEList { get; set; }

        /// <summary>
        /// Default Constructor.  Instantiates access to the shared resources (controllers).
        /// </summary>
        /// <param name="controller">The main app controller.</param>
        public SearchWindow(AppController controller)
        {
            try
            {
                InitializeComponent();
                this.Controller = controller;
                string[] GLE = new string[5] { ">", ">=", "=", "<=", "<" };
                this.GLEList = new List<string>(GLE);

                // Initialize UI component values
                cbInvoiceNumber.ItemsSource = Controller.Invoices.Invoices;
                cbInvoiceNumber.DisplayMemberPath = "InvoiceNumber";
                cbInvoiceNumber.SelectedValuePath = "InvoiceNumber";
                lbxInvoiceList.ItemsSource = Controller.Invoices.SearchedInvoices;
                cbInvoiceDateGLE.ItemsSource = this.GLEList;
                cbInvoiceDateGLE.SelectedItem = this.GLEList.ElementAt(2);
                cbTotalPriceGLE.ItemsSource = this.GLEList;
                cbTotalPriceGLE.SelectedItem = this.GLEList.ElementAt(2);

            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }


        /// <summary>
        /// Clears and re-sets the invoice ListBox
        /// </summary>
        private void UpdateInvoiceList()
        {
            // lbxInvoiceList.Items.Clear();
            lbxInvoiceList.ItemsSource = Controller.Invoices.SearchedInvoices;
        }

        #region Event Handlers;

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="sender">The cancel button.</param>
        /// <param name="e">Event args.</param>
        private void Cancel(object sender, RoutedEventArgs e)
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
        /// Loads the selected invoice into the shared resource. Closes the window.
        /// </summary>
        /// <param name="sender">The load button or a double-clicked ListBoxItem.</param>
        /// <param name="e">Event args.</param>
        private void LoadInvoice(object sender, EventArgs e)
        {
            try
            {
                // Validate

                // Set the ActiveInvoice
                Controller.Invoices.SetActiveInvoice(lbxInvoiceList.SelectedItem);
                this.Close();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        /// <summary>
        /// Filters the list of Invoices based on provided filters from the UI.
        /// </summary>
        /// <param name="sender">The search button.</param>
        /// <param name="e">Event args.</param>
        private void Search(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate
                string invoiceNumber;
                string totalPriceGLE; // (Greater than/Less than/Equal to)
                decimal totalPrice;
                string invoiceDateGLE; // (Greater than / Less than / Equal to) 
                DateTime invoiceDate;

                Controller.Invoices.ClearSearch();

                // Apply InvoiceNumber Filter
                if (cbInvoiceNumber.SelectedValue != null)
                {
                    invoiceNumber = (string)(cbInvoiceNumber.SelectedValue);
                    Controller.Invoices.SearchInvoices(invoiceNumber);
                }

                // Apply TotalPrice Filter
                if (!txtTotalPrice.Text.Equals(""))
                {
                    try
                    {
                        totalPrice = Convert.ToDecimal(txtTotalPrice.Text);
                        totalPriceGLE = cbTotalPriceGLE.SelectedValue.ToString();
                        Controller.Invoices.SearchInvoices(totalPrice, totalPriceGLE);
                    }
                    catch (Exception ex) { }
                }

                // Apply InvoiceDate Filter
                if (dpInvoiceDate.SelectedDate != null)
                {
                    try
                    {
                        invoiceDate = (DateTime)dpInvoiceDate.SelectedDate;
                        invoiceDateGLE = cbInvoiceDateGLE.SelectedValue.ToString();
                        Controller.Invoices.SearchInvoices(invoiceDate, invoiceDateGLE);
                    }
                    catch (Exception ex) { }
                }

                UpdateInvoiceList();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        /// <summary>
        /// ListBoxItem Left Click: Enables the "Load Invoice" button".
        /// </summary>
        /// <param name="sender">ListBoxItem.</param>
        /// <param name="e">Event args.</param>
        private void ChooseInvoice(object sender, MouseButtonEventArgs e)
        {
            btnLoad.IsEnabled = true;
        }

        /// <summary>
        /// Resets the search form and reloads the List.
        /// </summary>
        /// <param name="sender">The "Reset" button.</param>
        /// <param name="e">Event Args.</param>
        private void Reset(object sender, RoutedEventArgs e)
        {
            cbInvoiceNumber.SelectedIndex = -1;
            cbInvoiceDateGLE.SelectedItem = this.GLEList.ElementAt(2);
            cbTotalPriceGLE.SelectedItem = this.GLEList.ElementAt(2);
            txtTotalPrice.Text = "";
            dpInvoiceDate.SelectedDate = null;
            dpInvoiceDate.DisplayDate = DateTime.Now;
            Controller.Invoices.ClearSearch();
            UpdateInvoiceList();

            Search(sender, e);
        }

        #endregion;
    }
}
