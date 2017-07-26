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

        }



        /// <summary>
        /// Saves the active Item object to the DB.
        /// </summary>
        public void SaveActiveItem()
        {
            try
            {
                // Call function from Item
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
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
