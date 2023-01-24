using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Commands;

public class UpdateDirectorCommand
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public UpdateDirectorModel Model { get; set; }
    public int Id { get; set; }

    public UpdateDirectorCommand(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.DirectorId == Id);

        if (director is null)
            throw new InvalidOperationException("Director not found!");

        director.Name = Model.Name;
        director.Surname = Model.Surname;

        _dbContext.SaveChanges();
    }
}

public class UpdateDirectorModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
