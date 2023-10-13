using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMove.Domain
{
    public class Member
    {
        public int MemberId { get; set; }
        public string First_Name { get; set; }= string.Empty;
        public string Last_Name { get; set;}= string.Empty;
        public string Email { get; set; } = string.Empty;

        // Linking One to Many

        public int RantalId { get; set; }
        public Rantal Rantal { get; set; } // Generated Type

}
}
