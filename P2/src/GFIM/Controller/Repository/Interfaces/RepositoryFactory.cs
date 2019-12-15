namespace GFAB.Controllers
{

  /// <summary>
  /// A factory that allows the creation of repositories
  /// </summary>
  public interface RepositoryFactory
  {
    MealRepository MealRepository();

    ItemRepository ItemRepository();

    ItemPurchaseRepository ItemPurchaseRepository();

  }

}