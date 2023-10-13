using CleanMove.Application;
using CleanMove.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanMove.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private readonly IMoveService _service;
        public MoveController(IMoveService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            var moviesFromServices = _service.GetAllMovies();
            return Ok(moviesFromServices);
        }

        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie) 
        {
            var Movie = _service.CreateMovie(movie);
            return Ok(Movie);
        } 
    }
}
