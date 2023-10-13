using CleanMove.Application;
using CleanMove.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMove.Infrustructure
{
    public class MoveRepository : IMoveRepository
    {

        public static List<Movie> movies = new List<Movie>()
        {
            //new Movie { Id = 1, Name = "Pirates Of Carribian" , Cost =  100 },
            //new Movie { Id = 2, Name = "Home Alone" , Cost =  200 }
        };

        private readonly MoveDbContext  _movieDbContext;
        public MoveRepository(MoveDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Movie CreateMove(Movie movie)
        {
            _movieDbContext.Movies.Add(movie);
            _movieDbContext.SaveChanges();
            return movie;
        }

        public List<Movie> GetAllMovies()
        {   
           return _movieDbContext.Movies.ToList(); ;
        }
    }
}
