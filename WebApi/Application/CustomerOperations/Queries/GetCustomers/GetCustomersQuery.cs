using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Queries;

public class GetCustomersQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCustomersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<CustomerViewModel> Handle()
    {
        var result = _dbContext.Customers.OrderBy(x => x.CustomerId).ToList();
        List<CustomerViewModel> list = _mapper.Map<List<CustomerViewModel>>(result);
        return list;
    }
}

public class CustomerViewModel
{
    public int CustomerId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
