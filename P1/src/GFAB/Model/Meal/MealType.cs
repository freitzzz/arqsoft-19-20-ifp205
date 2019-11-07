using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// MealType is a model that represents the type of a meal
  /// </summary>
  public class MealType : ValueObject
  {

    /// <summary>
    /// Name identifies the meal type
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Creates a MealType based on its name
    /// </summary>
    /// <param name="name">A string that identifies the meal type</param>
    /// <returns>MealType for the specified name</returns>
    // TODO: @Freitas Unit test
    public static MealType ValueOf(string name)
    {

      return new MealType(name);

    }

    /// <summary>
    /// Private and only constructor allowed for MealType
    /// Object construction modifications should be done via ValueOf function variations
    /// </summary>
    /// <param name="name">The name that identifies the meal type</param>
    // TODO: @Freitas Unit test
    private MealType(string name)
    {

      grantNameCannotBeNull(name);

      grantNameExists(name);

      this.Name = name;

    }

    /// <summary>
    /// Proves meal types equality
    /// </summary>
    /// <param name="comparingMealType">The meal type being compared</param>
    /// <returns>bool true if equality was proven, false otherwise</returns>
    public override bool Equals(object comparingMealType)
    {

      MealType objAsMealType = comparingMealType as MealType;
      return objAsMealType != null && Name.Equals(objAsMealType.Name);

    }

    /// <summary>
    /// Creates an integer representation of the meal type
    /// </summary>
    /// <returns>int with the meal type integer representation</returns>
    public override int GetHashCode() => Name.GetHashCode();

    // Verifies if the name is not null
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantNameCannotBeNull(string name)
    {
      if (name == null)
      {
        throw new ArgumentNullException("mealtype name cannot be null");
      }
    }

    // Verifies if the name matches the existent meal type names that are considered
    // as valid
    // TODO: @Freitas Unit Test
    private void grantNameExists(string name)
    {
      IEnumerable<string> names = existingNames();

      bool exists = names.Where((_name) => _name.Equals(name)).Count() != 0;

      if (!exists)
      {
        throw new ArgumentException("mealtype name does not match the existent names");
      }
    }

    // Retrieves the existent names that are considered as valid names for a meal type
    // TODO: @Freitas Unit Test
    private IEnumerable<string> existingNames()
    {
      return ExistingMealTypesService.ExistingMealTypes;
    }
  }
}