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

    public class ItemsController : ControllerBase
    {
        private RepositoryFactory factory;

        //TODO: @PedroCoelho Finish Implementing

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

            try {
                Meal meal = this.factory.MealRepository().Find(itemToAdd.mealId);

                try {
                    Location location = Location.ValueOf(itemToAdd.location);
                    DateTime expirationDate = DateTime.Parse(itemToAdd.expirationDate);
                    DateTime productionDate = DateTime.Parse(itemToAdd.productionDate);
                    if(expirationDate > productionDate) {
                        Item item = new Item(meal.Id(), location, productionDate, expirationDate);

                        RegisterItemModelView response = new RegisterItemModelView(Convert.ToInt32(item.ID),
                            Convert.ToInt32(meal.ID), item.id.Id, 
                            item.location.Name,
                            item.livenessPeriod.EndDateTime.ToShortDateString(), 
                            item.productionDate.ToShortDateString(), item.expirationDate.ToShortDateString());

                        return StatusCode(201,response);
                    }
                    else {
                        return BadRequest(new ErrorModelView("production date it cannot be after the expiration date"));
                    }
                }
                catch(ArgumentException exception) {
                    return BadRequest(new ErrorModelView(exception.Message));
                }

            }
            catch(ArgumentException e) {
                return BadRequest(new ErrorModelView(e.Message));
            }
        }

        //TODO: @PedroCoelho finish Implementing
        //Delete : /items:id
        [HttpDelete]
        public async Task<IActionResult> RemoveItem(int itemId)
        {

            return NotFound(new ErrorModelView("request not implemented"));
        }
    }
}