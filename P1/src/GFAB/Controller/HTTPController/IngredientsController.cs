using System;
using System.Collections.Generic;
using GFAB.Model;
using GFAB.View;
using Microsoft.AspNetCore.Mvc;

namespace GFAB.Controllers
{

  /// <summary>
  /// Controls endpoints for ingredients collection functionalities
  /// </summary>
  [Route("api/ingredients")]
  [ApiController]
  public class IngredientsController : ControllerBase
  {

    [HttpGet]
    public IActionResult AvailableIngredients()
    {
      try
      {
        List<string> ingredients = ExistingIngredientsService.ExistingIngredients;

        if (ingredients.Count == 0)
        {
          return NotFound();
        }

        GetAvailableIngredientsModelView modelview = new GetAvailableIngredientsModelView(ingredients);

        return Ok(modelview);
      }
      catch (Exception databaseException)
      {
        // TODO: Log exception
        return StatusCode(500);
      }

    }

  }
}