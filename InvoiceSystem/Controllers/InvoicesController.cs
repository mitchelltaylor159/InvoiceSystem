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
        /// Saves the active Invoice object to the DB.
        /// </summary>
        public void SaveActiveInvoice()
        {
            try
            {
                // Call function from Invoice
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Loads all of the invoices into the class variable, Invoices.
        /// </summary>
        public void LoadInvoices()
        {
            try
            {
                // Call function from Invoice
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public IEnumerable<Invoice> SearchInvoices()
        {
            // Replace with code (LINQ) to search.
            return new List<Invoice>();
        }
    }
}
