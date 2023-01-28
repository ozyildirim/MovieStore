using FluentValidation;
using WebApi.Application.OrderOperations.Queries;

namespace WebApi.Application.ActorOperations.Queries;

public class GetCustomerOrdersQueryValidator : AbstractValidator<GetCustomerOrdersQuery>
{
    public GetCustomerOrdersQueryValidator()
    {
        RuleFor(command => command.CustomerId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Customer Id must be 0 or greater!");
    }
}
