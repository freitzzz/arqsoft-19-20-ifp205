namespace GFAB.Model
{
    
	/// <summary>
  /// An interface for marking repositories
  /// </summary>
  /// <typeparam name="AR">Type of the aggregate root which repository is of</typeparam>
  public interface Repository<AR, BID> where AR : AggregateRoot<BID>
  {

    /// <summary>
    /// Allows the save of an aggregate root
    /// Throws an ArgumentException if the aggregate root already exists
    /// Throws an InvalidOperationException if an error occurred in the save process
    /// </summary>
    /// <param name="rootToSave">AR which is desired to save</param>
    /// <returns>Instance of the saved AR</returns>
    AR Save(AR rootToSave);

    /// <summary>
    /// Allows the update of an existent aggregate root
    /// Throws an ArgumentException if the aggregate root does not exist
    /// Throws an InvalidOperationException if an error occurred in the update process
    /// </summary>
    /// <param name="rootToUpdate">AR which is desired to update</param>
    /// <returns>Instance of the updated AR</returns>
    AR Update(AR rootToUpdate);

    /// <summary>
    /// Allows the find of an existent aggregate root identified 
    /// by the specified business identifier.
    /// Throws an ArgumentException if no aggregate root was found to be identifiable 
    /// by the identifier
    /// </summary>
    /// <param name="rootIdentifier">Business Identifier of the AR</param>
    /// <returns>Instance of the AR which is identifiable by the business identifier</returns>
    AR Find(BID rootIdentifier);

    /// <summary>
    /// Allows the deletion of an existent aggregate root
    /// Throws an ArgumentException if the aggregate root does not exist
    /// Throws an InvalidOperationException if an error occurred in the deletion process
    /// </summary>
    /// <param name="rootToDelete">AR which is desired to delete</param>
    void Delete(AR rootToDelete);
  }

}