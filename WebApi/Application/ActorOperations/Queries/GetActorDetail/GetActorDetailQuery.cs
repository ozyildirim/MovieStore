using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Application.ActorOperations.Queries;

public class GetActorDetailQuery
{
    public int? Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public ActorDetailViewModel Handle()
    {
        var actor = _dbContext.Actors
            .Include(x => x.MovieActors)
            .ThenInclude(y => y.Movie)
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
    public ICollection<ActorMoviesVM>? Movies { get; set; }

    public struct ActorMoviesVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
