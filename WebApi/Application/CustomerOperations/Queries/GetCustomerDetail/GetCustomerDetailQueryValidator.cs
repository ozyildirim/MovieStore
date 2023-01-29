using FluentValidation;

namespace WebApi.Application.CustomerOperations.Queries;

public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
{
    public GetCustomerDetailQueryValidator()
    {
        RuleFor(command => command.Id)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Customer id must be 0 or greater!");
    }
}
