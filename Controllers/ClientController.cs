using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using newProjectJs.Data;
using newProjectJs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/client")]
public class ClientController : Controller
{
    private readonly CafeContext db;
    public ClientController(CafeContext db)
    {
        this.db = db;
    }
    //get
    [HttpGet("restaurants")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurant()
    {
        return Ok(await db.Restaurants.ToListAsync());
    }
    [HttpGet("restaurant/{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurant(string id)
    {
        Restaurant restauarnts = await db.Restaurants.FindAsync(int.Parse(id));
        return Ok(restauarnts);
    }
    [HttpPost("food")]
    public async Task<ActionResult<List<Food>>> GetFood()
    {
        return Ok(await db.Food.ToListAsync());
    }
    //food by restaurant id
    [HttpDelete("food/{id}")]
    public async Task<ActionResult<List<Food>>> GetFoodByRestaurant(string id)
    {
        return Ok(await db.Food.Where((food) => food.RestaurantId == int.Parse(id)).ToListAsync());
    }
    //get available tables
    [HttpGet("restaurants")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
    {
        List<Restaurant> restaurants = await db.Restaurants.ToListAsync();
        async void action(Restaurant element)
        {
            element.Manager = await db.Managers.FindAsync(element.ManagerId);
        }
        restaurants.ForEach(action);
        return Ok(restaurants);
    }
    [HttpPost("restaurant")]
    public async Task AddRestaurant([FromBody]Restaurant restaurant)
    {
        await db.Restaurants.AddAsync(restaurant);
        await db.SaveChangesAsync();
    }
    [HttpDelete("restaurant/{id}")]
    public async Task<ActionResult> DeleteRestaurant(string id)
    {
        var entity = await db.Restaurants.FindAsync(Int32.Parse(id));
        db.Restaurants.Remove(entity);
        await db.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("clients")]
    public async Task<ActionResult<List<Client>>> GetClients()
    {
        return Ok(await db.Clients.ToListAsync());
    }
}
