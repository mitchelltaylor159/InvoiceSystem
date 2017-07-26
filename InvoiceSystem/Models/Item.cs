using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Models
{
    public class Item
    {
        /// <summary>
        /// The DB Primary Key.
        /// </summary>
        public int? ItemID { get; set; }

        /// <summary>
        /// The SKU of the item.  This is used on invoices and searches.
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// A title or name for the item: (e.g. Windows Surface 4 Pro).
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// The price of the individual item, in dollars.
        /// </summary>
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Item()
        {

        }

        /// <summary>
        /// The constructor that takes all of the parameters to create the object.
        /// </summary>
        /// <param name="itemID">The DB Primary Key.</param>
        /// <param name="itemCode">The SKU of the item.</param>
        /// <param name="itemDescription">A title for the item.</param>
        /// <param name="itemPrice">The price of the individual item, in dollars.</param>
        public Item(int? itemID, string itemCode, string itemDescription, decimal itemPrice)
        {
            try
            {
                this.ItemID = itemID;
                this.ItemCode = itemCode;
                this.ItemDescription = itemDescription;
                this.ItemPrice = itemPrice;
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
