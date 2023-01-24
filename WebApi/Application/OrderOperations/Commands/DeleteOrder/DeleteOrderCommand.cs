using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.OrderOperations.Commands;

public class DeleteOrderCommand
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int Id { get; set; }

    public DeleteOrderCommand(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var order = _dbContext.Orders.SingleOrDefault(x => x.Id == Id);

        if (order is null)
        {
            throw new InvalidOperationException("Order not found!");
        }

        _dbContext.Orders.Remove(order);
        _dbContext.SaveChanges();
    }
}
