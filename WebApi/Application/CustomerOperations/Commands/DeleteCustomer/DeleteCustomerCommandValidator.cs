using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Customer id must be specified!");
    }
}
