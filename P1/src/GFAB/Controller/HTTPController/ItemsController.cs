using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GFAB.View.Item;
using GFAB.View;

namespace GFAB.Controllers {

    [Route("api/items")]
    [ApiController]

    public class ItemsController: ControllerBase {

        //TODO: @PedroCoelho Finish Implementing

        //POST: /items
        [HttpPost]
        public async Task<IActionResult> RegisterItem(AddItemModelView itemToAdd) {

            return NotFound(new ErrorModelView("request not implemented"));
        }

        //TODO: @PedroCoelho finish Implementing
        //Delete : /items:id
        [HttpDelete]
        public async Task<IActionResult> RemoveItem(int itemId) {
            
            return NotFound(new ErrorModelView("request not implemented"));
        }
    }
}