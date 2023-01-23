using System.Collections.Generic;

namespace WebApi.Models.Entities;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime Year { get; set; }
    public Director Director { get; set; }
    public ICollection<Actor> Actors { get; set; }
    public ICollection<Customer> PurchasedCustomers { get; set; }
}
