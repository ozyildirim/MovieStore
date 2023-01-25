using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations.Commands;
using WebApi.Application.CustomerOperations.Queries;
using WebApi.DbOperations;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class CustomerController : ControllerBase
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly ILogger<CustomerController> _logger;
    private readonly IMapper _mapper;

    public CustomerController(
        MovieStoreDbContext dbContext,
        ILogger<CustomerController> logger,
        IMapper mapper
    )
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        GetCustomersQuery query = new GetCustomersQuery(_dbContext, _mapper);
        var result = query.Handle();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomerDetail(int id)
    {
        GetCustomerDetailQuery query = new GetCustomerDetailQuery(_dbContext, _mapper);
        query.Id = id;
        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddCustomer([FromBody] CreateCustomerModel newCustomer)
    {
        CreateCustomerCommand command = new CreateCustomerCommand(_dbContext, _mapper);
        command.Model = newCustomer;

        CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        DeleteCustomerCommand command = new DeleteCustomerCommand(_dbContext, _mapper);
        command.Id = id;

        DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer([FromBody] UpdateCustomerModel updatedCustomer, int id)
    {
        UpdateCustomerCommand command = new UpdateCustomerCommand(_dbContext, _mapper);
        command.Id = id;
        command.Model = updatedCustomer;

        UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
}
