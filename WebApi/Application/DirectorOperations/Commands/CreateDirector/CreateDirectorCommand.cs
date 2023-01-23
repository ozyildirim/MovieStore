using AutoMapper;
using WebApi.DbOperations;
using WebApi.Models.Entities;

namespace WebApi.Application.DirectorOperations.Commands;

public class CreateDirectorCommand
{
    public CreateDirectorModel Model { get; set; }
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateDirectorCommand(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(
            x => x.Name == Model.Name && x.Surname == Model.Surname
        );

        if (director is not null)
        {
            throw new InvalidOperationException("Actor already exists!");
        }

        director = _mapper.Map<Director>(Model);
        _dbContext.Directors.Add(director);
        _dbContext.SaveChanges();
    }
}

public class CreateDirectorModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
