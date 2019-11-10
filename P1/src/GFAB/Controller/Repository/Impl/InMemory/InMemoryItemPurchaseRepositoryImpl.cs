using System;
using System.Collections.Generic;
using System.Linq;
using GFAB.Model;
using Microsoft.EntityFrameworkCore;

namespace GFAB.Controllers
{

  public class InMemoryItemPurchaseRepositoryImpl : ItemPurchaseRepository
  {

    private InMemoryDbContext ctx;

    public InMemoryItemPurchaseRepositoryImpl(InMemoryDbContext dbContext)
    {
      ctx = dbContext;
    }

    public List<ItemPurchase> All()
    {
      return ctx.ItemPurchases.ToList();
    }

    public void Delete(ItemPurchase rootToDelete)
    {
      throw new System.NotImplementedException();
    }

    public ItemPurchase Find(long id)
    {
      throw new System.NotImplementedException();
    }

    public ItemPurchase Find(ItemPurchaseID rootIdentifier)
    {

      List<ItemPurchase> allItemPurchases = All();

      IEnumerable<ItemPurchase> itemPurchases = allItemPurchases.Where((itemPurchase) => itemPurchase.PurchaseID.Equals(rootIdentifier));

      if (itemPurchases.Count() == 0)
      {
        throw new ArgumentException("no item purchase matches the given business identifier");
      }

      return itemPurchases.First();
    }

    public ItemPurchase Save(ItemPurchase rootToSave)
    {

      try
      {
        Find(rootToSave.Id());
        throw new InvalidOperationException("item purchase with the same business identifier already exists");
      }
      catch (ArgumentException noItemPurchaseFound)
      {

        ctx.ItemPurchases.Add(rootToSave);

        ctx.SaveChanges();

        return Find(rootToSave.Id());

      }

    }

    public ItemPurchase Update(ItemPurchase rootToUpdate)
    {
      throw new System.NotImplementedException();
    }
  }

}