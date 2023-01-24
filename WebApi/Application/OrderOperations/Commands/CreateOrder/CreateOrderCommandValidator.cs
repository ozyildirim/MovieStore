using FluentValidation;

namespace WebApi.Application.OrderOperations.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(command => command.Model.MovieId)
            .NotNull()
            .WithMessage("Movie Id must be specified!");

        RuleFor(command => command.Model.CustomerId)
            .NotNull()
            .WithMessage("Customer Id must be specified!");

        RuleFor(command => command.Model.Price)
            .NotNull()
            .WithMessage("Price must be specified!");
    }
}
