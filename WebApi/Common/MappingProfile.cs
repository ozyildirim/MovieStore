using AutoMapper;
using WebApi.Application.ActorOperations.Commands;
using WebApi.Application.ActorOperations.Queries;
using WebApi.Application.DirectorOperations.Commands;
using WebApi.Application.DirectorOperations.Queries;
using WebApi.Application.MovieOperations.Commands;
using WebApi.Application.MovieOperations.Queries;
using WebApi.Models.Entities;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Actor Mappings
        CreateMap<Actor, ActorViewModel>();
        CreateMap<Actor, ActorDetailViewModel>();
        CreateMap<CreateActorModel, Actor>();

        // Director Mappings
        CreateMap<Director, DirectorViewModel>();
        CreateMap<Director, DirectorDetailViewModel>();
        CreateMap<CreateDirectorModel, Director>();

        // Movie Mappings
        CreateMap<Movie, MovieViewModel>();
        CreateMap<Movie, MovieDetailViewModel>();
        CreateMap<CreateMovieModel, Movie>();
    }
}
