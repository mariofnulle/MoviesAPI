using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
                .HasOne(address => address.MovieTheather)
                .WithOne(movieTheater => movieTheater.Address)
                .HasForeignKey<MovieTheather>(movieTheater => movieTheater.AddressId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheather> MovieTheathers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
