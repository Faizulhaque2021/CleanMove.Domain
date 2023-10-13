using CleanMove.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMove.Infrustructure
{
    public class MoveDbContext:DbContext
    {
        public MoveDbContext(DbContextOptions<MoveDbContext> options):base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many (Member and Rentals)
            modelBuilder.Entity<Member>()
           .HasOne<Rantal>(s => s.Rantal)
           .WithMany(r => r.Members)
           .HasForeignKey(s => s.RantalId);

            // Many to Many (Rantal and Movie)
            modelBuilder.Entity<MovieRantal>()
            .HasKey(g => new { g.RentalId, g.MovieId});

            // Hamdle Decimals to avoid precision loss

            modelBuilder.Entity<Rantal>()
            .Property(p => p.TotalCost)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Movie>()
            .Property(p => p.Rantal_Cost)
            .HasColumnType("decimal(18,2)");
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rantal> Rantals { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MovieRantal> MovieRantals { get; set; }
    }
}
