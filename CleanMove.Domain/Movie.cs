using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMove.Domain
{
    public class Movie
   {
        public int MovieId { get; set; }
        public string Movie_Name { get; set; } = string.Empty;
        public decimal Rantal_Cost { get; set; }
        public int Rantal_Duration { get; set; }

        //Many To Many Relationship
        public IList<MovieRantal> MovieRantals { get; set; } 
    }
}
