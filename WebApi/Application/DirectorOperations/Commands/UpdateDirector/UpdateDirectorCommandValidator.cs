using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands;

public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
{
    public UpdateDirectorCommandValidator()
    {
        RuleFor(command => command.Model.Name)
            .NotNull()
            .MinimumLength(4)
            .WithMessage("Director name must be greater than 4 characters!");

        RuleFor(command => command.Model.Surname)
            .NotNull()
            .MinimumLength(4)
            .WithMessage("Director surname must be greater than 4 characters!");
    }
}
