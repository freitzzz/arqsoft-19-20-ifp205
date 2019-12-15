using System;
using System.Collections.Generic;
using System.Linq;
using GFAB.Model;
using Microsoft.EntityFrameworkCore;

namespace GFAB.Controllers
{

  public class InMemoryMealRepositoryImpl : MealRepository
  {

    private InMemoryDbContext ctx;

    public InMemoryMealRepositoryImpl(InMemoryDbContext dbContext)
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

      List<Meal> allMeals = All();

      IEnumerable<Meal> meals = allMeals.Where((meal) => meal.Designation.Equals(rootIdentifier));

      if (meals.Count() == 0)
      {
        throw new ArgumentException("no meal matches the given business identifier");
      }

      return meals.First();
    }

    public Meal Save(Meal rootToSave)
    {

      try
      {
        Find(rootToSave.Id());
        throw new InvalidOperationException("meal with the save business identifier already exists");
      }
      catch (ArgumentException noMealFound)
      {

        ctx.Meals.Add(rootToSave);

        ctx.SaveChanges();

        return Find(rootToSave.Id());

      }

    }

    public Meal Update(Meal rootToUpdate)
    {
      throw new System.NotImplementedException();
    }
  }

}