using FluentValidation;
using static Application.Constants.Lengths;

namespace Application.UseCases.Commands.UpdateBook;

public sealed class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
        
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(TitleMaxLength).WithMessage($"Title must not exceed {TitleMaxLength} characters");
        
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author is required")
            .MaximumLength(AuthorMaxLength).WithMessage($"Author must not exceed {AuthorMaxLength} characters");
    }
}