using System;
using System.Linq;
using System.Threading.Tasks;
using newProjectJs.Data;
using newProjectJs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
namespace newProjectJs.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly CafeContext db;
        public AuthController(CafeContext db)
        {
            this.db = db;
        }
        //get
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody]JObject auth)
        {
            string password=auth["password"].ToString();
            string email=auth["email"].ToString();
            try{
                var client = await db.Clients.Where(x=>x.Email==email).FirstAsync();
                if (client.Password == password) return client;
                else{
                    return Ok("password is wrong");
                }
            }catch(Exception e){
                try{
                    var admin = await db.Admins.Where(x=>x.Email==email).FirstAsync();
                    if (admin.Password == password) return admin;
                    else{
                        return Ok("password is wrong");
                    }
                }catch(Exception f){
                    try{
                        var manager = await db.Managers.Where(x=>x.Email==email).FirstAsync();
                        if (manager.Password == password) return manager;
                        else{
                            return Ok("password is wrong");
                        }
                    }
                    catch(Exception g){
                        return NotFound();
                    }
                }
            }
        }
        [HttpPost("register")]
        public async Task Register([FromBody]Client user){
            await db.Clients.AddAsync(user);
            await db.SaveChangesAsync();
        }
    }
}
