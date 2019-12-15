namespace GFAB.Model
{

  /// <summary>
  /// An interface for marking aggregate roots
  /// </summary>
  /// <typeparam name="E">Type of the entity which is the root of the aggregate</typeparam>
  public interface AggregateRoot<BID> : Entity<BID> { }

}