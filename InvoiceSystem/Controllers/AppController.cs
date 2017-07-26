using InvoiceSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Controllers
{
    /// <summary>
    /// AppController is the main background class that will
    /// contain the entire application.
    /// </summary>
    public class AppController
    {
        /// <summary>
        /// The Main Window
        /// </summary>
        public MainWindow MainView { get; set; }

        /// <summary>
        /// The Search Window
        /// </summary>
        public SearchWindow SearchView { get; set; }

        /// <summary>
        /// The Edit Window
        /// </summary>
        public EditWindow EditView { get; set; }

        /// <summary>
        /// Access to the Invoices Controller
        /// </summary>
        public InvoicesController Invoices { get; set; }

        /// <summary>
        /// Access to the Invoice Items Controller
        /// </summary>
        public InvoiceItemsController InvoiceItems { get; set; }

        /// <summary>
        /// Access to the Items Controller
        /// </summary>
        public ItemsController Items { get; set; }

        /// <summary>
        /// The default constructor
        /// </summary>
        public AppController()
        {
            // Initialize controllers
            this.Invoices = new InvoicesController();
            this.InvoiceItems = new InvoiceItemsController();
            this.Items = new ItemsController();
            
            // Initialize view
            this.MainView = new MainWindow(this);
            App.Current.MainWindow = this.MainView;
            MainView.Show();
        }

        /// <summary>
        /// Opens the Search Window
        /// </summary>
        public void Search()
        {
            this.SearchView = new SearchWindow(this);
            this.SearchView.Show();
        }

        /// <summary>
        /// Opens the Edit Window
        /// </summary>
        public void Edit()
        {
            this.EditView = new EditWindow(this);
            this.EditView.Show();
        }

    }
}
