using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// A domain service that allows the inject and retrieval of the existent allergens
  /// that are considered as valid
  /// </summary>
  public class ExistingAllergensService : Service
  {

    // Global list that stores the existing allergen names as strings

    private static List<string> Allergens = new List<string>();

    /// <summary>
    /// Allows the injection of the new existent allergens
    /// This function replaces the existing allergens with those provided in the argument
    /// </summary>
    /// <param name="allergens">A string list that defines the existent allergens</param>
    public static void InjectAllergens(List<string> allergens)
    {

      // null check

      if (allergens == null)
      {
        throw new ArgumentNullException("cannot inject null allergens list");
      }


      // null elements check

      if (allergens.Contains(null))
      {
        throw new ArgumentNullException("cannot inject allergens list with null elements");
      }


      List<string> allergensList = allergens.Select((allergen) => allergen.ToLower()).ToList();

      HashSet<string> allergenListAsSet = allergensList.ToHashSet();

      // duplicates check

      if (allergens.Count > allergenListAsSet.Count)
      {
        throw new ArgumentException("cannot inject allergens list with duplicated elements");
      }

      Allergens = new List<string>(allergens);
    }

    /// <summary>
    /// Allows the retrieval of the existent allergens
    /// </summary>
    /// <returns>A string list with the existent allergen names</returns>
    public static List<string> ExistingAllergens => new List<string>(Allergens);

  }

}