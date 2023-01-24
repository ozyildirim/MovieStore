using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands;
using WebApi.Application.DirectorOperations.Commands;
using WebApi.Application.MovieOperations.Commands;
using WebApi.Application.MovieOperations.Queries;
using WebApi.Application.OrderOperations.Commands;
using WebApi.Application.OrderOperations.Queries;
using WebApi.DbOperations;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class OrderController : ControllerBase
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly ILogger<OrderController> _logger;
    private readonly IMapper _mapper;

    public OrderController(
        MovieStoreDbContext dbContext,
        ILogger<OrderController> logger,
        IMapper mapper
    )
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        GetOrdersQuery query = new GetOrdersQuery(_dbContext, _mapper);
        var result = query.Handle();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderDetail(int id)
    {
        GetOrderDetailQuery query = new GetOrderDetailQuery(_dbContext, _mapper);
        query.Id = id;
        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddOrder([FromBody] CreateOrderModel newOrder)
    {
        CreateOrderCommand command = new CreateOrderCommand(_dbContext, _mapper);
        command.Model = newOrder;

        CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        DeleteOrderCommand command = new DeleteOrderCommand(_dbContext, _mapper);
        command.Id = id;

        DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder([FromBody] UpdateOrderrModel updatedOrder, int id)
    {
        UpdateOrderCommand command = new UpdateOrderCommand(_dbContext, _mapper);
        command.Id = id;
        command.Model = updatedOrder;

        command.Handle();
        return Ok();
    }
}
