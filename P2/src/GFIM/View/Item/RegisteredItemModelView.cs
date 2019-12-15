using GFAB.Model;

namespace GFIM.View
{

  /// <summary>
  /// Model View that will be used on the web appilication to present a registered item
  /// </summary>
  public class RegisterItemModelView
  {

    public RegisterItemModelView()
    {

    }

    /// <summary>
    /// The Identification number of the certain item
    /// </summary>
    /// <value></value>
    public long id { get; set; }

    public long identificationNumber {get; set;}

    /// <summary>
    /// The Meal business identifier
    /// </summary>
    /// <value></value>
    public string mealId { get; set; }

    /// <summary>
    /// The generated label that can be printed to represent the item in the physicall location that will be stored
    /// </summary>
    /// <value></value>
    public string label { get; set; }

    /// <summary>
    /// The date that represents how long the item will be served for
    /// </summary>
    /// <value></value>
    public string availableToServeUntil { get; set; }

    /// <summary>
    /// The date that marks the production of the item
    /// </summary>
    /// <value></value>
    public string productionDate { get; set; }

    /// <summary>
    /// The date that marks when the item will expire, and no long be edible
    /// </summary>
    /// <value></value>
    public string expirationDate { get; set; }

    public RegisterItemModelView(Item item)
    {

      id = item.ID;

      mealId = item.MealId.Id;

      identificationNumber = item.IdentificationNumber;

      label = item.Id().Id;

      availableToServeUntil = item.LivenessPeriod.EndDateTime.ToString("yyyy'-'MM'-'ddTHH':'mm':'ss");

      productionDate = item.ProductionDate.ToString("yyyy'-'MM'-'dd");

      expirationDate = item.ExpirationDate.ToString("yyyy'-'MM'-'dd");

    }
  }
}