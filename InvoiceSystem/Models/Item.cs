using System;
using System.Collections.Generic;
using System.Data;
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
        /// Static access to the Database
        /// </summary>
        public static Database DB = new Database();

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

        /// <summary>
        /// Queries the DB for ALL items, creates a list of Items objects, and returns it.
        /// </summary>
        /// <returns>A list of all Item objects from the DB.</returns>
        public static List<Item> GetItems()
        {
            try
            {
                // Set up the variables
                string SQL = "SELECT * FROM Invoice";
                int numRows = 0;
                List<Item> itemList = new List<Item>();

                // Call the DB query
                DataSet invoiceDS = DB.ExecuteSQLStatement(SQL, ref numRows);

                // Add each item to the list
                foreach (DataRow dr in invoiceDS.Tables[0].Rows)
                {
                    itemList.Add(new Item(Convert.ToInt32(dr["ItemID"].ToString()), dr["ItemCode"].ToString(),
                        dr["ItemDescription"].ToString(), Decimal.FromOACurrency((long)dr["ItemPrice"]) ) );
                }

                return itemList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        public void Save()
        {
            try
            {
                if (this.ItemID != null)
                {
                    Update();
                    return;
                }

                if (this.ItemCode == null || this.ItemDescription == null)
                {
                    throw new Exception("Could not save Item record: Insufficient information provided.");
                }

                // Builds a SQL string to save a record
                string SQL = "INSERT INTO Item " + // INSERT INTO Item
                    "(ItemCode, ItemDescription, ItemPrice) VALUES " + // (ItemCode, ItemDescription, ItemPrice) VALUES
                    "(\"" + this.ItemCode + "\", " + // ("_____",
                    "\"" + this.ItemDescription + "\", " + // "_____",
                    "\"" + this.ItemPrice + "\")"; // "_____")
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the DB record for the current Invoice object.
        /// </summary>
        public void Update()
        {
            try
            {
                // Builds a SQL string to update the entry for the current Item object.
                string SQL = "UPDATE Item " + // UPDATE Item
                    "SET ItemCode = \"" + this.ItemCode + "\"" + // SET ItemCode = "_____"
                    ", ItemDescription = \"" + this.ItemDescription + "\"" + // , ItemDescription = "_____"
                    ", ItemPrice = \"" + this.ItemPrice + "\"" + // , ItemPrice = "_____"
                    "\" WHERE ItemID = " + this.ItemID; // WHERE ItemID = _
                int numRows;

                numRows = DB.ExecuteNonQuery(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the record for the current Invoice from the DB
        /// </summary>
        public void Delete()
        {
            try
            {
                // Delete the associated InvoiceItems
                string SQL = "DELETE FROM InvoiceItem WHERE ItemID = " + this.ItemID;
                int numRows;

                DB.ExecuteNonQuery(SQL);

                // Delete the Invoice
                SQL = "DELETE FROM Item WHERE ItemID = " + this.ItemID;

                numRows = DB.ExecuteNonQuery(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// ToString() Override Method
        /// </summary>
        /// <returns>ItemCode: ItemDescription</returns>
        override public string ToString()
        {
            return this.ItemCode + ": " + this.ItemDescription;
        }
    }
}
