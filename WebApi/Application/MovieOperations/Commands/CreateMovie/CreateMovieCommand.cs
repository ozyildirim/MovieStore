using AutoMapper;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.MovieOperations.Commands;

public class CreateMovieCommand
{
    public CreateMovieModel Model { get; set; }
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateMovieCommand(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Title == Model.Title);

        if (movie is not null)
        {
            throw new InvalidOperationException("Actor already exists!");
        }

        movie = _mapper.Map<Movie>(movie);
        _dbContext.Movies.Add(movie);
        _dbContext.SaveChanges();
    }
}

public class CreateMovieModel
{
    public string Title { get; set; }
    public DateTime Year { get; set; }
    public int DirectorId { get; set; }
}
