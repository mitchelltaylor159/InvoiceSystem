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
        public AppController Controller { get; set; }
        public SearchWindow(AppController controller)
        {
            InitializeComponent();
            this.Controller = controller;
        }

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

        private void LoadInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate
                // Set the ActiveInvoice
                this.Close();
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {

            try
            {
                // Validate
                // Get the filters
                // Instantiate list as a sub-list of the controller's list using LINQ
                // Refresh the ListBox
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }
    }
}
