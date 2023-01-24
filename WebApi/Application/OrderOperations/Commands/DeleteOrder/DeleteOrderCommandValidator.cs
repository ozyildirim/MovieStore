using FluentValidation;

namespace WebApi.Application.OrderOperations.Commands;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Order id must be specified!");
    }
}
