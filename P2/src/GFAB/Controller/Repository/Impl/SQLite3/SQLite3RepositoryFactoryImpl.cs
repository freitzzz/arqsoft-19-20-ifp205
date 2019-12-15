namespace GFAB.Controllers
{

  public class SQLite3RepositoryFactoryImpl : RepositoryFactory
  {

    private SQLite3DbContext ctx;

    public SQLite3RepositoryFactoryImpl(SQLite3DbContext dbContext)
    {
      ctx = dbContext;
    }

    public ItemPurchaseRepository ItemPurchaseRepository()
    {
      throw new System.NotImplementedException();
    }

    public ItemRepository ItemRepository()
    {
      return new SQLite3ItemRepositoryImpl(ctx);
    }

    public MealRepository MealRepository()
    {
      return new SQLite3MealRepositoryImpl(ctx);
    }
  }

}