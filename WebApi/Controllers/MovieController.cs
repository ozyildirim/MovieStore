using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperations.Queries;
using WebApi.DbOperations;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class MovieController : ControllerBase
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly ILogger<MovieController> _logger;
    private readonly IMapper _mapper;

    public MovieController(
        MovieStoreDbContext dbContext,
        ILogger<MovieController> logger,
        IMapper mapper
    )
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        GetMoviesQuery query = new GetMoviesQuery(_dbContext, _mapper);
        var result = query.Handle();

        return Ok(result);
    }

    // [HttpGet("{id}")]
    // public IActionResult GetDirectorDetail(int id)
    // {
    //     GetDirectorDetailQuery query = new GetDirectorDetailQuery(_dbContext, _mapper);
    //     query.Id = id;
    //     var result = query.Handle();

    //     return Ok(result);
    // }

    // [HttpPost]
    // public IActionResult AddDirector([FromBody] CreateDirectorModel newDirector)
    // {
    //     CreateDirectorCommand command = new CreateDirectorCommand(_dbContext, _mapper);
    //     command.Model = newDirector;

    //     CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
    //     validator.ValidateAndThrow(command);

    //     command.Handle();
    //     return Ok();
    // }

    // [HttpDelete("{id}")]
    // public IActionResult DeleteDirector(int id)
    // {
    //     DeleteDirectorCommand command = new DeleteDirectorCommand(_dbContext, _mapper);
    //     command.Id = id;

    //     DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
    //     validator.ValidateAndThrow(command);

    //     command.Handle();
    //     return Ok();
    // }

    // [HttpPut("{id}")]
    // public IActionResult UpdateDirector([FromBody] UpdateDirectorModel updatedDirector, int id)
    // {
    //     UpdateDirectorCommand command = new UpdateDirectorCommand(_dbContext, _mapper);
    //     command.Id = id;
    //     command.Model = updatedDirector;

    //     UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
    //     validator.ValidateAndThrow(command);

    //     command.Handle();
    //     return Ok();
    // }
}
