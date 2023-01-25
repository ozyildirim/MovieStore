using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(command => command.Model.Name)
            .MinimumLength(4)
            .WithMessage("Customer name must be greater than 4 characters!");

        RuleFor(command => command.Model.Surname)
            .MinimumLength(4)
            .WithMessage("Customer surname must be greater than 4 characters!");
    }
}
