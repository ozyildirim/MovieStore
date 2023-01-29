using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }
    public double? Price { get; set; }
    public DateTime? OrderDate { get; set; }
    public bool isActive { get; set; } = true;

    public Customer? Customer { get; set; }
    public Movie? Movie { get; set; }
    public int? CustomerId { get; set; }
    public int? MovieId { get; set; }
}
