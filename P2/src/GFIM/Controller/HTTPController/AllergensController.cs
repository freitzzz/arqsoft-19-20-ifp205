using System;
using System.Collections.Generic;
using GFAB.Model;
using GFAB.View;
using Microsoft.AspNetCore.Mvc;

namespace GFAB.Controllers
{

  /// <summary>
  /// Controls endpoints for allergens collection functionalities
  /// </summary>
  [Route("api/allergens")]
  [ApiController]
  public class AllergensController : ControllerBase
  {

    [HttpGet]
    public IActionResult AvailableAllergens()
    {
      try
      {
        List<string> allergens = ExistingAllergensService.ExistingAllergens;

        if (allergens.Count == 0)
        {
          return NotFound(null);
        }

        GetAvailableAllergensModelView modelview = new GetAvailableAllergensModelView(allergens);

        return Ok(modelview);
      }
      catch (Exception databaseException)
      {
        // TODO: Log exception
        return StatusCode(500, null);
      }

    }

  }
}