using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.OrderOperations.Commands;

public class UpdateOrderCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public UpdateOrderrModel Model { get; set; }
    public int? Id { get; set; }

    public UpdateOrderCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var order = _dbContext.Orders.SingleOrDefault(x => x.Id == Id);

        if (order is null)
            throw new InvalidOperationException("Order not found!");

        order.Price = Model.Price != default ? Model.Price : order.Price;
        order.CustomerId = Model.CustomerId != default ? Model.CustomerId : order.CustomerId;
        order.MovieId = Model.MovieId != default ? Model.MovieId : order.MovieId;

        _dbContext.SaveChanges();
    }
}

public class UpdateOrderrModel
{
    public double? Price { get; set; }
    public DateTime? OrderDate { get; set; }
    public bool isActive { get; set; } = true;

    public int? CustomerId { get; set; }
    public int? MovieId { get; set; }
}
