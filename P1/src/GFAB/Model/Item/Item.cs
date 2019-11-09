using System;
using System.ComponentModel.DataAnnotations;

namespace GFAB.Model
{

  //Entity that represents an item within the inventory
  //Also the root of the aggregate Item --> represented in our aggregate/root diagram aswell
  public class Item : AggregateRoot<ItemID>
  {
    // For the ORM
    protected Item()
    {
    }

    private int GenerateItemIdentificationNumber()
    {

      return (int)new Random().Next(1001);
    }

    public Item(MealID mealDesignation, string location, DateTime productionDate, DateTime expirationDate)
    {

      DateTime timeNow = DateTime.Now;

      this.mealId = mealDesignation;
      this.location = Location.ValueOf(location);
      this.livenessPeriod = TimePeriod.ValueOf(timeNow, timeNow.AddDays(1));
      this.expirationDate = expirationDate;
      this.productionDate = productionDate;
      this.id = ItemID.ValueOf(this.mealId.Id, this.GenerateItemIdentificationNumber(), this.productionDate, this.expirationDate);
    }

    /// <summary>
    /// Internal identifier (database)
    /// </summary>
    public long ID { get; protected set; }

    ///<summary>
    /// Identifies a certain item in inventory. This is unique for each item
    ///</summary>
    [Key]
    public ItemID id { get; set; }
    ///<summary>
    /// Represents the current location within the kitchen for a single item
    ///</summary>
    public Location location { get; set; }
    ///<summary>
    ///Represents the date which the item was produced
    ///</summary>
    public DateTime productionDate { get; set; }
    ///<summary>
    ///Represents the date for which the item can no longer be served
    ///</summary>
    public DateTime expirationDate { get; set; }
    ///<summary>
    /// Represents the period for which the item can be served in the cafeteria (for example)
    ///</summary>
    public TimePeriod livenessPeriod { get; set; }
    ///<summary>
    ///Flag which indicates if the item was already server or not
    /// By default a item isnt served
    ///</summary>
    public bool served { get; set; } = false;
    ///<summary>
    ///The unique identification of the meal which is currently related to a single item 
    ///</summary>
    public MealID mealId { get; set; }

    ///<summary>
    /// Method which will indicate if a item is avaliable at the moment or not
    ///</summary>
    public bool Available()
    {

      if (!this.served) return true;
      else return false;
    }

    public ItemID Id()
    {
      return id;
    }

    ///<summary>
    ///Method that will marked this item as served
    ///Returns false if the item was already served
    ///</summary>
    public bool markAsServed()
    {
      if (this.Available())
      {
        this.served = true;
        return true;
      }
      else return false;
    }
  }
}