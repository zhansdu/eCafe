using System;
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
    public async Task Post([FromBody]Manager manager)
    {
        await db.Managers.AddAsync(manager);
        await db.SaveChangesAsync();
    }
    //delete DELETE
    [HttpDelete("manager/{id}")]
    public async Task<ActionResult> DeleteManager(string id)
    {
        var entity = await db.Managers.FindAsync(Int32.Parse(id));
        db.Managers.Remove(entity);
        await db.SaveChangesAsync();
        return Ok();
    }
    //get restaurants
    [HttpGet("restaurants")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
    {
        List<Restaurant> restaurants = await db.Restaurants.ToListAsync();
        restaurants.ForEach(async (element) =>
        {
            element.Manager = await db.Managers.FindAsync(element.ManagerId);
        });
        return Ok(restaurants);
    }
    [HttpPost("restaurant")]
    public async Task AddRestaurant([FromBody]Restaurant restaurant)
    {
        await db.AddAsync(restaurant);
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
