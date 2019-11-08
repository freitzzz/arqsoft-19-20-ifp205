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
      return ctx.Items.ToList();
    }

    public void Delete(Item rootToDelete)
    {
      throw new System.NotImplementedException();
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
      IQueryable<Item> items = ctx.Items.Where((item) => item.Id().Equals(rootIdentifier));

      if (items.Count() == 0)
      {
        throw new ArgumentException("no item matches the given business identifier");
      }

      return items.First();
    }

    public Item Save(Item rootToSave)
    {

      ctx.Items.Add(rootToSave);

      ctx.SaveChanges();

      return Find(rootToSave.Id());

    }

    public Item Update(Item rootToUpdate)
    {
      throw new System.NotImplementedException();
    }
  }

}