using JulAPI.Service;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest
{
    [TestClass]
    public class MovieServiceTest : MockDatabase
    {
        MoviesService? target;
        [TestInitialize]
        public void initilize() 
        {
            SetupVariables();
            SetupDatabase();
            target = new MoviesService(_helperConnection); 
        }

        [TestCleanup]
        public void cleanup()
        {
            RemoveDatabase();
            target = null;
        }

        [TestMethod]
        public void Get_GetAllFromDatabase()
        {
            var result = target.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            for(int i = 0; i< _Movies.Count; i++)
            {
                Assert.AreEqual(_Movies[i], result[i]);
            }
        }

        private List<Movies> _Movies = new()
        {
            new Movies()
            {
                Name = "Beauty and the beast (live-action)",
                GenreName = "Romance",
                Imbd_rating= 7.1f,
                JayOrNay = "jay",
                PickedBy = "Gabbe",
                Id = 0,
                IsMajor = "1"
            },
            new Movies()
            {
                Name = "Catch me if you can",
                GenreName = "Biography",
                Imbd_rating = 8.1f,
                JayOrNay="Jay",
                PickedBy = "Gabbe",
                IsMajor = "1",
                Id = 1
            },
            new Movies()
            {
                Name="1917",
                GenreName = "War",
                Imbd_rating = 8.2f,
                JayOrNay = "Jay",
                PickedBy = "Micke",
                Id = 2,
                IsMajor = "0"
            }
        };
    }
}
