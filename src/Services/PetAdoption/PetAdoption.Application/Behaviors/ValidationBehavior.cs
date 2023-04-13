namespace AdoPet.Services.PetAdoption.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : ResultBase<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (failures.Any())
        {
            var errors = failures.Select(f => new ValidationError(f.ErrorMessage, f.PropertyName));

            if (typeof(TResponse) == typeof(Result))
            {
                return (TResponse)(ResultBase)Result.Fail(errors);
            }

            if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                var fluentResultValueType = typeof(TResponse).GetGenericArguments()[0];

                var failMethod = typeof(Result).GetMethods()
                    .Where(x => x.Name == nameof(Result.Fail))
                    .Where(x => x.IsGenericMethod)
                    .Where(x => x.GetParameters().Length == 1)
                    .Where(x => x.GetParameters()[0].ParameterType == typeof(IEnumerable<IError>))
                    .Single()
                    .MakeGenericMethod(fluentResultValueType);

                return (TResponse)(ResultBase)failMethod.Invoke(null, new[] { errors })!;
            }
        }

        return await next();
    }
}