using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Commands;

public class UpdateMovieCommand
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public UpdateMovieModel Model { get; set; }
    public int Id { get; set; }

    public UpdateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieId == Id);

        if (movie is null)
            throw new InvalidOperationException("Actor not found!");
        // book = _mapper.Map<Book>(Model);


        movie.Title = Model.Title != default ? Model.Title : movie.Title;
        movie.Year = Model.Year != default ? Model.Year : movie.Year;
        movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;
        movie.Price = Model.Price != default ? Model.Price : movie.Price;
    
        _dbContext.SaveChanges();
    }
}

public class UpdateMovieModel
{
    public string? Title { get; set; }
    public DateTime Year { get; set; }
    public int DirectorId { get; set; }
    public double Price { get; set; }
}
