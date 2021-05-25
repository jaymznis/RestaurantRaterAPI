using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        private RestaurantDbContext _context = new RestaurantDbContext();

        public async Task<IHttpActionResult> PostReastaurant(Restaurant model)
        {
            if (model == null)
            {
                return BadRequest("your request boday cannot be empty");
            }
            //checks if every proprerty that is required is included from Restaurant class (model)
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
