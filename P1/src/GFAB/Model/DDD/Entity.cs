namespace GFAB.Model
{

  /// <summary>
  /// An interface for marking entities
  /// </summary>
  /// <typeparam name="BID">Type of the entity business identifier</typeparam>
  public interface Entity<BID> : Identifiable<BID>
  {

    /// <summary>
    /// Creates an integer representation of the entity. By default it uses the business identifier
    /// hashcode function
    /// </summary>
    /// <returns>int with the entity integer representation</returns>
    int GetHashCode() => Id().GetHashCode();

    /// <summary>
    /// Proves entity equality. By default it uses the entities business identifiers
    /// to compare the entity
    /// </summary>
    /// <param name="obj">The comparing entity</param>
    /// <returns>bool true if equality was proven, false if not</returns>
    bool Equals(object obj)
    {
      Identifiable<BID> objIdentifiable = obj as Identifiable<BID>;
      return objIdentifiable != null && Id().Equals(objIdentifiable.Id());
    }

  }
}