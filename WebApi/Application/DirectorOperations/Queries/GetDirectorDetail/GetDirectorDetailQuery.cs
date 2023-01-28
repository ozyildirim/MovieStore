using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.DirectorOperations.Queries;

public class GetDirectorDetailQuery
{
    public int Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDirectorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public DirectorDetailViewModel Handle()
    {
        var actor = _dbContext.Directors
            .Include(x => x.Movies)
            // .ThenInclude(x => x.Actors)
            .SingleOrDefault(x => x.DirectorId == Id);

        if (actor is null)
        {
            throw new InvalidOperationException("Director not found!");
        }

        DirectorDetailViewModel vm = _mapper.Map<DirectorDetailViewModel>(actor);
        return vm;
    }
}

public class DirectorDetailViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public ICollection<Movie>? Movies { get; set; }
}
