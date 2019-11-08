using System;

namespace GFAB.Model
{

  /// <summary>
  /// ItemID is a model that identifies the business identifier of an Item
  /// </summary>
  public class ItemID : ValueObject
  {

    /// <summary>
    /// Id identifies the item business identifier
    /// </summary>
    /// <value></value>
    public string Id { get; }

    /// <summary>
    /// Creates an ItemID based on the item label specifications
    /// </summary>
    /// <param name="mealDesignation">The designation of the meal which the item corresponds to</param>
    /// <param name="itemIdentificationNumber">The item identification number</param>
    /// <param name="productionDate">The date in which the item was produced</param>
    /// <param name="expirationDate">The date in which the item expires</param>
    /// <returns>ItemID generated with the item label specifications</returns>
    /// TODO : Unit Test this function
    public static ItemID ValueOf(string mealDesignation, int itemIdentificationNumber, DateTime productionDate, DateTime expirationDate){

      string generatedId = GenerateId(mealDesignation, itemIdentificationNumber, productionDate, expirationDate);

      return new ItemID(generatedId);
    }

    ///<summary>
    /// Identification generation algorithm
    ///</summary>
    private static string GenerateId(string mealDesignation, int itemIdentificationNumber, DateTime productionDate, DateTime expirationDate)
    {
      return mealDesignation + ":" + itemIdentificationNumber.ToString() + "\n" + productionDate.ToShortDateString() + "-" + expirationDate.ToShortDateString();
    }

    /// <summary>
    /// Private and only constructor allowed for ItemID
    /// Object construction modifications should be done via ValueOf function variations
    /// </summary>
    /// <param name="id">The item business identifier</param>
    private ItemID(string id)
    {

      GrantIdCannotBeNull(id);

      GrantIdCompliesWithGenerationRule(id);

      this.Id = id;

    }

    // Necessary for EF ORM
    protected ItemID(){}

    // TODO: @PedroCoelho implement this verification method (should throw ArgumentException if verification fails)
    private void GrantIdCompliesWithGenerationRule(string id)
    {
      throw new NotImplementedException();
    }

    private void GrantIdCannotBeNull(string id)
    {
      if(String.IsNullOrEmpty(id))
        throw new ArgumentNullException("item identification cant be empty");
    }
  }
}