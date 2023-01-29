using FluentValidation;

namespace WebApi.Application.ActorOperations.Queries;

public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
{
    public GetActorDetailQueryValidator()
    {
        RuleFor(command => command.Id)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Actor id must be 0 or greater!");
    }
}
