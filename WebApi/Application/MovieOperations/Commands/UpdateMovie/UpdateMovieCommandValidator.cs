using FluentValidation;
using WebApi.Application.ActorOperations.Commands;

namespace WebApi.Application.DirectorOperations.Commands;

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieCommandValidator()
    {
        RuleFor(command => command.Model.Title)
            .NotNull()
            .MinimumLength(4)
            .WithMessage("Movie title must be greater than 4 characters!");

        RuleFor(command => command.Model.Price)
            .NotNull()
            .WithMessage("Movie price must be specified!");
    }
}
