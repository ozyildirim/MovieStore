using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Application.DirectorOperations.Queries;

public class GetDirectorsQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<DirectorViewModel> Handle()
    {
        var result = _dbContext.Directors
            .Include(x => x.Movies)
            .OrderBy(x => x.DirectorId)
            .ToList();
        List<DirectorViewModel> list = _mapper.Map<List<DirectorViewModel>>(result);
        return list;
    }
}

public class DirectorViewModel
{
    public int DirectorId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public virtual ICollection<Movie>? Movies { get; set; }
}
