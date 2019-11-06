using System;
using System.Linq;

namespace GFAB.Model
{
  /// <summary>
  /// MealID is a model that identifies the business identifier of a meal
  /// This identifier corresponds to the meal designation
  /// </summary>
  public class MealID : ValueObject
  {

    /// <summary>
    /// Id identifies the meal business identifier
    /// </summary>
    public string Id { get; internal set; }

    /// <summary>
    /// Creates a MealID using the meal designation as the business identifier
    /// </summary>
    /// <param name="mealDesignation">The designation of the meal which identifies it</param>
    /// <returns>MealID for the specified meal designation</returns>
    // TODO: @Freitas Unit test
    public static MealID ValueOf(string mealDesignation)
    {

      return new MealID(mealDesignation);

    }

    /// <summary>
    /// Private and only constructor allowed for MealID
    /// Object construction modifications should be done via ValueOf function variations
    /// </summary>
    /// <param name="id">The meal business identifier</param>
    // TODO: @Freitas Unit test
    private MealID(string id)
    {

      grantIdCannotBeNull(id);

      grantIdCannotBePrecededBySpaces(id);

      grantIdCanOnlyContainLetters(id);

      grantIdStartsWithCapitalCaseLetter(id);

      grantIdIsAtLeastFourCharactersLong(id);

      this.Id = id;

    }

    // Verifies if the id starts with a capital case letter ([A-Z])
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantIdStartsWithCapitalCaseLetter(string id)
    {
      if (!Char.IsUpper(id.First()))
      {

        throw new ArgumentException("meal id must start with a capital case letter");

      }
    }

    // Verifies if the id only contains letters ([a-Z])
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantIdCanOnlyContainLetters(string id)
    {
      if (!id.All(Char.IsLetter))
      {
        throw new ArgumentException("meal id cannot only contain letters");
      }
    }

    // Verifies if the id is not preceded by spaces (at the start of the string)
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantIdCannotBePrecededBySpaces(string id)
    {
      if (id.StartsWith(" "))
      {
        throw new ArgumentException("meal id cannot be preceded by spaces");
      }
    }

    // Verifies if the id is at least four characters long
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantIdIsAtLeastFourCharactersLong(string id)
    {
      if (id.Length < 4)
      {
        throw new ArgumentException("meal id must be at least four characters long");
      }
    }

    // Verifies if the id is not null
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantIdCannotBeNull(string id)
    {
      if (id == null)
      {
        throw new ArgumentNullException("meal id cannot be null");
      }
    }
  }

}