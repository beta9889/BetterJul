using JulAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace JulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService) 
        {
            _movieService= movieService;
        }

        [HttpGet]
        public List<Movies> Get()
        {
            return _movieService.Get();
        }
    }
}
