using FluentValidation;
using MediatR;

namespace Application.Behaviours;

public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
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
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
        }
        
        return await next(cancellationToken);
    }
}