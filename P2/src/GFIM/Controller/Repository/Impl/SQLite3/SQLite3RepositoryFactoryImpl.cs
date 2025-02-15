namespace GFAB.Controllers
{

  public class SQLite3RepositoryFactoryImpl : RepositoryFactory
  {

    private SQLite3DbContext ctx;

    public SQLite3RepositoryFactoryImpl(SQLite3DbContext dbContext)
    {
      ctx = dbContext;
    }

    public ItemRepository ItemRepository()
    {
      return new SQLite3ItemRepositoryImpl(ctx);
    }
  }

}