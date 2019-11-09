using GFAB.Model;
using Microsoft.EntityFrameworkCore;

namespace GFAB.Controllers
{

  /// <summary>
  /// A custom database context for InMemory database
  /// </summary>
  public class InMemoryDbContext : DbContext
  {

    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
    {

    }


    public DbSet<Meal> Meals { get; set; }

    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Meal>().HasKey(meal => meal.ID);

      builder.Entity<Meal>().OwnsOne(meal => meal.Designation);

      builder.Entity<Meal>().OwnsOne(meal => meal.Type);

      builder.Entity<Meal>().OwnsMany(meal => meal.Allergens);

      builder.Entity<Meal>().OwnsMany(meal => meal.Descriptors);

      builder.Entity<Meal>().OwnsMany(meal => meal.Ingredients);


      builder.Entity<Item>().OwnsOne(item => item.LivenessPeriod);

      builder.Entity<Item>().OwnsOne(item => item.MealId);

      builder.Entity<Item>().OwnsOne(item => item.Location);

      builder.Entity<Item>().OwnsOne(item => item.ItemId);
    }

  }

}