namespace GFAB.View.Item {

    /// <summary>
    /// Model View that will be used on the web appilication to present a registered item
    /// </summary>
    public class RegisterItemModelView {

        public  RegisterItemModelView() {
            
        }

        /// <summary>
        /// The Identification number of the certain item
        /// </summary>
        /// <value></value>
        public int id {get; set;}

        /// <summary>
        /// The Meal Identification number associated to the certain item
        /// </summary>
        /// <value></value>
        public int mealId {get; set;}

        /// <summary>
        /// The generated label that can be printed to represent the item in the physicall location that will be stored
        /// </summary>
        /// <value></value>
        public string label {get; set;}

        /// <summary>
        /// The specific location that the registered item is going to be stored
        /// </summary>
        /// <value></value>
        public string location {get; set;}

        /// <summary>
        /// The date that represents how long the item will be served for
        /// </summary>
        /// <value></value>
        public string availableToServeUntil {get; set;}

        /// <summary>
        /// The date that marks the production of the item
        /// </summary>
        /// <value></value>
        public string productionDate {get; set;}

        /// <summary>
        /// The date that marks when the item will expire, and no long be edible
        /// </summary>
        /// <value></value>
        public string expirationDate {get; set;}

        public RegisterItemModelView (int id, int mealId, string label, string location, 
            string availableToServeUntil, string productionDate, string expirationDate) {

            this.id = id;
            this.mealId = mealId;
            this.label = label;
            this.location = location;
            this.availableToServeUntil = availableToServeUntil;
            this.productionDate = productionDate;
            this.expirationDate = expirationDate;
        }
    }
}