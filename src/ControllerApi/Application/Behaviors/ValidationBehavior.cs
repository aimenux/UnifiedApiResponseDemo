using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var failures = await ValidateAsync(request, cancellationToken);
        
        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }
        
        return await next(cancellationToken);
    }

    private async Task<List<ValidationFailure>> ValidateAsync(TRequest request, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var tasks = _validators
            .Select(x => x.ValidateAsync(context, cancellationToken))
            .ToList();
        var validationResults = await Task.WhenAll(tasks);
        var failures = validationResults
            .Where(x => x.Errors.Count != 0)
            .SelectMany(x => x.Errors)
            .ToList();
        return failures;
    }
}