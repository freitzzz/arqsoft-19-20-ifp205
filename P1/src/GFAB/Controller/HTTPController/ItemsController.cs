using System;
using Microsoft.AspNetCore.Mvc;
using GFAB.View;
using GFAB.Model;
using System.Collections.Generic;

namespace GFAB.Controllers
{

  [Route("api/items")]
  [ApiController]

  public class ItemsController : ControllerBase //TODO: Create a technical logger to write in a .txt file locally on the server
  {
    private RepositoryFactory factory;

    public ItemsController(RepositoryFactory repositoryFactory)
    {
      factory = repositoryFactory;
    }


    [HttpGet]
    public IActionResult AvailableItems()
    {
      try
      {
        List<Item> items = factory.ItemRepository().All();

        if (items.Count == 0)
        {
          return NotFound(null);
        }

        GetAvailableItemsModelView modelview = new GetAvailableItemsModelView(items);

        return Ok(modelview);
      }
      catch (Exception databaseException)
      {
        // TODO: Log exception
        return StatusCode(500, null);
      }

    }

    //POST: /items
    [HttpPost]
    public IActionResult RegisterItem(AddItemModelView itemToAdd)
    {

      if (!ModelState.IsValid || itemToAdd == null)
      {
        return BadRequest(new ErrorModelView("information not accepted"));
      }

      try
      {

        Meal meal = this.factory.MealRepository().Find(itemToAdd.mealId);

        string location = itemToAdd.location;
        DateTime expirationDate = DateTime.Parse(itemToAdd.expirationDate);
        DateTime productionDate = DateTime.Parse(itemToAdd.productionDate);

        Item item = new Item(meal.Id(), location, productionDate, expirationDate);

        this.factory.ItemRepository().Save(item);

        RegisterItemModelView response = new RegisterItemModelView(item);

        return StatusCode(201, response);
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
      catch (FormatException dateFormatException)
      {
        // TODO: Log exception
        return BadRequest(new ErrorModelView(dateFormatException.Message));

      }
      catch (Exception databaseException)
      {
        // TODO: Log exception
        return StatusCode(500, null);

      }
    }

    //Delete : /items:id
    [HttpDelete("{id}")]
    public IActionResult RemoveItem(long id)
    {
      try
      {
        Item item = this.factory.ItemRepository().Find(id);

        this.factory.ItemRepository().Delete(item);

        return NoContent();
      }
      catch (Exception e)
      {

        if (e is ArgumentException)
          return NotFound(null);

        return StatusCode(500, null);
      }

    }
  }
}