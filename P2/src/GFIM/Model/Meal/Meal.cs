using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{
  
  public class Meal : ValueObject
  {
    /// <summary>
    /// Internal identifier (database)
    /// </summary>
    public long MealId { get; protected set; }

    /// <summary>
    /// Designation identifies the meal as unique in the business
    /// </summary>
    public MealID Designation { get; protected set; }

    public static Meal ValueOf(long id, string designation) => new Meal(id, designation);
    
    private Meal(long id, string designation)
    {

      MealId = id;

      Designation = MealID.ValueOf(designation);
    }

    // Necessary for EF ORM
    protected Meal(){}
  }

}