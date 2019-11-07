using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// Ingredient is a model that represents a meal ingredient
  /// </summary>
  public class Ingredient : ValueObject
  {

    /// <summary>
    /// Name identifies the ingredient
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Creates an Ingredient based on its name
    /// </summary>
    /// <param name="name">A string that identifies the ingredient</param>
    /// <returns>Ingredient for the specified name</returns>
    // TODO: @Freitas Unit test
    public static Ingredient ValueOf(string name)
    {

      return new Ingredient(name);

    }

    /// <summary>
    /// Private and only constructor allowed for Ingredient
    /// Object construction modifications should be done via ValueOf function variations
    /// </summary>
    /// <param name="name">The name that identifies the ingredient</param>
    // TODO: @Freitas Unit test
    private Ingredient(string name)
    {

      grantNameCannotBeNull(name);

      grantNameExists(name);

      this.Name = name;

    }

    // Verifies if the name is not null
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantNameCannotBeNull(string name)
    {
      if (name == null)
      {
        throw new ArgumentNullException("ingredient name cannot be null");
      }
    }

    // Verifies if the name matches the existent ingredient names that are considered
    // as valid
    // TODO: @Freitas Unit Test
    private void grantNameExists(string name)
    {
      IEnumerable<string> names = existingNames();

      bool exists = names.Where((_name) => _name.Equals(name)) != null;

      if (!exists)
      {
        throw new ArgumentException("ingredient name does not match the existent names");
      }
    }

	// Retrieves the existent names that are considered as valid names for an ingredient
    // TODO: @Freitas Unit Test
    private IEnumerable<string> existingNames()
    {
      return ExistingIngredientsService.ExistingIngredients;
    }
  }

}