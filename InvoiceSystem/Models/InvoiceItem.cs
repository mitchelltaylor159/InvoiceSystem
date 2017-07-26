using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        /// <summary>
        /// Queries the DB for invoiceItems from a specified Invoice, creates a list of InvoiceItem objects, and returns it.
        /// </summary>
        /// <returns>A list of all InvoiceItem objects from the specified Invoice in the DB.</returns>
        public static List<InvoiceItem> GetInvoiceItems(int? invoiceID)
        {
            try
            {
                // Set up the variables
                string SQL = "SELECT * FROM InvoiceItem WHERE InvoiceID = " + invoiceID;
                int numRows = 0;
                List<InvoiceItem> itemList = new List<InvoiceItem>();

                // For non-DB invoice records
                if (invoiceID == null)
                {
                    return itemList;
                }

                // Call the DB query
                DataSet invoiceDS = DB.ExecuteSQLStatement(SQL, ref numRows);

                // Add each item to the list
                foreach (DataRow dr in invoiceDS.Tables[0].Rows)
                {
                    itemList.Add(new InvoiceItem(Convert.ToInt32(dr["InvoiceID"].ToString()),
                        Convert.ToInt32(dr["ItemID"].ToString()),
                        Convert.ToInt32(dr["Quantity"].ToString()),
                        Convert.ToInt32(dr["LineNumber"].ToString())));
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

                if (this.InvoiceID == null || this.ItemID== null)
                {
                    throw new Exception("Could not save InvoiceItem record: Insufficient information provided.");
                }

                // Builds a SQL string to save a record
                string SQL = "INSERT INTO InvoiceItem " + // INSERT INTO InvoiceItem
                    "(InvoiceID, ItemID, Quantity, LineNumber) VALUES " + // (InvoiceID, ItemID, Quantity, LineNumber) VALUES
                    "(\"" + this.InvoiceID + "\", " + // ("_____",
                    "\"" + this.ItemID+ "\", " + // "_____",
                    "\"" + this.Quantity + "\", " + // "_____",
                    "\"" + this.LineNumber + "\")"; // "_____")

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
                string SQL = "UPDATE InvoiceItem " + // UPDATE InvoiceItem
                    "SET InvoiceID = \"" + this.InvoiceID + "\", " + // SET InvoiceID = "_____",
                    "ItemID = \"" + this.ItemID + "\", " + // ItemID = "_____",
                    "Quantity = \"" + this.Quantity + "\", " + // Quantity = "_____",
                    "LineNumber = \"" + this.LineNumber + "\" " + // LineNumber = "_____"
                    "WHERE ItemID = " + this.ItemID + " " + // WHERE ItemID = _
                    "AND InvoiceID = " + this.InvoiceID; // AND InvoiceID = _
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
                string SQL = "DELETE FROM InvoiceItem WHERE ItemID = " + this.ItemID + " AND InvoiceID = " + this.InvoiceID;
                int numRows;
                
                numRows = DB.ExecuteNonQuery(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public override string ToString()
        {
            return this.LineNumber + ": " + this.Quantity;
        }
    }
}
