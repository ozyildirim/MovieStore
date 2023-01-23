using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.ActorOperations.Queries;

public class GetActorsQuery
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorsQuery(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<ActorViewModel> Handle()
    {
        var result = _dbContext.Actors.Include(x => x.Movies).OrderBy(x => x.ActorId).ToList();
        List<ActorViewModel> list = _mapper.Map<List<ActorViewModel>>(result);
        return list;
    }
}

public class ActorViewModel
{
    public int ActorId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}
