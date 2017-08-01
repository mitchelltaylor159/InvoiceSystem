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
        public MainWindow(AppController controller)
        {
            InitializeComponent();
            this.Controller = controller;
            
        }
        public void LoadActiveInvoice()
        {
            InvoiceNumTextBox.Text = Controller.Invoices.ActiveInvoice.InvoiceNumber;
            CurrentDate.SelectedDate = Controller.Invoices.ActiveInvoice.InvoiceDate;
            SelectedItemCombo.ItemsSource = Controller.Items.Items;
            DataGridList.ItemsSource = Controller.Invoices.ActiveInvoice.ListItems;

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.Edit();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.Search();
            }
            catch (Exception ex)
            {
                //Controller.Handler
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void DataGridList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // try
           // {
                //Update the active item in controller
                Controller.InvoiceItems.ActiveInvoiceItem = (InvoiceItem)DataGridList.SelectedItem;
            InvoiceNumTextBox.Text = Controller.Invoices.ActiveInvoice.InvoiceNumber;


            QuantityBox.Text = Controller.InvoiceItems.ActiveInvoiceItem.Quantity.ToString();
            
            SelectedItemCombo.SelectedItem  = Controller.Items.Items.Where(m => m.ItemID == Controller.InvoiceItems.ActiveInvoiceItem.ItemID).Single(); ;

            //  }
            /*catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }*/
        }

        /*public void updateInvoiceItemFields()
        {
            try
            {
                InvoiceNumTextBox.Text = Controller.Invoices.ActiveInvoice.InvoiceNumber;

                
                QuantityBox.Text = Controller.InvoiceItems.ActiveInvoiceItem.Quantity.ToString();
                var items = Controller.Items.Items.Where(m => m.ItemID > Controller.InvoiceItems.ActiveInvoiceItem.ItemID);
                SelectedItemCombo.SelectedItem = items.FirstOrDefault();
               // DataGridList.ItemsSource = Controller.Invoices.ActiveInvoice.ListItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }*/



    }
}
