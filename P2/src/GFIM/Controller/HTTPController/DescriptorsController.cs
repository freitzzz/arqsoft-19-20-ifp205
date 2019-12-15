using System;
using System.Collections.Generic;
using GFAB.Model;
using GFAB.View;
using Microsoft.AspNetCore.Mvc;

namespace GFAB.Controllers
{

  /// <summary>
  /// Controls endpoints for descriptors collection functionalities
  /// </summary>
  [Route("api/descriptors")]
  [ApiController]
  public class DescriptorsController : ControllerBase
  {

    [HttpGet]
    public IActionResult AvailableDescriptors()
    {
      try
      {
        Dictionary<string,List<string>> descriptors = ExistingDescriptorsService.ExistingDescriptors;

        if (descriptors.Count == 0)
        {
          return NotFound(null);
        }

        GetAvailableDescriptorsModelView modelview = new GetAvailableDescriptorsModelView(descriptors);

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