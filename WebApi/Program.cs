using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IMovieStoreDbContext>(
    provider => provider.GetService<MovieStoreDbContext>()
);

builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
builder.Services.AddSingleton<ILoggerService, DbLogger>();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(
        opt =>
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json
                .ReferenceLoopHandling
                .Ignore
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<MovieStoreDbContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection"))
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomExceptionMiddleware();

app.MapControllers();

app.Run();
