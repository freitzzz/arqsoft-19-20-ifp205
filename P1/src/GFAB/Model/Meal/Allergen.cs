using System;
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

      grantNameCannotBePrecededBySpaces(name);

      grantNameCanOnlyContainLetters(name);

      grantNameIsAtLeastThreeCharactersLong(name);

      this.Name = name;

    }

    // Verifies if the name is at least three characters long
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantNameIsAtLeastThreeCharactersLong(string name)
    {
      if (name.Length < 3)
      {
        throw new ArgumentException("allergen name must be at least three characters long");
      }
    }

    // Verifies if the name contains only letters ([a-Z])
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantNameCanOnlyContainLetters(string name)
    {
      if (name.All(Char.IsLetter))
      {
        throw new ArgumentException("allergen name can only contain letters");
      }
    }

    // Verifies if the name is not preceded by spaces
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantNameCannotBePrecededBySpaces(string name)
    {
      if (name.StartsWith(" "))
      {
        throw new ArgumentException("allergen name cannot preceded by spaces");
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
  }

}