﻿using InvoiceSystem.Controllers;
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
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

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
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



    }
}
