using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.DbOperations;

public class MovieStoreDbContext : DbContext
{
    public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ActorMovie> ActorMovies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API
        modelBuilder.Entity<ActorMovie>().HasKey(am => new { am.ActorId, am.MovieId });

        // modelBuilder
        //     .Entity<Movie>()
        //     .HasOne<Director>(s => s.Director)
        //     .WithMany(d => d.Movies)
        //     .HasForeignKey(s => s.DirectorId);
    }
}
