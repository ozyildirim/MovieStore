using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands;

public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
{
    public CreateDirectorCommandValidator()
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
