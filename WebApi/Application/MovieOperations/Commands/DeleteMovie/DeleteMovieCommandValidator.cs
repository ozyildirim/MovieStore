using FluentValidation;
using WebApi.Application.ActorOperations.Commands;

namespace WebApi.Application.MovieOperations.Commands;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Movie id must be specified!");
    }
}
