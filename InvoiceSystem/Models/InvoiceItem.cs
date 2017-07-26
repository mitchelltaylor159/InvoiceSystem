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
        /// The line number that the item is on.
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// Static access to the Database
        /// </summary>
        public static Database DB = new Database();



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
        /// <param name="lineNumber">The line number that the item is on.</param>
        public InvoiceItem(int invoiceID, int itemID, int quantity, int lineNumber)
        {
            try
            {
                this.InvoiceID = invoiceID;
                this.ItemID = itemID;
                this.Quantity = quantity;
                this.LineNumber = lineNumber;
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
