using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// A domain service that allows the inject and retrieval of the existent ingredients
  /// that are considered as valid
  /// </summary>
  public class ExistingIngredientsService : Service
  {

    // Global list that stores the existing ingredient names as strings

    private static List<string> Ingredients = new List<string>();

    /// <summary>
    /// Allows the injection of the new existent ingredients
    /// This function replaces the existing ingredients with those provided in the argument
    /// </summary>
    /// <param name="ingredients">A string list that defines the existent ingredients</param>
    public static void InjectIngredients(List<string> ingredients)
    {

      // null check

      if (ingredients == null)
      {
        throw new ArgumentNullException("cannot inject null ingredients list");
      }


      // null elements check

      if (ingredients.Contains(null))
      {
        throw new ArgumentNullException("cannot inject ingredients list with null elements");
      }


      List<string> ingredientsList = new List<string>(ingredients);

      HashSet<string> ingredientListAsSet = ingredientsList.ToHashSet();

      // duplicates check

      if (ingredients.Count > ingredientListAsSet.Count)
      {
        throw new ArgumentException("cannot inject ingredients list with duplicated elements");
      }

      Ingredients = ingredientsList;
    }

    /// <summary>
    /// Allows the retrieval of the existent ingredients
    /// </summary>
    /// <returns>A string list with the existent ingredient names</returns>
    public static List<string> ExistingIngredients => new List<string>(Ingredients);

  }

}