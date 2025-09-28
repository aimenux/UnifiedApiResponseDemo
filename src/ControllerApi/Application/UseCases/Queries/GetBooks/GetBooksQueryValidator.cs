using FluentValidation;

namespace Application.UseCases.Queries.GetBooks;

public sealed class GetBooksQueryValidator : AbstractValidator<GetBooksQuery>
{
    public GetBooksQueryValidator()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThan(0).WithMessage("PageIndex must be greater than 0");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("PageSize must be greater than 0");
    }
}