using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.DirectorOperations.Queries;

public class GetDirectorsQuery
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDirectorsQuery(MovieStoreDbContext dbContext, IMapper mapper)
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
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}
