using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using newProjectJs.Data;
using newProjectJs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/admin")]
public class AdminController : Controller
{
    private readonly CafeContext db;
    public AdminController(CafeContext db)
    {
        this.db = db;
    }
    //get
    [HttpGet("managers")]
    public async Task<ActionResult<List<Manager>>> Get()
    {
        return Ok(await db.Managers.ToListAsync());
    }
    //Create manager POST
    [HttpPost("manager")]
    public async Task<ActionResult> Post([FromBody]Manager manager)
    {
        await db.Managers.AddAsync(manager);
        await db.SaveChangesAsync();
        return Ok();
    }
    //delete manager
    [HttpDelete("manager/{id}")]
    public async Task<ActionResult> DeleteManager(string id)
    {
        var manager = await db.Managers.FindAsync(int.Parse(id));
        var restaurants = await db.Restaurants.Where((restaurant) => restaurant.ManagerId == manager.ManagerId).ToListAsync();
        db.Managers.Remove(manager);
        restaurants.ForEach((obj) => db.Restaurants.Remove(obj));
        await db.SaveChangesAsync();
        return Ok();
    }
    //get restaurants
    [HttpGet("restaurants")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
    {
        List<Restaurant> restaurants = await db.Restaurants.ToListAsync();
        restaurants.ForEach((obj) => { obj.Manager = db.Managers.Find(obj.ManagerId);obj.City = db.Cities.Find(obj.CityId); });
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
    [HttpGet("cities")]
    public async Task<ActionResult<List<City>>> GetCities()
    {
        return Ok(await db.Cities.ToListAsync());
    }
}
