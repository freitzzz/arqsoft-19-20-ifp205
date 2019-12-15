using System;

namespace GFAB.Model
{

  /// <summary>
  /// A domain service that allows the conversion of descriptors quantity units
  /// </summary>
  public class DescriptorQuantityUnitConversionService : Service
  {

    /// <summary>
    /// Allows the conversion of a given quantity in a given quantity unit to grams
    /// </summary>
    /// <param name="quantity">The quantity being converted to grams</param>
    /// <param name="quantityUnit">The unit that measures the quantity unit</param>
    /// <returns>The given quantity in grams</returns>
    // TODO: ATAM - The design of this solution fits the requirements for the PoC, however
    // it should be rethinked to a more "strategic" solution
    public static double ConvertToGrams(double quantity, string quantityUnit)
    {

      double oneUnitMeasureInGram;

      switch (quantityUnit)
      {
        case "g":
          oneUnitMeasureInGram = 1;
          break;
        case "mg":
          oneUnitMeasureInGram = 0.001;
          break;
        case "kg":
          oneUnitMeasureInGram = 1000;
          break;
        case "cal":
          oneUnitMeasureInGram = 0.12959782;
          break;
        case "kcal":
          oneUnitMeasureInGram = 129.59782;
          break;
        default:
          throw new ArgumentException("cannot convert quantity unit {quantityUnit} to grams", quantityUnit);
      }

      return quantity * oneUnitMeasureInGram;
    }

  }

}