namespace GFAB.View {

    /// <summary>
    /// Model View for the request POST: /items
    /// Add a new item to the inventory
    /// </summary>
    public class AddItemModelView {

        public AddItemModelView() {
            
        }

        /// <summary>
        /// The identification number of the meal associated to the new item
        /// </summary>
        /// <value></value>
        public int mealId {get; set;}

        /// <summary>
        /// ProductionDate defined for the item 
        /// </summary>
        /// <value></value>\
        public string productionDate {get; set;}

        /// <summary>
        /// Expiration date which the item will be no longer edible
        /// </summary>
        /// <value></value>
        public string expirationDate {get; set;}

        public AddItemModelView (int mealId, string productionDate, string expirationDate) {
            this.mealId = mealId;
            this.productionDate = productionDate;
            this.expirationDate = expirationDate;
        }
    }
}