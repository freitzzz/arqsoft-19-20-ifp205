using System;
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

      grantNameCannotBePrecededBySpaces(name);

      grantNameCanOnlyContainLetters(name);

      grantNameIsAtLeastFourCharactersLong(name);

      this.Name = name;

    }

    // Verifies if the name is at least four characters long
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantNameIsAtLeastFourCharactersLong(string name)
    {
      if (name.Length < 4)
      {
        throw new ArgumentException("ingredient name must be at least four characters long");
      }
    }

    // Verifies if the name contains only letters ([a-Z])
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantNameCanOnlyContainLetters(string name)
    {
      if (name.All(Char.IsLetter))
      {
        throw new ArgumentException("ingredient name can only contain letters");
      }
    }

    // Verifies if the name is not preceded by spaces
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantNameCannotBePrecededBySpaces(string name)
    {
      if (name.StartsWith(" "))
      {
        throw new ArgumentException("ingredient name cannot preceded by spaces");
      }
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
  }

}