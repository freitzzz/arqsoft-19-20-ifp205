using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// A domain service that allows the inject and retrieval of the existent meal types
  /// that are considered as valid
  /// </summary>
  public class ExistingMealTypesService : Service
  {

    // Global list that stores the existing meal type names as strings

    private static List<string> MealTypes = new List<string>();

    /// <summary>
    /// Allows the injection of the new existent meal types
    /// This function replaces the existing meal types with those provided in the argument
    /// </summary>
    /// <param name="mealTypes">A string list that defines the existent meal types</param>
    public static void InjectMealTypes(List<string> mealTypes)
    {

      // null check

      if (mealTypes == null)
      {
        throw new ArgumentNullException("cannot inject null meal types list");
      }


      // null elements check

      if (mealTypes.Contains(null))
      {
        throw new ArgumentNullException("cannot inject meal types list with null elements");
      }


      List<string> mealTypesList = mealTypes.Select((mealType) => mealType.ToLower()).ToList();

      HashSet<string> mealTypeListAsSet = mealTypesList.ToHashSet();

      // duplicates check

      if (mealTypes.Count > mealTypeListAsSet.Count)
      {
        throw new ArgumentException("cannot inject meal types list with duplicated elements");
      }

      MealTypes = new List<string>(mealTypes);
    }

    /// <summary>
    /// Allows the retrieval of the existent meal types
    /// </summary>
    /// <returns>A string list with the existent meal type names</returns>
    public static List<string> ExistingMealTypes => new List<string>(MealTypes);

  }

}