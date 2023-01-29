using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands;

public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
{
    public UpdateActorCommandValidator()
    {
        RuleFor(command => command.Model.Name)
            .NotNull()
            .MinimumLength(4)
            .WithMessage("Actor name must be greater than 4 characters!");

        RuleFor(command => command.Model.Surname)
            .NotNull()
            .MinimumLength(4)
            .WithMessage("Actor surname must be greater than 4 characters!");
    }
}
