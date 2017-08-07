using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Controllers
{
    public class ItemsController
    {
        /// <summary>
        /// The current working Item.
        /// </summary>
        public Item ActiveItem { get; set; }

        /// <summary>
        /// A list of all Items from the DB.
        /// </summary>
        public IEnumerable<Item> Items { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public ItemsController()
        {
            try
            {
                LoadItems();
                this.ActiveItem = null;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Creates a new item object
        /// </summary>
        public void CreateItem(int? itemID, string itemCode, string itemDescription, decimal itemPrice)
        {
            try
            {
                //Creates a new item
                Item temp = new Item(itemID, itemCode, itemDescription, itemPrice);
                this.ActiveItem = temp;
                this.SaveActiveItem();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Loads all of the Items into the class variable, Items.
        /// </summary>
        public void LoadItems()
        {
            try
            {
                // Call function from Item
                this.Items = Item.GetItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Searches all items by itemID and returns 1.
        /// </summary>
        /// <param name="itemID">The ItemID to search for.</param>
        /// <returns>A reference to the matching Item object.</returns>
        public Item SearchSingle(int? itemID)
        {
            try
            {
                return this.Items.Where(m => m.ItemID == itemID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Saves the active Item object to the DB.
        /// </summary>
        public void SaveActiveItem()
        {
            try
            {
                // Call function from Item
                this.ActiveItem.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the active Item object in the DB.
        /// </summary>
        public void UpdateActiveItem()
        {
            try
            {
                // Call function from Item
                this.ActiveItem.Update();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the active Item object from the DB.
        /// </summary>
        public void DeleteActiveItem()
        {
            try
            {
                // Call function from Item
                this.ActiveItem.Delete();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
