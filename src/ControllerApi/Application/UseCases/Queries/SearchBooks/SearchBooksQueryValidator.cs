using FluentValidation;

namespace Application.UseCases.Queries.SearchBooks;

public sealed class SearchBooksQueryValidator : AbstractValidator<SearchBooksQuery>
{
    public SearchBooksQueryValidator()
    {
        RuleFor(x => x.SearchTerm)
            .NotEmpty().WithMessage("SearchTerm is required");
        
        RuleFor(x => x.PageIndex)
            .GreaterThan(0).WithMessage("PageIndex must be greater than 0");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("PageSize must be greater than 0");
    }
}