using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.MovieOperations.Queries;

public class GetMoviesQuery
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<MovieViewModel> Handle()
    {
        var movies = _dbContext.Movies
            .Include(m => m.Director)
            .Include(m => m.MovieActors)
            .ThenInclude(ma => ma.Actor)
            .OrderBy(x => x.MovieId);
        List<MovieViewModel> list = _mapper.Map<List<MovieViewModel>>(movies);
        return list;
    }
}

public class MovieViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime? Year { get; set; }
    public string? Director { get; set; }
    public ICollection<MovieActorVM>? Actors { get; set; }

    public struct MovieActorVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
