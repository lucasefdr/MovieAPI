using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Section>()
            .HasKey(section => new { section.MovieId, section.MovieTheaterId });

        builder.Entity<Section>()
            .HasOne(section => section.Movie)
            .WithMany(movie => movie.Sections)
            .HasForeignKey(section => section.MovieId);

        builder.Entity<Section>()
            .HasOne(section => section.MovieTheater)
            .WithMany(movieTheater => movieTheater.Sections)
            .HasForeignKey(section => section.MovieTheaterId);

        builder.Entity<Address>()
            .HasOne(address => address.MovieTheater)
            .WithOne(movieTheater => movieTheater.Address)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieTheater> MovieTheaters { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Section> Sections { get; set; }
}