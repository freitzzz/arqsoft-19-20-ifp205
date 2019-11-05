namespace GFAB.Model
{

  /// <summary>
  /// An interface for marking objects that are identifiable
  /// </summary>
  /// <typeparam name="ID">Type of the identifier</typeparam>
  public interface Identifiable<ID>
  {

    /// <summary>
    /// Allows the access of the object identifier
    /// </summary>
    /// <returns>ID with the object identifier</returns>
    ID Id();

  }

}