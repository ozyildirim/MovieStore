using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.OrderOperations.Queries;

public class GetOrderDetailQuery
{
    public int? Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public OrderDetailViewModel Handle()
    {
        var order = _dbContext.Orders
            .Include(x => x.Customer)
            .Include(x => x.Movie)
            .SingleOrDefault(x => x.Id == Id);

        if (order is null)
        {
            throw new InvalidOperationException("Order not found!");
        }

        OrderDetailViewModel vm = _mapper.Map<OrderDetailViewModel>(order);
        return vm;
    }
}

public class OrderDetailViewModel
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int? MovieId { get; set; }
    public Movie? Movie { get; set; }
    public double? Price { get; set; }
    public DateTime? OrderDate { get; set; }
}
