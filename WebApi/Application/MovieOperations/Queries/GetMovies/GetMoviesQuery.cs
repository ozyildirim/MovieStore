using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.MovieOperations.Queries;

public class GetMoviesQuery
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetMoviesQuery(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<MovieViewModel> Handle()
    {
        var movies = _dbContext.Movies
            .Include(x => x.Director)
            .Include(x => x.ActorMovies)
            .ThenInclude(x => x.Actor)
            .AsNoTracking()
            .OrderBy(x => x.MovieId)
            .ToList<Movie>();
        List<MovieViewModel> list = _mapper.Map<List<MovieViewModel>>(movies);
        return list;
    }
}

public class MovieViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime Year { get; set; }
    public Director Director { get; set; }
    public ICollection<Actor> Actors { get; set; }
}
