namespace GFAB.Controllers
{

  public class InMemoryRepositoryFactoryImpl : RepositoryFactory
  {

    private InMemoryDbContext ctx;

    public InMemoryRepositoryFactoryImpl(InMemoryDbContext dbContext)
    {
      ctx = dbContext;
    }

    public ItemRepository ItemRepository()
    {
      return new InMemoryItemRepositoryImpl(ctx);
    }

    public MealRepository MealRepository()
    {
      return new InMemoryMealRepositoryImpl(ctx);
    }
  }

}