using System.Collections.Generic;

namespace WebApi.Models.Entities;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime Year { get; set; }
    public virtual Director Director { get; set; }
    public virtual ICollection<Actor> Actors { get; set; }
    public virtual ICollection<Customer> PurchasedCustomers { get; set; }
    public bool isActive { get; set; } = true; 
}
