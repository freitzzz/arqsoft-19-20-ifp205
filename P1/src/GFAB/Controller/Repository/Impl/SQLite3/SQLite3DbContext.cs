using GFAB.Model;
using Microsoft.EntityFrameworkCore;

namespace GFAB.Controllers
{

  /// <summary>
  /// A custom database context for SQLite3 database
  /// </summary>
  public class SQLite3DbContext : DbContext
  {

    public DbSet<Meal> Meals { get; set; }

    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }

  }

}