namespace WebApi.Models.Entities;

public class Order
{
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public int MovieId { get; set; }
    public double Price { get; set; }
    public DateTime OrderDate { get; set; }
    public bool isActive { get; set; } = true;
}
