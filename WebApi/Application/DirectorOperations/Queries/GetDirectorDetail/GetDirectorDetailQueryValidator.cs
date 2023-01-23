using FluentValidation;

namespace WebApi.Application.DirectorOperations.Queries;

public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
{
    public GetDirectorDetailQueryValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Director id must be 0 or greater!");
    }
}
