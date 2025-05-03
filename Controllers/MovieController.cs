using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300106.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie("The Shawshank Redemption", "Frank Darabont", new List<String>{"Tim Robbins", "Morgan Freeman", "Bob Gunton" }, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." ),
            new Movie("The Godfather", "Francis Ford Coppola", new List<String>{"Marlon Brando", "Al Pacino", "James Caan" }, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." ),
            new Movie("The Dark Knight", "Christopher Nolan", new List<String>{"Christian Bale", "Heath Ledger", "Aaron Eckhart"}, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness." ),
        };

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return movies;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            if (id < 0 || id >= movies.Count){
                return NotFound();
            }
            return movies[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            movies.Add(movie);
            return CreatedAtAction(nameof(Get), new { id = movies.Count - 1 }, movie);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(id < 0 || id >= movies.Count)
            {
                return NotFound();
            }
            movies.RemoveAt(id);
            return NoContent();
        }
    }
}
