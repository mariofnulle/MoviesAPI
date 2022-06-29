﻿using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheather> MovieTheathers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
