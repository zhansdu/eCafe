using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using newProjectJs.Data;
using newProjectJs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/manager")]
public class ManagerController : Controller
{
    private readonly CafeContext db;
    public ManagerController(CafeContext db)
    {
        this.db = db;
    }
    //get by manager id
    [HttpGet("restaurants/{id}")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurants(string id)
    {
        var restaurants = await db.Restaurants.Where((r)=>r.ManagerId==int.Parse(id)).ToListAsync();
        return Ok(restaurants);
    }
    [HttpPut("restaurant")]
    public async Task<ActionResult> EditRestaurant([FromBody]Restaurant restaurant)
    {
        db.Update(restaurant);

        await db.SaveChangesAsync();

        return Ok();
    }
    [HttpDelete("restaurant/{id}")]
    public async Task<ActionResult> DeleteRestaurant(string id)
    {
        var entity = await db.Restaurants.FindAsync(Int32.Parse(id));
        db.Restaurants.Remove(entity);
        await db.SaveChangesAsync();
        return Ok();
    }
    //get by restaurant id
    [HttpGet("food/{id}")]
    public async Task<ActionResult<List<Food>>> GetFood(string id)
    {
        var food = await db.Food.Where((f)=>f.RestaurantId==int.Parse(id)).ToListAsync();
        return Ok(food);
    }
    [HttpPost("food")]
    public async Task AddFood([FromBody]Food food)
    {
        Console.WriteLine(food.Name);
        await db.Food.AddAsync(food);
        await db.SaveChangesAsync();
    }
    [HttpPut("food")]
    public async Task<ActionResult> EditFood([FromBody] Food food)
    {
        db.Update(food);
        await db.SaveChangesAsync();

        return Ok();
    }
    [HttpDelete("food/{id}")]
    public async Task<ActionResult> DeleteFood(string id)
    {
        var entity = await db.Food.FindAsync(Int32.Parse(id));
        db.Food.Remove(entity);
        await db.SaveChangesAsync();
        return Ok();
    }
    //get by restaurant id
    [HttpGet("tables/{id}")]
    public async Task<ActionResult<List<Table>>> GetTables(string id)
    {
        IEnumerable<Table> tables= await db.Tables.Where((table)=>table.RestaurantId==int.Parse(id)).ToListAsync();
        return Ok(tables);
    }
    [HttpPost("table")]
    public async Task AddTable([FromBody]Table table)
    {
        await db.Tables.AddAsync(table);
        await db.SaveChangesAsync();
    }
    [HttpPut("table")]
    public async Task<ActionResult> EditTable([FromBody] Table table)
    {
        db.Update(table);

        await db.SaveChangesAsync();

        return Ok();
    }
    [HttpDelete("table/{id}")]
    public async Task<ActionResult> DeleteTable(string id)
    {
        var entity = await db.Tables.FindAsync(Int32.Parse(id));
        db.Tables.Remove(entity);
        await db.SaveChangesAsync();
        return Ok();
    }
    //get orders by restaurant id
    [HttpGet("orders/{id}")]
    public async Task<ActionResult<List<Order>>> GetOrders(string id,[FromBody]DateTime time)
    {
        var orders = await db.Orders.Where((ord)=>(ord.RestaurantId==int.Parse(id))&&(ord.StartTime.Date==time.Date)).ToListAsync();
        return Ok(orders);
    }
}
