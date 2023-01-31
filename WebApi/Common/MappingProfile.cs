using AutoMapper;
using WebApi.Application.ActorOperations.Commands;
using WebApi.Application.ActorOperations.Queries;
using WebApi.Application.CustomerOperations.Commands;
using WebApi.Application.CustomerOperations.Queries;
using WebApi.Application.DirectorOperations.Commands;
using WebApi.Application.DirectorOperations.Queries;
using WebApi.Application.MovieOperations.Commands;
using WebApi.Application.MovieOperations.Queries;
using WebApi.Application.OrderOperations.Commands;
using WebApi.Application.OrderOperations.Queries;
using WebApi.Models.Entities;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Actor Mappings
        //// GetActors
        CreateMap<Actor, ActorViewModel>()
            .ForMember(
                dest => dest.Movies,
                opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Movie).ToList())
            );
        CreateMap<Movie, ActorViewModel.ActorMoviesVM>();

        //// GetActorDetail
        CreateMap<Actor, ActorDetailViewModel>()
            .ForMember(
                dest => dest.Movies,
                opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Movie).ToList())
            );
        CreateMap<Movie, ActorDetailViewModel>();
        //// CreateActor
        CreateMap<CreateActorModel, Actor>();

        // Director Mappings
        CreateMap<Director, DirectorViewModel>();
        CreateMap<Director, DirectorDetailViewModel>();
        CreateMap<CreateDirectorModel, Director>();

        // Movie Mappings
        //// GetMovies
        CreateMap<Movie, MovieViewModel>()
            .ForMember(
                dest => dest.Actors,
                opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor).ToList())
            );
        CreateMap<Actor, MovieViewModel.MovieActorVM>();
        //// GetMovieDetail
        CreateMap<Movie, MovieDetailViewModel>()
            .ForMember(
                dest => dest.Actors,
                opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor).ToList())
            )
            .ForMember(
                dest => dest.Director,
                opt => opt.MapFrom(src => src.Director.Name.ToString())
            );

        CreateMap<Actor, MovieDetailViewModel.MovieActor>();
        CreateMap<CreateMovieModel, Movie>();

        // Order Mappings
        CreateMap<Order, OrderViewModel>();
        CreateMap<Order, OrderDetailViewModel>();
        CreateMap<CreateOrderModel, Order>();

        // Customer Mappings
        CreateMap<Customer, CustomerViewModel>();
        CreateMap<Customer, CustomerDetailViewModel>();
        CreateMap<CreateCustomerModel, Customer>();
    }
}
