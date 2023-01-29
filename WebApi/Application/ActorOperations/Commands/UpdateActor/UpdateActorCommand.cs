using AutoMapper;

namespace WebApi.Application.ActorOperations.Commands;

public class UpdateActorCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public UpdateActorModel Model { get; set; }
    public int? Id { get; set; }

    public UpdateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(x => x.ActorId == Id);

        if (actor is null)
            throw new InvalidOperationException("Actor not found!");

        actor.Name = Model.Name;
        actor.Surname = Model.Surname;

        _dbContext.SaveChanges();
    }
}

public class UpdateActorModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
