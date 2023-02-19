using JulAPI.Controllers;
using JulAPI.Service;
using Moq;
using MySqlX.XDevAPI.Common;
using Shared;

namespace APITest
{
    [TestClass]
    public class MovieControllerTest
    {
        Mock<IMovieService>? service { get; set; }
        MoviesController? moviesController { get; set; }
        [TestInitialize]
        public void initalize()
        {
            service = new Mock<IMovieService>();
            service.Setup(p => p.Get()).Returns(_movieList);
            moviesController= new MoviesController(service.Object);
        }

        [TestMethod]
        public void Get_returnsListOfMovies()
        {
            var result = moviesController.Get();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Movies>));
            Assert.AreEqual(2, result.Count());

            for(int i = 0; i < result.Count();i++)
            {
                Assert.AreEqual(_movieList[i], result[i]);
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            service.VerifyAll();
            moviesController = null;
            service = null;
        }

        private readonly List<Movies> _movieList = 
        new() {
            new Movies
            {
                JayOrNay = "yay",
                PickedBy = "Beta",
                Imbd_rating = 8.8f,
                Name = "Test",
                Id = 1,
                GenreName= "Genre",
            },
            new Movies
            {
                JayOrNay = "Nay",
                PickedBy = "Micke",
                Imbd_rating = 7.7f,
                Name = "Name",
                Id = 2,
                GenreName= "NoGenre",
            },
        };
        
    }
}