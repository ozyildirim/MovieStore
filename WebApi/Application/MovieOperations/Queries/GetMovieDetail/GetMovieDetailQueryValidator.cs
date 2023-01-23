using FluentValidation;

namespace WebApi.Application.MovieOperations.Queries;

public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
{
    public GetMovieDetailQueryValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Movie id must be 0 or greater!");
    }
}
