using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// Allergen is a model that represents a meal allergen
  /// </summary>
  public class Allergen : ValueObject
  {

    /// <summary>
    /// Name identifies the allergen
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Creates an Allergen based on its name
    /// </summary>
    /// <param name="name">A string that identifies the allergen</param>
    /// <returns>Allergen for the specified name</returns>
    // TODO: @Freitas Unit test
    public static Allergen ValueOf(string name)
    {

      return new Allergen(name);

    }

    /// <summary>
    /// Private and only constructor allowed for Allergen
    /// Object construction modifications should be done via ValueOf function variations
    /// </summary>
    /// <param name="name">The name that identifies the allergen</param>
    // TODO: @Freitas Unit test
    private Allergen(string name)
    {

      grantNameCannotBeNull(name);

      grantNameExists(name);

      this.Name = name;

    }

    // Necessary for EF ORM
    protected Allergen(){}

    /// <summary>
    /// Proves allergens equality
    /// </summary>
    /// <param name="comparingAllergen">The allergen being compared</param>
    /// <returns>bool true if equality was proven, false otherwise</returns>
    public override bool Equals(object comparingAllergen)
    {

      Allergen objAsAllergen = comparingAllergen as Allergen;
      return objAsAllergen != null && Name.Equals(objAsAllergen.Name);

    }

    /// <summary>
    /// Creates an integer representation of the allergen
    /// </summary>
    /// <returns>int with the allergen integer representation</returns>
    public override int GetHashCode() => Name.GetHashCode();

    // Verifies if the name matches the existent allergen names that are considered
    // as valid
    // TODO: @Freitas Unit Test
    private void grantNameExists(string name)
    {
      IEnumerable<string> names = existingNames();

      bool exists = names.Where((_name) => _name.Equals(name)).Count() != 0;

      if (!exists)
      {
        throw new ArgumentException("allergen name does not match the existent names");
      }
    }

    // Verifies if the name is not null
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantNameCannotBeNull(string name)
    {
      if (name == null)
      {
        throw new ArgumentNullException("allergen name cannot be null");
      }
    }

    // Retrieves the existent names that are considered as valid names for an allergen
    // TODO: @Freitas Unit Test
    private IEnumerable<string> existingNames()
    {
      return ExistingAllergensService.ExistingAllergens;
    }
  }

}