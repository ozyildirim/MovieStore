using AutoMapper;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.CustomerOperations.CreateToken;

public class CreateTokenCommand
{
    public CreateTokenModel Model { get; set; }
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public CreateTokenCommand(IMovieStoreDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var customer = _context.Customers.FirstOrDefault(
            x => x.Email == Model.Email && x.Password == Model.Password
        );

        if (customer is not null)
        {
            // Create Token
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(customer);

            customer.RefreshToken = token.RefreshToken;
            customer.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(3);
            _context.SaveChanges();

            return token;
        }
        else
        {
            throw new InvalidOperationException("Email or Password is wrong!");
        }
    }
}

public class CreateTokenModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
