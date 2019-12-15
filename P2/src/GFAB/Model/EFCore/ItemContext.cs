using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GFAB.Model.EFCore {

    public class ItemContext : DbContext {

        public DbSet<Item> Items {get; set;}

        // protected override void OnConfiguring(DbContextOptionsBuilder options) {
        //     => options.UseSqlServer("Data Source=items.db"); //TODO: Create local database
        // }
    }
}