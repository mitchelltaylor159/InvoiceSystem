using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Controllers
{
    public class InvoicesController
    {
        /// <summary>
        /// The current working invoice.
        /// </summary>
        public Invoice ActiveInvoice { get; set; }

        /// <summary>
        /// A list of all invoices from the DB.
        /// </summary>
        public IEnumerable<Invoice> Invoices { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public InvoicesController()
        {

        }




        /// <summary>
        /// Loads all of the invoices into the class variable, Invoices.
        /// </summary>
        public void LoadInvoices()
        {
            try
            {
                // Call function from Invoice
                this.Invoices = Invoice.GetInvoices();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Search the loaded invoices, return a subset.
        /// </summary>
        /// <returns>A subset of all of the loaded invoices that match the given criteria.</returns>
        public IEnumerable<Invoice> SearchInvoices()
        {
            // Add arguments to the method declaration (overload for different search terms)
            // i.e. SearchInvoices(DateTime invoiceDate)  then another method declaration: SearchInvoices(int InvoiceID)

            // Replace with code (LINQ) to search this.Invoices and return.
            return new List<Invoice>();
        }


        /// <summary>
        /// Saves the active Invoice object to the DB.
        /// </summary>
        public void SaveActiveInvoice()
        {
            try
            {
                // Call function from Item
                this.ActiveInvoice.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the active Invoice object in the DB.
        /// </summary>
        public void UpdateActiveInvoice()
        {
            try
            {
                // Call function from Item
                this.ActiveInvoice.Update();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the active Invoice object from the DB.
        /// </summary>
        public void DeleteActiveInvoice()
        {
            try
            {
                // Call function from Invoice
                this.ActiveInvoice.Delete();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
