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
        /// A list of invoices based on a query from the Invoices property.
        /// </summary>
        public IEnumerable<Invoice> SearchedInvoices { get; set; }

        /// <summary>
        /// A list of all invoices from the DB.
        /// </summary>
        public IEnumerable<Invoice> Invoices { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public InvoicesController()
        {
            try
            {
                LoadInvoices();
                this.ActiveInvoice = null;
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
                this.Invoices = Invoice.GetInvoices();
                ClearSearch();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
        
        /// <summary>
         /// Resets the Invoice search.
         /// </summary>
        public void ClearSearch()
        {
            try
            {
                this.SearchedInvoices = this.Invoices.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Search the loaded invoices by InvoiceNumber, return a subset.
        /// </summary>
        /// <param name="invoiceNumber">The InvoiceNumber.</param>
        public void SearchInvoices(string invoiceNumber)
        {
            try
            {
                this.SearchedInvoices = this.SearchedInvoices.Where(m => m.InvoiceNumber.Equals(invoiceNumber));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Search the loaded invoices by price, return a subset.
        /// </summary>
        /// <param name="totalPrice">The total price of the Invoice.</param>
        /// <param name="GLE">(Greater than/Less than/Equal to) A string representing an operator (>,>=,=,etc).</param>
        public void SearchInvoices(decimal totalPrice, string GLE)
        {
            try
            {
                switch (GLE)
                {
                    case ">": this.SearchedInvoices = this.SearchedInvoices.Where(m => m.TotalPrice > totalPrice); break;
                    case ">=": this.SearchedInvoices = this.SearchedInvoices.Where(m => m.TotalPrice >= totalPrice); break;
                    case "<=": this.SearchedInvoices = this.SearchedInvoices.Where(m => m.TotalPrice <= totalPrice); break;
                    case "<": this.SearchedInvoices = this.SearchedInvoices.Where(m => m.TotalPrice < totalPrice); break;
                    default: this.SearchedInvoices = this.SearchedInvoices.Where(m => m.TotalPrice == totalPrice); break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Search the loaded invoices by date, return a subset.
        /// </summary>
        /// <param name="date">The Invoice InvoiceDate.</param>
        /// <param name="GLE">(Greater than/Less than/Equal to) A string representing an operator (>,>=,=,etc).</param>
        public void SearchInvoices(DateTime date, string GLE)
        {
            try
            {
                switch (GLE)
                {
                    // compare the 20170728120000 format, converted to int. 
                    case ">": this.SearchedInvoices = this.SearchedInvoices.Where(m => m.InvoiceDate > date); break;
                    case ">=": this.SearchedInvoices = this.SearchedInvoices.Where(m => m.InvoiceDate >= date); break;
                    case "<=": this.SearchedInvoices = this.SearchedInvoices.Where(m => m.InvoiceDate <= date); break;
                    case "<": this.SearchedInvoices = this.SearchedInvoices.Where(m => m.InvoiceDate < date); break;
                    default: this.SearchedInvoices = this.SearchedInvoices.Where(m => m.InvoiceDate == date); break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void SetActiveInvoice(object invoice)
        {
            try
            {
                this.ActiveInvoice = (Invoice)invoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
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
