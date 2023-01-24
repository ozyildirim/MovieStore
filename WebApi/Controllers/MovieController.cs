using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands;
using WebApi.Application.DirectorOperations.Commands;
using WebApi.Application.MovieOperations.Commands;
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

    [HttpGet("{id}")]
    public IActionResult GetMovieDetail(int id)
    {
        GetMovieDetailQuery query = new GetMovieDetailQuery(_dbContext, _mapper);
        query.Id = id;
        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
    {
        CreateMovieCommand command = new CreateMovieCommand(_dbContext, _mapper);
        command.Model = newMovie;

        CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        DeleteMovieCommand command = new DeleteMovieCommand(_dbContext, _mapper);
        command.Id = id;

        DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie([FromBody] UpdateMovieModel updatedMovie, int id)
    {
        UpdateMovieCommand command = new UpdateMovieCommand(_dbContext, _mapper);
        command.Id = id;
        command.Model = updatedMovie;

        UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
}
