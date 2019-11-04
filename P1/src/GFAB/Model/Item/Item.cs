using System;

namespace GFAB.Model {

    //Entity that represents an item within the inventory
    //Also the root of the aggregate Item --> represented in our aggregate/root diagram aswell
    public class Item {
        // For the ORM
        protected Item() {
        }
        ///<summary>
        /// Represents the id that represents a item in the database
        ///</summary>
        public int Id{get; set;}

        ///<summary>
        /// Identifies a certain item in inventory. This is unique for each item
        ///</summary>
        public ItemID id {get; set;} 
        ///<summary>
        /// Represents the current location within the kitchen for a single item
        ///</summary>
        public Location location {get; set;}
        ///<summary>
        ///Represents the date which the item was produced
        ///</summary>
        public DateTime productionDate{get; set;}
        ///<summary>
        ///Represents the date for which the item can no longer be served
        ///</summary>
        public DateTime expirationDate {get; set;}
        ///<summary>
        /// Represents the period for which the item can be served in the cafeteria (for example)
        ///</summary>
        public TimePeriod livenessPeriod {get; set;}
        ///<summary>
        ///Flag which indicates if the item was already server or not
        /// By default a item isnt served
        ///</summary>
        public bool served {get; set;} = false;
        ///<summary>
        ///The unique identification of the meal which is currently related to a single item 
        ///</summary>
        //public MealID mealId {get; set;}

        ///<summary>
        /// Method which will indicate if a item is avaliable at the moment or not
        ///</summary>
        public bool avaliable () {

            if(!this.served) return true;
            else return false;
        }

        ///<summary>
        ///Method that will marked this item as served
        ///Returns false if the item was already served
        ///</summary>
        public bool markAsServed() {
            if(this.avaliable()) {
                this.served = true;
                return true;
            }
            else return false;
        }
    }
}