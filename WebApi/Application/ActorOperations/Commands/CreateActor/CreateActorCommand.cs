using AutoMapper;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.ActorOperations.Commands;

public class CreateActorCommand
{
    public CreateActorModel Model { get; set; }
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateActorCommand(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(
            x => x.Name == Model.Name && x.Surname == Model.Surname
        );

        if (actor is not null)
        {
            throw new InvalidOperationException("Actor already exists!");
        }

        actor = _mapper.Map<Actor>(Model);
        _dbContext.Actors.Add(actor);
        _dbContext.SaveChanges();
    }
}

public class CreateActorModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
