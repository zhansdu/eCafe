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
    // get all restaurants
    [HttpGet("restaurants")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
    {
        List<Restaurant> restaurants = await db.Restaurants.ToListAsync();
        restaurants.ForEach((Restaurant restaurant) => { restaurant.City = db.Cities.Find(restaurant.CityId); });
        return Ok(restaurants);
    }
    //get by city restaurants
    [HttpGet("restaurants/{id}")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurantByCity(string id)
    {
        List<Restaurant> restaurants=await db.Restaurants.Where((arg)=>arg.CityId==int.Parse(id)).ToListAsync();
        restaurants.ForEach((Restaurant restaurant) => { restaurant.City = db.Cities.Find(restaurant.CityId); });
        return Ok(restaurants);
    }
    //get restaurant by id
    [HttpGet("restaurant/{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurantById(string id)
    {
        Restaurant restaurant = await db.Restaurants.FindAsync(int.Parse(id));
        restaurant.City=await db.Cities.FindAsync(restaurant.CityId);
        return Ok(restaurant);
    }
    //get food by city
    [HttpGet("food/city/{id}")]
    public async Task<ActionResult<List<Food>>> GetFoodByCity(string id)
    {
        List<Food> food = await db.Food.Where((arg) => arg.CityId == int.Parse(id)).ToListAsync();
        return Ok(food);
    }
    //food by restaurant id
    [HttpGet("food/restaurant/{id}")]
    public async Task<ActionResult<List<Food>>> GetFoodByRestaurant(string id)
    {
        List<Food> menu = await db.Food.Where((food) => food.RestaurantId == int.Parse(id)).ToListAsync();
        return Ok(menu);
    }
    //get available tables
    [HttpGet("tables/{id}")]
    public async Task<ActionResult<List<Table>>> GetTables(string id)
    {
        List<Table> tables= await db.Tables.Where((table)=>table.RestaurantId==int.Parse(id)).ToListAsync();
        return Ok(tables);
    }
    [HttpPost("orders/{id}")]
    public async Task<ActionResult<List<Order>>> GetOrders(string id,[FromBody]DateTime time)
    {
        Order any=await db.Orders.LastAsync();

        Console.WriteLine(any.StartTime.Date);
        Console.WriteLine(time.Date);
        Console.WriteLine(any.StartTime.Date==time.Date);
        List<Order> orders= await db.Orders.Where((order)=>(order.RestaurantId==int.Parse(id))&&(order.StartTime.Date.ToString("d")==time.Date.ToString("d"))).ToListAsync();
        return Ok(orders);
    }
    [HttpPost("order")]
    public async Task<ActionResult> AddOrder([FromBody]Order order)
    {
        await db.Orders.AddAsync(order);
        await db.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("cities")]
    public async Task<ActionResult<List<City>>> GetCities()
    {
        return Ok(await db.Cities.ToListAsync());
    }
}
