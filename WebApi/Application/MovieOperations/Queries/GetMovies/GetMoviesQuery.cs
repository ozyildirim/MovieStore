using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.DirectorOperations.Queries;
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
        var result = _dbContext.Movies
            .Include(movie => movie.Actors)
            .Include(movie => movie.Director)
            .OrderBy(x => x.Id)
            .Select(
                movie =>
                    new MovieViewModel
                    {
                        Director = new Director
                        {
                            Id = movie.Director.Id,
                            Name = movie.Director.Name,
                            Surname = movie.Director.Surname,
                            isActive = movie.Director.isActive
                        },
                        Id = movie.Id,
                        Actors = movie.Actors,
                        Title = movie.Title,
                        Year = movie.Year
                    }
            )
            .ToList();
        List<MovieViewModel> list = _mapper.Map<List<MovieViewModel>>(result);
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
