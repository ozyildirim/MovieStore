using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Commands;

public class DeleteMovieCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int? Id { get; set; }

    public DeleteMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieId == Id);

        if (movie is null)
        {
            throw new InvalidOperationException("Movie not found!");
        }

        var movieActors = _dbContext.MovieActors.Any(x => x.MovieId == Id);

        if (!movieActors)
        {
            throw new InvalidOperationException("Actor must be removed from movie list first!");
        }

        movie.IsActive = false;
        _dbContext.SaveChanges();
    }
}
