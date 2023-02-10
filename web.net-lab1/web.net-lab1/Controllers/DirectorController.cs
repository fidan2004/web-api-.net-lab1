using Microsoft.AspNetCore.Mvc;

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using web.net_lab1.Models;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class DirectorController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            if (Database.Directors.Count > 0)
                return Ok(Database.Directors.OrderByDescending(m => m.Id));
            return NotFound("Not found");
        }
        [HttpPost]
        public IActionResult Create(string name, string surname, int age)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                Director director = new(name, surname, age);
                Database.Directors.Add(director);
                return Ok(director);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPut]
        public IActionResult Update(int id, string? name, string? surname, int age)
        {
            Director? director = Database.Directors.FirstOrDefault(d => d.Id == id);

            if (director != null)
            {
                Database.Directors.Remove(director);

                if (!string.IsNullOrEmpty(name))
                {
                    director.Name = name;
                }
                if (!string.IsNullOrEmpty(surname))
                {
                    director.Surname = surname;

                }
                if (age > 0)
                {
                    director.Age = age;
                }

                Database.Directors.Add(director);

                return Ok("Successfuly updated!!!");
            }

            return NotFound("Not found");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Director? director = Database.Directors.FirstOrDefault(d => d.Id == id);

            if (director != null)
            {
                Database.Directors.Remove(director);

                return Ok("Successfuly deleted!!!");
            }

            return NotFound("Not found");
        }
    }
}