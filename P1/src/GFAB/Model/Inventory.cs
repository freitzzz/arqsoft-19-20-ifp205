using System.Collections.Generic;

namespace GFAB.Model {

    //Entity which represents the inventory
    public class Inventory {

        //FOR ORM 
        protected Inventory() {

        }

        ///<summary>
        ///Represents the entity id in the database
        ///</summary>
        public int Id{get;set ;}
        ///<summary>
        /// Represents the list of items which the inventory will manage
        ///</summary>
        public List<Item> items{get;set;}

        public void storeItem (Item item) {
            //TODO : call ItemService to add a new item to the inventory
        }

        public void deleteItem (Item item) {
            //TODO : call ItemService to remove a new item in the inventory
        }

        public Item findItem(int itemId) {
            //TODO : call ItemService to find the item which holds the id that is a parameter to this function
            
            return null;
        }

        public void registerItemPurchase(UserType userType, int Itemid) {
            //TODO: call ItemService to save the purchase of a certain item
        }
    }
}