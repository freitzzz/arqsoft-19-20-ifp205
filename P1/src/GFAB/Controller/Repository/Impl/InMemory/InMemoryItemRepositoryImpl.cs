using System;
using System.Collections.Generic;
using System.Linq;
using GFAB.Model;
using Microsoft.EntityFrameworkCore;

namespace GFAB.Controllers
{

  public class InMemoryItemRepositoryImpl : ItemRepository
  {

    private InMemoryDbContext ctx;

    public InMemoryItemRepositoryImpl(InMemoryDbContext dbContext)
    {
      ctx = dbContext;
    }

    public List<Item> All()
    {
      return ctx.Items.ToList().Where((item) => item.Available()).ToList();
    }

    public void Delete(Item rootToDelete)
    {
      ctx.Items.Remove(rootToDelete);

      ctx.SaveChanges();
    }

    public Item Find(long id)
    {
      Item item = ctx.Items.Find(id);

      if (item == null)
      {
        throw new ArgumentException("no item matches the given internal identifier");
      }

      return item;
    }

    public Item Find(ItemID rootIdentifier)
    {

      List<Item> allItems = All();

      IEnumerable<Item> items = allItems.Where((item) => item.ItemId.Equals(rootIdentifier));

      if (items.Count() == 0)
      {
        throw new ArgumentException("no item matches the given business identifier");
      }

      return items.First();
    }

    public Item Save(Item rootToSave)
    {

      try
      {
        Find(rootToSave.Id());
        throw new InvalidOperationException("item with the save business identifier already exists");
      }
      catch (ArgumentException noItemFound)
      {

        ctx.Items.Add(rootToSave);

        ctx.SaveChanges();

        return Find(rootToSave.Id());

      }

    }

    public Item Update(Item rootToUpdate)
    {
      ctx.Items.Update(rootToUpdate);

      ctx.SaveChanges();

      return rootToUpdate;
    }
  }

}