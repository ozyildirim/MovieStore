using AutoMapper;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.OrderOperations.Commands;

public class CreateOrderCommand
{
    public CreateOrderModel Model { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateOrderCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var order = _dbContext.Orders.SingleOrDefault(
            x => x.CustomerId == Model.CustomerId && x.MovieId == Model.MovieId
        );

        if (order is not null)
        {
            throw new InvalidOperationException("Order already exists!");
        }

        order = _mapper.Map<Order>(Model);
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
    }
}

public class CreateOrderModel
{
    public double? Price { get; set; }
    public DateTime? OrderDate { get; set; }

    public int? CustomerId { get; set; }
    public int? MovieId { get; set; }
}
