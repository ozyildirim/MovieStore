using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands;

public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
{
    public DeleteDirectorCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Director id must be specified!");
    }
}
