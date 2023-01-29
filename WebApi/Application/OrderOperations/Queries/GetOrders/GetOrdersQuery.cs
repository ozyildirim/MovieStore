using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.OrderOperations.Queries;

public class GetOrdersQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOrdersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<OrderViewModel> Handle()
    {
        var orders = _dbContext.Orders
            .Where(x => x.isActive == true)
            .Include(x => x.Customer)
            .Include(x => x.Movie)
            .OrderBy(x => x.Id)
            .ToList<Order>();
        List<OrderViewModel> list = _mapper.Map<List<OrderViewModel>>(orders);
        return list;
    }
}

public class OrderViewModel
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int? MovieId { get; set; }
    public Movie? Movie { get; set; }
    public double? Price { get; set; }
    public DateTime? OrderDate { get; set; }
}
