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
    // TODO: @Pedro Coelho remove set usage in order to comply with Value Object pattern
    public string Id { get; set; }

    /// <summary>
    /// Creates an ItemID based on the item label specifications
    /// </summary>
    /// <param name="mealDesignation">The designation of the meal which the item corresponds to</param>
    /// <param name="itemIdentificationNumber">The item identification number</param>
    /// <param name="productionDate">The date in which the item was produced</param>
    /// <param name="expirationDate">The date in which the item expires</param>
    /// <returns>ItemID generated with the item label specifications</returns>
    public static ItemID ValueOf(string mealDesignation, int itemIdentificationNumber, DateTime productionDate, DateTime expirationDate){

      string generatedId = generateId(mealDesignation, itemIdentificationNumber, productionDate, expirationDate);

      return new ItemID(generatedId);
    }

    // TODO: @Pedro Coelho implement this function
    private static string generateId(string mealDesignation, int itemIdentificationNumber, DateTime productionDate, DateTime expirationDate)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Private and only constructor allowed for ItemID
    /// Object construction modifications should be done via ValueOf function variations
    /// </summary>
    /// <param name="id">The item business identifier</param>
    private ItemID(string id)
    {

      grantIdCannotBeNull(id);

      grantIdCompliesWithGenerationRule(id);

      this.Id = id;

    }

    // TODO: @PedroCoelho implement this verification method (should throw ArgumentException if verification fails)
    private void grantIdCompliesWithGenerationRule(string id)
    {
      throw new NotImplementedException();
    }

    // TODO: @PedroCoelho implement this verification method (should throw ArgumentException if verification fails)
    private void grantIdCannotBeNull(string id)
    {
      throw new NotImplementedException();
    }
  }
}