using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using web.net_lab1.Models;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class MovieController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        if (Database.Movies.Count > 0)
            return Ok(Database.Movies.OrderByDescending(m => m.CreationDate));
        return NotFound("Not found");
    }
    [HttpPost]
    public IActionResult Create(string name, string genre, int directorId)
    {
        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(genre) && directorId > 0)
        {
            Movie movie = new(name, genre, directorId);
            Database.Movies.Add(movie);
            return Ok(movie);
        }
        return BadRequest("Something went wrong!");
    }

    [HttpPut]
    public IActionResult Update(int id, string? name, string? genre, int directorId)
    {
        Movie? movie = Database.Movies.FirstOrDefault(d => d.Id == id);

        if (movie != null)
        {
            Database.Movies.Remove(movie);

            if (!string.IsNullOrEmpty(name))
            {
                movie.Name = name;
            }
            if (!string.IsNullOrEmpty(genre))
            {
                movie.Genre = genre;

            }
            if (directorId > 0)
            {
                movie.DirectorId = directorId;
            }

            Database.Movies.Add(movie);

            return Ok("Successfuly updated!!!");
        }

        return NotFound("Not found");
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        Movie? movie = Database.Movies.FirstOrDefault(d => d.Id == id);

        if (movie != null)
        {
            Database.Movies.Remove(movie);

            return Ok("Successfuly deleted!!!");
        }
        return NotFound("Not found");
    }
    [HttpGet]
    public IActionResult FilterByDirectorId(int directorId)
    {
        List<Movie> movies = Database.Movies.Where(d => d.DirectorId == directorId).ToList();

        if (movies.Count > 0)
        {
            return Ok(movies);
        }
        return NotFound("Not found");
    }
}