using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.OrderOperations.Queries;

public class GetCustomerOrdersQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int CustomerId { get; set; }

    public GetCustomerOrdersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<OrderViewModel> Handle()
    {
        var orders = _dbContext.Orders
            .Where(x => x.CustomerId == CustomerId)
            .Include(x => x.Customer)
            .Include(x => x.Movie)
            .OrderBy(x => x.Id)
            .ToList<Order>();
        List<OrderViewModel> list = _mapper.Map<List<OrderViewModel>>(orders);
        return list;
    }
}
