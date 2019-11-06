using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// A domain service that allows the inject and retrieval of the existent descriptors
  /// that are considered as valid
  /// </summary>
  public class ExistingDescriptorsService : Service
  {

    // Global dictionary that stores the existing descriptor names as strings and their quantity units as list of strings

    private static Dictionary<string, List<string>> Descriptors = new Dictionary<string, List<string>>();

    /// <summary>
    /// Allows the injection of the new existent descriptors
    /// This function replaces the existing descriptors with those provided in the argument
    /// </summary>
    /// <param name="descriptors">A dictionary that defines the existent descriptors</param>
    public static void InjectDescriptors(Dictionary<string, List<string>> descriptors)
    {

      // null check

      if (descriptors == null)
      {
        throw new ArgumentNullException("cannot inject null descriptors maps");
      }

      // null elements check

      List<List<string>> descriptorsQuantityUnits = descriptors.Values.ToList();

      if (descriptorsQuantityUnits.Contains(null))
      {
        throw new ArgumentNullException("cannot inject null quantity units lists");
      }

      bool hasNullQuantityUnits = false;

      hasNullQuantityUnits = descriptorsQuantityUnits.Where((quantityUnits) => quantityUnits.Contains(null)) != null;

      if (hasNullQuantityUnits)
      {
        throw new ArgumentNullException("cannot inject null quantity units");
      }
      
      // duplicates check

      bool hasDuplicates = false;

      hasDuplicates
        = descriptorsQuantityUnits
        .Where((quantityUnits) => quantityUnits.Count > quantityUnits.ToHashSet().Count) != null;

      

      if (hasDuplicates)
      {
        throw new ArgumentException("cannot inject quantity units lists with duplicated elements");
      }

      Descriptors = new Dictionary<string, List<string>>(descriptors.ToList());
    }

    /// <summary>
    /// Allows the retrieval of the existent descriptors
    /// </summary>
    /// <returns>A dictionary with the existent descriptor names by their quantity units</returns>
    // TODO: ATAM - This operation is expensive and may be rethinked
    public static Dictionary<string, List<string>> ExistingDescriptors => new Dictionary<string, List<string>>(Descriptors.ToList());

  }

}