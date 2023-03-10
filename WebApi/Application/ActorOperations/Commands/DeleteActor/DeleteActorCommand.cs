using AutoMapper;

namespace WebApi.Application.ActorOperations.Commands;

public class DeleteActorCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int Id { get; set; }

    public DeleteActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(x => x.ActorId == Id);

        if (actor is null)
        {
            throw new InvalidOperationException("Actor not found!");
        }

        var movieActors = _dbContext.MovieActors.Any(x => x.ActorId == Id);
        if (!movieActors)
        {
            throw new InvalidOperationException("Actor's movies must be deleted first!");
        }

        // _dbContext.Actors.Remove(actor);
        actor.IsActive = false;
        _dbContext.SaveChanges();
    }
}
