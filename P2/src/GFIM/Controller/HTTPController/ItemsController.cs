using System;
using Microsoft.AspNetCore.Mvc;
using GFAB.View;
using GFAB.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using GFIM.View;
using System.Linq;

namespace GFAB.Controllers
{

  [Route("api/items")]
  [ApiController]

  public class ItemsController : ControllerBase //TODO: Create a technical logger to write in a .txt file locally on the server
  {
    private RepositoryFactory repositoryFactory;

    private IHttpClientFactory clientFactory;

    public ItemsController(RepositoryFactory repositoryFactory, IHttpClientFactory clientFactory)
    {
      this.repositoryFactory = repositoryFactory;
      this.clientFactory = clientFactory;
    }


    [HttpGet]
    public async Task<IActionResult> AvailableItems([FromQuery] long mealId)
    {
      try
      {
        List<Item> items = null;

        if (mealId == 0)
        {
          items = repositoryFactory.ItemRepository().All();
        }
        else
        {

          var request = new HttpRequestMessage(HttpMethod.Get, $"meals/{mealId}");

          var client = clientFactory.CreateClient("gfmm");

          var clientResponse = await client.SendAsync(request);

          if (clientResponse.StatusCode == HttpStatusCode.NotFound)
          {

            return NotFound(null);

          }

          var responsePayload = await clientResponse.Content.ReadAsStreamAsync();;

          JsonSerializerOptions deserializationOptions = new JsonSerializerOptions();
          deserializationOptions.PropertyNameCaseInsensitive = true;

          GetDetailedMealInformationModelView meal = await JsonSerializer.DeserializeAsync<GetDetailedMealInformationModelView>(responsePayload, deserializationOptions);

          MealID mealIdVO = MealID.ValueOf(meal.Designation);

          items = repositoryFactory.ItemRepository().All().Where((item) => item.MealId.Equals(mealIdVO)).ToList();
        }

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
    public async Task<IActionResult> RegisterItem(AddItemModelView itemToAdd)
    {

      if (!ModelState.IsValid || itemToAdd == null)
      {
        return BadRequest(new ErrorModelView("information not accepted"));
      }

      try
      {

        var request = new HttpRequestMessage(HttpMethod.Get, $"meals/{itemToAdd.mealId}");

        var client = clientFactory.CreateClient("gfmm");

        var clientResponse = await client.SendAsync(request);

        if (clientResponse.StatusCode == HttpStatusCode.NotFound)
        {

          return BadRequest(new ErrorModelView($"no meal was found by the resource identifier '{itemToAdd.mealId}'"));

        }

        var responsePayload = await clientResponse.Content.ReadAsStreamAsync();

        JsonSerializerOptions deserializationOptions = new JsonSerializerOptions();
        deserializationOptions.PropertyNameCaseInsensitive = true;

        GetDetailedMealInformationModelView meal = await JsonSerializer.DeserializeAsync<GetDetailedMealInformationModelView>(responsePayload, deserializationOptions);

        DateTime expirationDate = DateTime.Parse(itemToAdd.expirationDate);
        DateTime productionDate = DateTime.Parse(itemToAdd.productionDate);

        Item item = new Item(MealID.ValueOf(meal.Designation), productionDate, expirationDate);

        this.repositoryFactory.ItemRepository().Save(item);

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


    [HttpDelete("{id}")]
    public IActionResult RemoveItem(long id)
    {
      try
      {
        Item item = this.repositoryFactory.ItemRepository().Find(id);

        bool marked = item.markAsServed();

        if (!marked)
        {
          return NotFound(null);
        }

        this.repositoryFactory.ItemRepository().Update(item);

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