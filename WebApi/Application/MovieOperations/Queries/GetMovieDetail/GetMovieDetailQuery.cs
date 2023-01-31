using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.MovieOperations.Queries;

public class GetMovieDetailQuery
{
    public int? Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public MovieDetailViewModel Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieId == Id);

        if (movie is null)
        {
            throw new InvalidOperationException("Movie not found!");
        }

        MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);
        return vm;
    }
}

public class MovieDetailViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime? Year { get; set; }
    public Director? Director { get; set; }
    public ICollection<MovieActor>? Actors { get; set; }

    public struct MovieActor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
