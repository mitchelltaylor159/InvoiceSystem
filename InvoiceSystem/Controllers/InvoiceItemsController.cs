using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Controllers
{
    public class InvoiceItemsController
    {
        /// <summary>
        /// The current working InvoiceItem.
        /// </summary>
        public InvoiceItem ActiveInvoiceItem { get; set; }

        /// <summary>
        /// A list of all InvoiceItems from the DB.
        /// </summary>
        public IEnumerable<InvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public InvoiceItemsController()
        {
            try
            {
                this.ActiveInvoiceItem = null;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        
        /// <summary>
        /// Loads all of the InvoiceItems into the class variable, InvoiceItems.
        /// </summary>
        public void LoadInvoiceItems()
        {
            try
            {
                // Call function from InvoiceItem
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Loads all of the InvoiceItems from an invoice into the class variable, InvoiceItems.
        /// </summary>
        public void LoadInvoiceItems(Invoice invoice)
        {
            try
            {
                // Call function from InvoiceItem
                this.InvoiceItems = InvoiceItem.GetInvoiceItems(invoice.InvoiceID);
                /*for(int i = 0; i<this.InvoiceItems.Count(); i++)
                {
                    this.InvoiceItems.ElementAt(i).LineItem = 
                } addd method for*/
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Saves the active InvoiceItem object to the DB.
        /// </summary>
        public void SaveActiveInvoiceItem()
        {
            try
            {
                // Call function from Item
                this.ActiveInvoiceItem.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the active InvoiceItem object in the DB.
        /// </summary>
        public void UpdateActiveInvoiceItem()
        {
            try
            {
                // Call function from Item
                this.ActiveInvoiceItem.Update();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the active InvoiceItem object from the DB.
        /// </summary>
        public void DeleteActiveItem()
        {
            try
            {
                // Call function from Item
                this.ActiveInvoiceItem.Delete();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



    }
}
