using System;
using System.Collections.Generic;
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

    }
}
