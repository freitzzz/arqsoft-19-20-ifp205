using System.Collections.Generic;
using GFAB.Model;

namespace GFAB.Controllers
{

  /// <summary>
  /// Repository for item aggregate root
  /// </summary>
  /// <typeparam name="Item">Type of the aggregate root</typeparam>
  /// <typeparam name="ItemID">Type of item business identifier</typeparam>
  public interface ItemRepository : Repository<Item, ItemID>
  {

    /// <summary>
    /// Retrieves the item that is identified by a given interal identifier
    /// Throws ArgumentException if no item matches the internal identifier
    /// </summary>
    /// <param name="id">The internal identifier</param>
    /// <returns>Item object that matches the internal identifier</returns>
    Item Find(long id);

    /// <summary>
    /// Retrieves all items available on the repository
    /// </summary>
    /// <returns>List with the existing available items found in the repository</returns>
    List<Item> All();

  }

}