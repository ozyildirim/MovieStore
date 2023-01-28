using FluentValidation;
using WebApi.Application.OrderOperations.Queries;

namespace WebApi.Application.ActorOperations.Queries;

public class GetOrderDetailQueryValidator : AbstractValidator<GetOrderDetailQuery>
{
    public GetOrderDetailQueryValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Order id must be 0 or greater!");
    }
}
