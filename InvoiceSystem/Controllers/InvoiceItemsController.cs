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
        public List<InvoiceItem> InvoiceItems { get; set; }

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
        /// Deletes the active InvoiceItem object from the InvoiceItems List.
        /// </summary>
        public void DeleteActiveItem()
        {
            try
            {
                // Call function from Item
                // this.ActiveInvoiceItem.Delete();
                ((List<InvoiceItem>)this.InvoiceItems).Remove(this.ActiveInvoiceItem);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Saves/Updates all InvoiceItems in the current list.
        /// </summary>
        public void SaveInvoiceItems()
        {
            try
            {
                string SQL = "DELETE FROM InvoiceItem WHERE InvoiceID = " + this.ActiveInvoiceItem.InvoiceID;
                InvoiceItem.DB.ExecuteNonQuery(SQL);

                for (int i = 0; i < this.InvoiceItems.Count(); i++)
                {
                    this.InvoiceItems.ElementAt(i).Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes all InvoiceItem records from the DB for the activeInvoice. Saves all InvoiceItems in the current list.
        /// </summary>
        /// <param name="ActiveInvoice">The active (selected) invoice.</param>
        public void SaveInvoiceItems(Invoice activeInvoice)
        {
            try
            {
                string SQL = "DELETE FROM InvoiceItem WHERE InvoiceID = " + activeInvoice.InvoiceID;
                InvoiceItem.DB.ExecuteNonQuery(SQL);

                for (int i = 0; i < this.InvoiceItems.Count(); i++)
                {
                    this.InvoiceItems.ElementAt(i).InvoiceID = activeInvoice.InvoiceID;
                    this.InvoiceItems.ElementAt(i).Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Adds a new InvoiceItem to the current list of InvoiceItems.
        /// </summary>
        /// <param name="activeInvoice">The active (selected) Invoice.</param>
        /// <param name="activeItem">The active (selected) Item.</param>
        /// <param name="quantity">The quantity of the Item to add.</param>
        public void AddInvoiceItem(Invoice activeInvoice, Item activeItem, int quantity)
        {
            try
            {
                this.ActiveInvoiceItem = new InvoiceItem(activeInvoice.InvoiceID, activeItem.ItemID, quantity, InvoiceItems.Count() + 1);
                ((this.InvoiceItems)).Add(this.ActiveInvoiceItem);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



    }
}
