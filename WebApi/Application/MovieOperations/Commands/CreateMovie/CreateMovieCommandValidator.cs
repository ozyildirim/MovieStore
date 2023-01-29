using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(command => command.Model.Title)
            .NotNull()
            .MinimumLength(4)
            .WithMessage("Movie name must be greater than 4 characters!");

        RuleFor(command => command.Model.Year)
            .NotNull()
            .WithMessage("Movie year must be specified!");
    }
}
