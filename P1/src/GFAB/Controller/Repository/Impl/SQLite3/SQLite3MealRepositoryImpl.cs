using System;
using System.Collections.Generic;
using System.Linq;
using GFAB.Model;
using Microsoft.EntityFrameworkCore;

namespace GFAB.Controllers
{

  public class SQLite3MealRepositoryImpl : MealRepository
  {

    private SQLite3DbContext ctx;

    public SQLite3MealRepositoryImpl(SQLite3DbContext dbContext)
    {
      ctx = dbContext;
    }

    public List<Meal> All()
    {
      return ctx.Meals.ToList();
    }

    public void Delete(Meal rootToDelete)
    {
      throw new System.NotImplementedException();
    }

    public Meal Find(long id)
    {
      Meal meal = ctx.Meals.Find(id);

      if (meal == null)
      {
        throw new ArgumentException("no meal matches the given internal identifier");
      }

      return meal;
    }

    public Meal Find(MealID rootIdentifier)
    {
      IQueryable<Meal> meals = ctx.Meals.Where((meal) => meal.Id().Equals(rootIdentifier));

      if (meals.Count() == 0)
      {
        throw new ArgumentException("no meal matches the given business identifier");
      }

      return meals.First();
    }

    public Meal Save(Meal rootToSave)
    {

      ctx.Meals.Add(rootToSave);

      ctx.SaveChanges();

      return Find(rootToSave.Id());

    }

    public Meal Update(Meal rootToUpdate)
    {
      throw new System.NotImplementedException();
    }
  }

}