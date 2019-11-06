using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// Descriptor is a model that represents a meal descriptor per 100 g of the meal
  /// </summary>
  public class Descriptor : ValueObject
  {

    /// <summary>
    /// Name identifies the descriptor
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Quantity identifies the existent quantity of the descriptor per 100g of meal
    /// </summary>
    public double Quantity { get; protected set; }

    /// <summary>
    /// QuantityUnit identifies the measure unit of the descriptor quantity
    /// </summary>
    public string QuantityUnit { get; protected set; }

    /// <summary>
    /// Creates a Descriptor based on its specifications
    /// </summary>
    /// <param name="name">A string that identifies the descriptor</param>
    /// <param name="quantity">A numerical value that identifies the descriptor quantity per 100g of meal</param>
    /// <param name="quantityUnit">A string that measures the descriptor quantity</param>
    /// <returns>Descriptor for the specified specifications</returns>
    // TODO: @Freitas Unit test
    public static Descriptor ValueOf(string name, double quantity, string quantityUnit)
    {
      return new Descriptor(name, quantity, quantityUnit);
    }

    /// <summary>
    /// Private and only constructor allowed for Descriptor
    /// </summary>
    /// <param name="name">The name that identifies the descriptor</param>
    /// <param name="quantity">The numeric quantity which the descriptor exists per 100g of meal</param>
    /// <param name="quantityUnit">The quantity unit that measures the descriptor quantity</param>
    // TODO: @Freitas Unit test
    private Descriptor(string name, double quantity, string quantityUnit)
    {

      grantNameCannotBeNull(name);

      grantNameExists(name);


      grantQuantityCannotBeLowerThanZero(quantity);

      grantQuantityCannotBeEqualToZero(quantity);


      grantQuantityUnitCannotBeNull(quantityUnit);

      grantQuantityUnitExists(quantityUnit);


      grantNameAndQuantityUnitMatch(name, quantityUnit);

      grantQuantityCannotBeGreaterThanOneHundredGrams(quantity, quantityUnit);

      this.Name = name;

      this.Quantity = quantity;

      this.QuantityUnit = quantityUnit;

    }

    /// <summary>
    /// Returns the descriptor quantity in grams
    /// </summary>
    /// <returns>double that identifies the descriptor quantity in grams</returns>
    public double QuantityInGrams()
    {

      return convertQuantityToGrams(Quantity, QuantityUnit);

    }

    // Verifies if the name and quantity unit match as valid
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantNameAndQuantityUnitMatch(string name, string quantityUnit)
    {
      IEnumerable<string> nameUnits = existingQuantityUnits(name);

      bool exists = nameUnits.Where((unit) => unit.Equals(quantityUnit)) != null;

      if (!exists)
      {
        throw new ArgumentException("descriptor quantity unit does not match with the name");
      }
    }

    // Verifies if the name is not null
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantNameCannotBeNull(string name)
    {
      if (name == null)
      {
        throw new ArgumentNullException("descriptor name cannot be null");
      }
    }

    // Verifies if the name matches the existing descriptor names which are considered as valid
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantNameExists(string name)
    {
      IEnumerable<string> names = existingNames();

      bool exists = names.Where((_name) => _name.Equals(name)) != null;

      if (!exists)
      {
        throw new ArgumentException("descriptor name match the existent names");
      }
    }

    // Verifies that the quantity in grams is not greater than 100 g
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantQuantityCannotBeGreaterThanOneHundredGrams(double quantity, string quantityUnit)
    {
      double quantityInGrams = convertQuantityToGrams(quantity, quantityUnit);

      if (quantityInGrams >= 100)
      {

        throw new ArgumentException("descriptor quantity in grams cannot be higher than one hundred grams");

      }
    }

    // Verifies that the quantity is not equal to zero
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantQuantityCannotBeEqualToZero(double quantity)
    {
      if (quantity == 0)
      {
        throw new ArgumentException("descriptor quantity cannot be equal to zero");
      }
    }

    // Verifies that the quantity cannot be lower than zero
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test	
    private void grantQuantityCannotBeLowerThanZero(double quantity)
    {
      if (quantity < 0)
      {
        throw new ArgumentException("descriptor quantity cannot be lower than zero");
      }
    }

    // Verifies if the quantity unit matches the existing descriptor names that are considered as valid
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantQuantityUnitExists(string quantityUnit)
    {
      IEnumerable<string> quantityUnits = existingQuantityUnits();

      bool exists = quantityUnits.Where((string unit) => unit.Equals(quantityUnit)) != null;

      if (!exists)
      {
        throw new ArgumentException("descriptor quantity unit does not match the existent quantity units");
      }
    }

    // Verifies that the quantity unit is not null
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantQuantityUnitCannotBeNull(string quantityUnit)
    {
      if (quantityUnit == null)
      {
        throw new ArgumentNullException("descriptor quantity unit cannot be null");
      }
    }

    // Allows the retrieval of the existing descriptor names which are considered as valid
    private IEnumerable<string> existingNames()
    {
      //TODO: Freitas Implement method
      throw new NotImplementedException();
    }

    // Allows the retrieval of the existing quantity units which are considered as valid
    private IEnumerable<string> existingQuantityUnits()
    {
      //TODO: Freitas Implement method
      throw new NotImplementedException();
    }

    // Allows the retrieval of the existing quantity units which are considered as valid
    // for a specified descriptor name
    private IEnumerable<string> existingQuantityUnits(string name)
    {
      //TODO: Freitas Implement method
      throw new NotImplementedException();
    }

    // Allows the conversion of a specified quantity and quantity unit to grams
    private double convertQuantityToGrams(double quantity, string quantityUnit)
    {
      //TODO: Freitas Implement method
      throw new NotImplementedException();
    }

  }
}