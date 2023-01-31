using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models.Entities;

namespace WebApi.DbOperations;

public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
{
    public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent APIhttps://github.com/ozyildirim
        modelBuilder.Entity<MovieActor>(ConfigureMovieActor);

        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureMovieActor(EntityTypeBuilder<MovieActor> modelBuilder)
    {
        modelBuilder.HasKey(mc => new { mc.MovieId, mc.ActorId });
        modelBuilder
            .HasOne(mc => mc.Movie)
            .WithMany(g => g.MovieActors)
            .HasForeignKey(mg => mg.MovieId);
        modelBuilder
            .HasOne(mc => mc.Actor)
            .WithMany(g => g.MovieActors)
            .HasForeignKey(mg => mg.ActorId);
    }

    public override int SaveChanges() => base.SaveChanges();
}
