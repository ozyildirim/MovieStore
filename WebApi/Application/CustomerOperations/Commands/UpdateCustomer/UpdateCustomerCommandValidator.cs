using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(command => command.Model.Name)
            .NotNull()
            .MinimumLength(4)
            .WithMessage("Customer name must be greater than 4 characters!");

        RuleFor(command => command.Model.Surname)
            .NotNull()
            .MinimumLength(4)
            .WithMessage("Customer surname must be greater than 4 characters!");
    }
}
