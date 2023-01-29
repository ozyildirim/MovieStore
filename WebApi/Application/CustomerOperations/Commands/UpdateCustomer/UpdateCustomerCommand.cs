using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands;

public class UpdateCustomerCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public UpdateCustomerModel Model { get; set; }
    public int? Id { get; set; }

    public UpdateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(x => x.CustomerId == Id);

        if (customer is null)
            throw new InvalidOperationException("Customer not found!");

        customer.Name = Model.Name;
        customer.Surname = Model.Surname;

        _dbContext.SaveChanges();
    }
}

public class UpdateCustomerModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
