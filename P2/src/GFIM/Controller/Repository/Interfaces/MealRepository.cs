using System.Collections.Generic;
using GFAB.Model;

namespace GFAB.Controllers
{

  /// <summary>
  /// Repository for meal aggregate root
  /// </summary>
  /// <typeparam name="Meal">Type of the aggregate root</typeparam>
  /// <typeparam name="MealID">Type of meal business identifier</typeparam>
  public interface MealRepository : Repository<Meal, MealID>
  {

    /// <summary>
    /// Retrieves the meal that is identified by a given interal identifier
    /// Throws ArgumentException if no meal matches the internal identifier
    /// </summary>
    /// <param name="id">The internal identifier</param>
    /// <returns>Meal object that matches the internal identifier</returns>
    Meal Find(long id);

    /// <summary>
    /// Retrieves all meals available on the repository
    /// </summary>
    /// <returns>List with the existing available meals found in the repository</returns>
    List<Meal> All();

  }

}