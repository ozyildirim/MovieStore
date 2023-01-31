using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Application.ActorOperations.Queries;

public class GetActorsQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<ActorViewModel> Handle()
    {
        var result = _dbContext.Actors
            .Include(x => x.MovieActors)
            .ThenInclude(x => x.Movie)
            .OrderBy(x => x.ActorId)
            .ToList();
        List<ActorViewModel> list = _mapper.Map<List<ActorViewModel>>(result);
        return list;
    }
}

public class ActorViewModel
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
