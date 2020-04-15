using System.Threading.Tasks;
using newProjectJs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/food")]
public class FoodController : Controller
    {
        private readonly CafeContext _db;
        public FoodController(CafeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetFood()
        {
           
            return Ok(await _db.Food.ToListAsync());
        }
    }
