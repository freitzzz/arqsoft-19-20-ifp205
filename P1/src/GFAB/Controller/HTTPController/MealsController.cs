using System;
using System.Collections.Generic;
using System.Linq;
using GFAB.Model;
using GFAB.View;
using Microsoft.AspNetCore.Mvc;

namespace GFAB.Controllers
{

  /// <summary>
  /// Controls endpoints for meals collection functionalities
  /// </summary>
  [Route("api/meals")]
  [ApiController]
  public class MealsController : ControllerBase
  {

    private RepositoryFactory factory;
    
    public MealsController(RepositoryFactory repositoryFactory)
    {
      factory = repositoryFactory;
    }

    [HttpGet]
    public IActionResult AvailableMeals()
    {
      try
      {
        List<Meal> meals = factory.MealRepository().All();

        if (meals.Count == 0)
        {
          return NotFound();
        }

        GetAvailableMealsModelView modelview = new GetAvailableMealsModelView(meals);

        return Ok(modelview);
      }
      catch (Exception databaseException)
      {
        // TODO: Log exception
        return StatusCode(500);
      }

    }

    [HttpGet("{id}")]
    public IActionResult DetailedMealInformation(long id)
    {

      try
      {

        Meal meal = factory.MealRepository().Find(id);

        GetDetailedMealInformationModelView modelview = new GetDetailedMealInformationModelView(meal);

        return Ok(modelview);

      }
      catch (ArgumentException noMealMatchIdException)
      {
        // TODO: Log exception
        return NotFound();

      }
      catch (Exception databaseException)
      {
        // TODO: Log exception
        return StatusCode(500);

      }

    }

    [HttpPost]
    public IActionResult CreateMeal([FromBody] CreateMealModelView createModelView)
    {

      try
      {

        string designation = createModelView.Designation;

        MealType type = MealType.ValueOf(createModelView.Type);

        List<Ingredient> ingredients = createModelView.Ingredients.Select((ingredient) => Ingredient.ValueOf(ingredient)).ToList();

        List<Allergen> allergens = createModelView.Allergens.Select((allergen) => Allergen.ValueOf(allergen)).ToList();

        List<Descriptor> descriptors = createModelView.Descriptors.Select((descriptor) => Descriptor.ValueOf(descriptor.Name, descriptor.Quantity, descriptor.QuantityUnit)).ToList();

        Meal meal;

        if (allergens.Count == 0)
        {
          meal = new Meal(designation, type, ingredients, descriptors);
        }
        else
        {
          meal = new Meal(designation, type, ingredients, descriptors, allergens);
        }

        meal = factory.MealRepository().Save(meal);

        GetDetailedMealInformationModelView modelview = new GetDetailedMealInformationModelView(meal);

        return Created("api/meals", modelview);

      }
      catch (InvalidOperationException argumentException)
      {
        // TODO: Log exception
        return BadRequest(new ErrorModelView(argumentException.Message));

      }
      catch (ArgumentException argumentException)
      {
        // TODO: Log exception
        return BadRequest(new ErrorModelView(argumentException.Message));

      }
      catch (Exception databaseException)
      {
        // TODO: Log exception
        return StatusCode(500);

      }

    }

  }

}