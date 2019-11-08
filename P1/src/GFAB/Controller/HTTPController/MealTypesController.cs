using System;
using System.Collections.Generic;
using GFAB.Model;
using GFAB.View;
using Microsoft.AspNetCore.Mvc;

namespace GFAB.Controllers
{

  /// <summary>
  /// Controls endpoints for meal types collection functionalities
  /// </summary>
  [Route("api/mealtypes")]
  [ApiController]
  public class MealTypesController : ControllerBase
  {

    [HttpGet]
    public IActionResult AvailableMealTypes()
    {
      try
      {
        List<string> mealTypes = ExistingMealTypesService.ExistingMealTypes;

        if (mealTypes.Count == 0)
        {
          return NotFound();
        }

        GetAvailableMealTypesModelView modelview = new GetAvailableMealTypesModelView(mealTypes);

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