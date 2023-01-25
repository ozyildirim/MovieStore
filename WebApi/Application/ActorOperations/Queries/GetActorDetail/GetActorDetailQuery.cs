using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.ActorOperations.Queries;

public class GetActorDetailQuery
{
    public int Id { get; set; }
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorDetailQuery(MovieStoreDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public ActorDetailViewModel Handle()
    {
        var actor = _dbContext.Actors
            .Include(x => x.ActorMovies)
            .SingleOrDefault(x => x.ActorId == Id);

        if (actor is null)
        {
            throw new InvalidOperationException("Actor not found!");
        }

        ActorDetailViewModel vm = _mapper.Map<ActorDetailViewModel>(actor);
        return vm;
    }
}

public class ActorDetailViewModel
{
    public int ActorId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public ICollection<Movie>? Movies { get; set; }
}
