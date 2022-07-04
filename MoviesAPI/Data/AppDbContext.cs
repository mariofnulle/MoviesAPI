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

            builder.Entity<MovieTheather>()
                .HasOne(movieTheather => movieTheather.Manager)
                .WithMany(manager => manager.MovieTheathers)
                .HasForeignKey(movieTheather => movieTheather.ManagerId);

            builder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId);

            builder.Entity<Session>()
                .HasOne(session => session.Theather)
                .WithMany(theather => theather.Sessions)
                .HasForeignKey(session => session.TheatherId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheather> MovieTheathers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
