using CleanMove.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMove.Application
{
    public class MoveService : IMoveService
    {
        private readonly IMoveRepository _moveRepository;

        //Constructor Dependency Injection
        public MoveService(IMoveRepository moveRepository)
        {
            _moveRepository = moveRepository;  
        }

        public Movie CreateMovie(Movie movie)
        {
            _moveRepository.CreateMove(movie);
            return movie;
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _moveRepository.GetAllMovies();
            return movies;
        }
    }
}
