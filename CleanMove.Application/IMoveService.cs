using CleanMove.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMove.Application
{
    // This is a use case
    public interface IMoveService
    {
        List<Movie> GetAllMovies();
        Movie CreateMovie(Movie movie);
    }
}
