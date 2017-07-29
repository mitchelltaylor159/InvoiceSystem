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
            InitializeComponent();
            this.Controller = controller;
        }

        private void btnSaveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate
                // Get the item
                // Update the item
                // Refresh the DataGrid
            }
            catch (Exception ex)
            {
                Controller.HandleError(new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message));
            }
        }

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
    }
}