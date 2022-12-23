using crudapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace crudapi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class userController : ControllerBase
    {
        dbcontext db;
        public userController(dbcontext db)
        {
            this.db = db;
        }
        // GET: api/<userController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var list=await db.users.ToListAsync();
            return Ok(list);
        }

        // GET api/<userController>/5
        [HttpGet]
        
        public async Task<IActionResult> GetuserbyidAsync(int id)
        {
            var list = await db.users.FindAsync(id);
            return Ok(list);
        }

        // POST api/<userController>
        [HttpPost]
     
       public IActionResult Postuser([FromBody]user user)
        {
            if (!ModelState.IsValid)
            return BadRequest("Not a Valid Model");
            db.users.Add(user);
            db.SaveChanges();
            return Ok();
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> putasync(int id, user updateuser)
        {
            if (id != updateuser.Id)
            {
                return BadRequest();
            }

            db.Entry(updateuser).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<userController>/5
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var usertodelete=await db.users.FindAsync(id);
            if (usertodelete == null)
            {
                return NotFound();

            }
            db.users.Remove(usertodelete);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
