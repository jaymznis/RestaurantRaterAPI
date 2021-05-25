using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        [HttpPost]
        //Create(Post)
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

        //GetAll
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }
        //GetById
       [HttpGet]
       public async Task<IHttpActionResult> GetById(int id)
        {                                                       //same as using a foreach to find by id
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if(restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound();
        }

        //Update(Put)

        //Delete
    }

}
