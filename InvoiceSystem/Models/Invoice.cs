using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Models
{
    public class Invoice
    {
        /// <summary>
        /// The DB Primary Key.
        /// </summary>
        public int? InvoiceID { get; set; }

        /// <summary>
        /// An auto-generated number for the invoice.
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// The date the of the invoice.
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// The status of the invoice.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Static access to the Database
        /// </summary>
        public static Database DB = new Database();

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Invoice()
        {

        }

        /// <summary>
        /// The constructor that uses all properties to create an object.
        /// </summary>
        /// <param name="invoiceID">The DB Primary Key.</param>
        /// <param name="invoiceNumber">The auto-generated number for the invoice.</param>
        /// <param name="invoiceDate">The date of the invoice.</param>
        /// <param name="status">The status of the invoice.</param>
        public Invoice(int invoiceID, string invoiceNumber, DateTime invoiceDate, string status)
        {
            try
            {
                this.InvoiceID = invoiceID;
                this.InvoiceNumber = invoiceNumber;
                this.InvoiceDate = invoiceDate;
                this.Status = status;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        // Code for DB queries and statements here...

        /// <summary>
        /// Queries the DB for ALL invoices, creates a list of Invoice objects, and returns it.
        /// </summary>
        /// <returns>A list of all Invoice objects from the DB.</returns>
        public static List<Invoice> GetInvoices()
        {
            try
            {
                // Set up the variables
                string SQL = "SELECT * FROM Invoice";
                int numRows = 0;
                List<Invoice> invoiceList = new List<Invoice>();

                // Call the DB query
                DataSet invoiceDS = DB.ExecuteSQLStatement(SQL, ref numRows);

                // Add each item to the list
                foreach (DataRow dr in invoiceDS.Tables[0].Rows)
                {
                    invoiceList.Add(new Invoice(Convert.ToInt32(dr["InvoiceID"].ToString()), dr["InvoiceNumber"].ToString(),
                        DateTime.Parse(dr["InvoiceDate"].ToString()), dr["Status"].ToString()) );
                }

                return invoiceList;
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
                if (this.InvoiceID != null)
                {
                    Update();
                    return;
                }

                if (this.InvoiceDate == null && this.Status == null)
                {
                    throw new Exception("Could not save record: No information provided.");
                }

                // Builds a SQL string to save a record with the invoice date (if available, or without it if it's not set) 
                // and the status (default to "Created" if it's not set)
                string SQL = "INSERT INTO Invoice " + // INSERT INTO Invoice
                    "(" + (this.InvoiceDate != null? "InvoiceDate, " : "") + "Status)" + // (InvoiceDate, Status) *or (Status)
                    "VALUES (\"" + (this.InvoiceDate != null ? "\"" + this.InvoiceDate.ToOADate() + "\", " : "") + // VALUES ("____", *or VALUES (
                    (this.Status != null ? "\"" + this.Status + "\"": "\"Created\"") + ")"; // "_____")
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
                string SQL = "UPDATE Invoice " + // UPDATE Invoice
                    "SET InvoiceDate = \"" + this.InvoiceDate.ToOADate() + // SET InvoiceDate = "_____"
                    "\", Status = \"" + (this.Status == null? "" : this.Status) + // , Status = "_____"
                    "\" WHERE InvoiceID = " + this.InvoiceID; // WHERE InvoiceID = _
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
                string SQL = "DELETE FROM InvoiceItem WHERE InvoiceID = " + this.InvoiceID;
                int numRows;

                DB.ExecuteNonQuery(SQL);

                // Delete the Invoice
                SQL = "DELETE FROM Invoice WHERE InvoiceID = " + this.InvoiceID;

                numRows = DB.ExecuteNonQuery(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


    }
}
