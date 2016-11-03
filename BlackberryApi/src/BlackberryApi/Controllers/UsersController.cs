using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackberryApi.Models.UsersModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackberryApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public IUsersRepository Users { get; set; }

        public UsersController(IUsersRepository users)
        {
            Users = users;
        }

        [HttpGet]
        public IEnumerable<Users> GetAll()
        {
            return Users.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(int id)
        {
            var item = Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Users item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            Users.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Users userItem)
        {
            if (userItem == null || userItem.ID != id)
            {
                return BadRequest();
            }

            var user = Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            Users.Update(userItem);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            
            Users.Remove(id);
            return new NoContentResult();
        }
    }
}
