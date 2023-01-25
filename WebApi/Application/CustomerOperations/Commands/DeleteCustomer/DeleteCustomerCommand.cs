using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands;

public class DeleteCustomerCommand
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int Id { get; set; }

    public DeleteCustomerCommand(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(x => x.CustomerId == Id);

        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found!");
        }

        customer.isActive = false;
        _dbContext.SaveChanges();
    }
}
