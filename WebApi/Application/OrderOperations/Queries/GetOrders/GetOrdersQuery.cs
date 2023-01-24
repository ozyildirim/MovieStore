using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.OrderOperations.Queries;

public class GetOrdersQuery
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOrdersQuery(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<OrderViewModel> Handle()
    {
        var orders = _dbContext.Orders.OrderBy(x => x.Id).ToList<Order>();
        List<OrderViewModel> list = _mapper.Map<List<OrderViewModel>>(orders);
        return list;
    }
}

public class OrderViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime Year { get; set; }
    public Director Director { get; set; }
    public ICollection<Actor> Actors { get; set; }
}
