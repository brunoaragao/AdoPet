namespace AdoPet.Services.PetAdoption.Api.Behaviors;

public class ValidationErrorsToModelStateBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : ResultBase<TResponse>
{
    private readonly IActionContextAccessor _actionContextAccessor;

    public ValidationErrorsToModelStateBehavior(IActionContextAccessor actionContextAccessor)
    {
        _actionContextAccessor = actionContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await next();

        if (result.HasError<ValidationError>(out var errors))
            foreach (var error in errors)
                _actionContextAccessor.ActionContext!.ModelState.AddModelError(error.PropertyName, error.Message);

        return result;
    }
}