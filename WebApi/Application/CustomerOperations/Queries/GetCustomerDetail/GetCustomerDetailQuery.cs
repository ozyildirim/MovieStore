using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.CustomerOperations.Queries;

public class GetCustomerDetailQuery
{
    public int? Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCustomerDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public CustomerDetailViewModel Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(x => x.CustomerId == Id);

        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found!");
        }

        CustomerDetailViewModel vm = _mapper.Map<CustomerDetailViewModel>(customer);
        return vm;
    }
}

public class CustomerDetailViewModel
{
    public int CustomerId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
