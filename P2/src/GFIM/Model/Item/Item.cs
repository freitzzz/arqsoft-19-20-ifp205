using System;
using System.ComponentModel.DataAnnotations;

namespace GFAB.Model
{

  //Entity that represents an item within the inventory
  //Also the root of the aggregate Item --> represented in our aggregate/root diagram aswell
  public class Item : AggregateRoot<ItemID>
  {

    /// <summary>
    /// Internal identifier (database)
    /// </summary>
    public long ID { get; protected set; }

    /// <summary>
    /// A generated number that identifies an item
    /// </summary>
    public long IdentificationNumber { get; protected set; }

    ///<summary>
    /// Identifies a certain item in inventory. This is unique for each item
    ///</summary>
    [Key]
    public ItemID ItemId { get; set; }
    ///<summary>
    ///Represents the date which the item was produced
    ///</summary>
    public DateTime ProductionDate { get; set; }
    ///<summary>
    ///Represents the date for which the item can no longer be served
    ///</summary>
    public DateTime ExpirationDate { get; set; }
    ///<summary>
    /// Represents the period for which the item can be served in the cafeteria (for example)
    ///</summary>
    public TimePeriod LivenessPeriod { get; set; }
    ///<summary>
    ///Flag which indicates if the item was already server or not
    /// By default a item isnt served
    ///</summary>
    public bool Served { get; set; } = false;
    ///<summary>
    ///The unique identification of the meal which is currently related to a single item 
    ///</summary>
    public MealID MealId { get; set; }

    public Item(MealID mealId, DateTime productionDate, DateTime expirationDate)
    {

      DateTime timeNow = DateTime.Now;

      grantMealIdCannotBeNull(mealId);


      grantProductionDateCannotBeNull(productionDate);

      grantExpirationDateCannotBeNull(expirationDate);

      grantProductionDateIsNotAfterTodaysDate(productionDate);

      grantExpirationDateIsNotBeforeTodaysDate(expirationDate);

      grantProductionDateIsNotAfterExpirationDate(productionDate, expirationDate);


      this.MealId = mealId;

      this.LivenessPeriod = TimePeriod.ValueOf(timeNow, timeNow.AddDays(1));

      this.ExpirationDate = expirationDate;

      this.ProductionDate = productionDate;

      long identificationNumber = ItemIdentificationNumberGeneratorService.RequestGenerator().Generate();

      this.IdentificationNumber = identificationNumber;

      this.ItemId = ItemID.ValueOf(this.MealId.Id, identificationNumber, this.ProductionDate, this.ExpirationDate);
    }

    // For the ORM
    protected Item()
    {
    }


    ///<summary>
    /// Method which will indicate if a item is avaliable at the moment or not
    ///</summary>
    public bool Available()
    {

      if (DateTime.Now > LivenessPeriod.EndDateTime)
      {
        return false;
      }

      if (DateTime.Now > ExpirationDate)
      {
        return false;
      }

      return !Served;
    }

    public ItemID Id()
    {
      return ItemId;
    }

    ///<summary>
    ///Method that will marked this item as served
    ///Returns false if the item was already served
    ///</summary>
    public bool markAsServed()
    {
      if (this.Available())
      {
        this.Served = true;
        return true;
      }
      else return false;
    }

    private void grantMealIdCannotBeNull(MealID mealId)
    {
      if (mealId == null)
      {

        throw new ArgumentNullException("item meal id cannot be null");

      }
    }

    private void grantProductionDateIsNotAfterExpirationDate(DateTime productionDate, DateTime expirationDate)
    {
      if (productionDate > expirationDate)
      {

        throw new ArgumentException("item production date cannot be after expiration date");

      }
    }

    private void grantExpirationDateIsNotBeforeTodaysDate(DateTime expirationDate)
    {
      if (expirationDate < DateTime.Now)
      {

        throw new ArgumentException("item expiration date cannot be before todays date");

      }
    }

    private void grantProductionDateIsNotAfterTodaysDate(DateTime productionDate)
    {
      if (productionDate > DateTime.Now)
      {

        throw new ArgumentException("item production date cannot be after todays date");

      }
    }

    private void grantProductionDateCannotBeNull(DateTime productionDate)
    {
      if (productionDate == null)
      {

        throw new ArgumentNullException("item production date cannot be null");

      }
    }

    private void grantExpirationDateCannotBeNull(DateTime expirationDate)
    {

      if (expirationDate == null)
      {

        throw new ArgumentNullException("item expiration date cannot be null");

      }
    }
  }
}