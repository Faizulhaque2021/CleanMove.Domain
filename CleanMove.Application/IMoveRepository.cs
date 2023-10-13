using CleanMove.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMove.Application
{
    public interface IMoveRepository
    {
        List<Movie> GetAllMovies();
        Movie CreateMove(Movie move);
    }
}
