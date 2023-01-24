using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Commands;

public class DeleteDirectorCommand
{
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int Id { get; set; }

    public DeleteDirectorCommand(MovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.DirectorId == Id);

        if (director is null)
        {
            throw new InvalidOperationException("Director not found!");
        }

        _dbContext.Directors.Remove(director);
        _dbContext.SaveChanges();
    }
}
