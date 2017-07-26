using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Models
{
    public class InvoiceItem
    {
        /// <summary>
        /// The DB Foreign Key for the Invoice.
        /// </summary>
        public int? InvoiceID { get; set; }
        
        /// <summary>
        /// The DB Foreign Key for the Item.
        /// </summary>
        public int? ItemID { get; set; }

        /// <summary>
        /// The quantity of the item added to an individual invoice.
        /// </summary>
        public int Quantity { get; set; }


        /// <summary>
        /// The default constructor.
        /// </summary>
        public InvoiceItem()
        {

        }

        /// <summary>
        /// The constructor that takes all of the properties to create an object.
        /// </summary>
        /// <param name="invoiceID">The DB Foreign Key for the Invoice.</param>
        /// <param name="itemID">The DB Foreign Key for the Item.</param>
        /// <param name="quantity">The quantity of the item added to an individual invoice.</param>
        public InvoiceItem(int invoiceID, int itemID, int quantity)
        {
            try
            {
                this.InvoiceID = invoiceID;
                this.ItemID = itemID;
                this.Quantity = quantity;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }

        // Code for DB queries and statements here...

    }
}
