using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Customer id must be specified!");
    }
}
