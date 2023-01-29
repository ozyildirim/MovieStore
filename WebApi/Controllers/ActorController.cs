using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands;
using WebApi.Application.ActorOperations.Queries;
using WebApi.DbOperations;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ActorController : ControllerBase
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly ILogger<ActorController> _logger;
    private readonly IMapper _mapper;

    public ActorController(
        IMovieStoreDbContext dbContext,
        ILogger<ActorController> logger,
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

    [HttpPost]
    public IActionResult AddActor([FromBody] CreateActorModel newActor)
    {
        CreateActorCommand command = new CreateActorCommand(_dbContext, _mapper);
        command.Model = newActor;

        CreateActorCommandValidator validator = new CreateActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        _logger.LogInformation($"Actor {newActor.Name} created successfully!");
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteActor(int id)
    {
        DeleteActorCommand command = new DeleteActorCommand(_dbContext, _mapper);
        command.Id = id;

        DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        _logger.LogInformation($"Actor with ID {id} deleted successfully!");

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateActor([FromBody] UpdateActorModel updatedActor, int id)
    {
        UpdateActorCommand command = new UpdateActorCommand(_dbContext, _mapper);
        command.Id = id;
        command.Model = updatedActor;

        UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        _logger.LogInformation($"Actor with ID {id} updated successfully!");

        return Ok();
    }
}
