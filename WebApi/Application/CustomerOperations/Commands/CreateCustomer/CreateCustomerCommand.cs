using AutoMapper;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.CustomerOperations.Commands;

public class CreateCustomerCommand
{
    public CreateCustomerModel Model { get; set; }
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateCustomerCommand(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(
            x => x.Name == Model.Name && x.Surname == Model.Surname
        );

        if (customer is not null)
        {
            throw new InvalidOperationException("Customer already exists!");
        }

        customer = _mapper.Map<Customer>(Model);
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
    }
}

public class CreateCustomerModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
