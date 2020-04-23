// using System.Threading.Tasks;
// using System.Collections.Generic;
// using newProjectJs.Data;
// using newProjectJs.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// [Route("api/food")]
// public class FoodController : Controller
// {
//     private readonly CafeContext _db;
//     public FoodController(CafeContext db)
//     {
//         _db = db;
//     }
//     [HttpGet]
//     public async Task<ActionResult<List<Food>>> Get()
//     {
//         return Ok(await _db.Food.ToListAsync());
//     }
//     [HttpGet("{id}")]
//     public async Task<ActionResult<Food>> Get(string id)
//     {
//         return await _db.Food.FindAsync(id);
//     }
//     [HttpPost]
//     public async Task Post(Food food)
//     {
//         await _db.AddAsync(food);
//         await _db.SaveChangesAsync();
//     }
//     [HttpPut("id")]
//     public async Task<ActionResult> Put(int id,Food food)
//     {
//         var exists = await _db.Food.AnyAsync(f => f.Id == id);
//         if (!exists)
//         {
//             return NotFound();
//         }
//         _db.Food.Update(food);
//         await _db.SaveChangesAsync();
//         return Ok();
//     }
//     [HttpDelete("{id}")]
//     public async Task<ActionResult> Delete(int id)
//     {
//         var entity = await _db.Food.FindAsync(id);
//         _db.Food.Remove(entity);
//         await _db.SaveChangesAsync();
//         return Ok();
//     }
// }
