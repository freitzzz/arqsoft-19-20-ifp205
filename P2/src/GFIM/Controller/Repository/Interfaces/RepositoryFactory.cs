namespace GFAB.Controllers
{

  /// <summary>
  /// A factory that allows the creation of repositories
  /// </summary>
  public interface RepositoryFactory
  {

    ItemRepository ItemRepository();

  }

}