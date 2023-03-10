using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands;

public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
{
    public DeleteActorCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Actor id must be specified!");
    }
}
