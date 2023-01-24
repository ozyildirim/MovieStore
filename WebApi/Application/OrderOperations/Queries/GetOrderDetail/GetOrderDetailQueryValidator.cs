using FluentValidation;

namespace WebApi.Application.ActorOperations.Queries;

public class GetOrderDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
{
    public GetOrderDetailQueryValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Order id must be 0 or greater!");
    }
}
