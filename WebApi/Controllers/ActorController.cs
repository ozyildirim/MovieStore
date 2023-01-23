using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Queries;
using WebApi.DbOperations;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ActorController : ControllerBase
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly ILogger<ConsoleLogger> _logger;
    private readonly IMapper _mapper;

    public ActorController(
        MovieStoreDbContext dbContext,
        ILogger<ConsoleLogger> logger,
        IMapper mapper
    )
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetActors()
    {
        GetActorsQuery query = new GetActorsQuery(_dbContext, _mapper);
        var result = query.Handle();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetActorDetail(int id)
    {
        GetActorDetailQuery query = new GetActorDetailQuery(_dbContext, _mapper);
        query.Id = id;
        var result = query.Handle();

        return Ok(result);
    }
}
