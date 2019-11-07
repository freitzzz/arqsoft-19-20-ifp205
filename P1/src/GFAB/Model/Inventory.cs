using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GFAB.Model {

    //Entity which represents the inventory
    public class Inventory{

        //FOR ORM 
        protected Inventory() {

        }

        ///<summary>
        ///Represents the entity id in the database
        ///</summary>
        [Key]
        public int Id{get;set ;}
        ///<summary>
        /// Represents the list of items which the inventory will manage
        ///</summary>
        public List<Item> items{get;set;}

        /// <summary>
        /// Stores a item in the inventory
        /// </summary>
        /// <param name="item"></param>
        public void storeItem (Item item) {
            this.items.Add(item);
        }

        /// <summary>
        /// Removes item that exists on the inventory
        /// </summary>
        /// <param name="item"></param>
        public void deleteItem (Item item) {
            this.items.Remove(item);
        }

        /// <summary>
        /// Finds a specific item by its identification
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Item findItem(ItemID itemId) {
            
            bool found = false;

            int i = 0;

            Item foundItem = null;

            while(!found && i < this.items.Count) {
                if(this.items[i].Id().Equals(itemId)) {
                    found = true;
                    foundItem = this.items[i];
                }
            }

            return foundItem;
        }

        public void registerItemPurchase(UserType userType, int Itemid) {
            //TODO: call ItemService to save the purchase of a certain item
        }
    }
}