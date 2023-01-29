using AutoMapper;

namespace WebApi.Application.DirectorOperations.Commands;

public class DeleteDirectorCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int? Id { get; set; }

    public DeleteDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.DirectorId == Id);

        if (director is null)
        {
            throw new InvalidOperationException("Director not found!");
        }

        var movies = _dbContext.Movies.Where(movie => movie.DirectorId == director.DirectorId);
        if (movies is not null)
        {
            throw new InvalidOperationException(
                "The movies that director are related must be deleted first!"
            );
        }

        director.IsActive = false;
        _dbContext.SaveChanges();
    }
}
