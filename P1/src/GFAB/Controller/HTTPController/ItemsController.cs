using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GFAB.View.Item;
using GFAB.View;
using GFAB.Model;
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

                try
                {
                    Location location = Location.ValueOf(itemToAdd.location);
                    DateTime expirationDate = DateTime.Parse(itemToAdd.expirationDate);
                    DateTime productionDate = DateTime.Parse(itemToAdd.productionDate);
                    try
                    {
                        Item item = new Item(meal.Id(), location, productionDate, expirationDate);

                        try
                        {
                            this.factory.ItemRepository().Save(item);

                            RegisterItemModelView response = new RegisterItemModelView(Convert.ToInt32(item.ID),
                                Convert.ToInt32(meal.ID), item.id.Id,
                                item.location.Name,
                                item.livenessPeriod.EndDateTime.ToShortDateString(),
                                item.productionDate.ToShortDateString(), item.expirationDate.ToShortDateString());

                            return StatusCode(201, response);
                        }
                        catch (Exception databaseException)
                        { 
                            return StatusCode(500);
                        }
                    }
                    catch (ArgumentException periodException)
                    {

                        return BadRequest(new ErrorModelView(periodException.Message));
                    }
                }
                catch (ArgumentException exception)
                {
                    return BadRequest(new ErrorModelView(exception.Message));
                }

            }
            catch (ArgumentException e)
            {
                return BadRequest(new ErrorModelView(e.Message));
            }
        }
        
        //Delete : /items:id
        [HttpDelete("{id}")]
        public IActionResult RemoveItem( long itemId)
        {
            try {
                Item item = this.factory.ItemRepository().Find(itemId);

                this.factory.ItemRepository().Delete(item);

                return NoContent();
            }
            catch(Exception e) {

                if(e is ArgumentException)
                    return NotFound(new ErrorModelView(e.Message));

                return StatusCode(500);
            }
            
        }
    }
}