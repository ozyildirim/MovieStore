using FluentValidation;

namespace WebApi.Application.ActorOperations.Queries;

public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
{
    public GetActorDetailQueryValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("BookId must be 0 or greater!");
    }
}
