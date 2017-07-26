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

        }



        /// <summary>
        /// Saves the active InvoiceItem object to the DB.
        /// </summary>
        public void SaveActiveInvoiceItem()
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
    }
}
