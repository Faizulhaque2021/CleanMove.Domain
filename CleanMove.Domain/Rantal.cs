namespace CleanMove.Domain
{
    public class Rantal
    {
        public int RantalId { get; set; }
        public DateTime RantalDate { get; set; } = DateTime.Now;
        public DateTime RantalExpiry {get; set;}
        public decimal TotalCost { get; set;}

        // One to Many Relationship

        public ICollection<Member> Members { get; set; }

        //Many To Many Relationship
        public IList<MovieRantal> MovieRantals { get; set; }  // Generated Type
    }
}