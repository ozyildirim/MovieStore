using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Commands;

public class DeleteMovieCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int Id { get; set; }

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

        movie.isActive = false;
        _dbContext.SaveChanges();
    }
}
