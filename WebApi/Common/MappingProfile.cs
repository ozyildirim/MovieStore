using AutoMapper;
using WebApi.Application.ActorOperations.Commands;
using WebApi.Application.ActorOperations.Queries;
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
    }
}
