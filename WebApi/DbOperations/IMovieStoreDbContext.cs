using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

public interface IMovieStoreDbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }

    int SaveChanges();
}
