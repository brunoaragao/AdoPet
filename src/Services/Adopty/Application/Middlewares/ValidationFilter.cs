namespace Adopty.Application.Middlewares;

public class ValidationFilter<TMessage> : IFilter<ConsumeContext<TMessage>>
    where TMessage : class
{
    private readonly IValidator<TMessage>? _validator;

    public ValidationFilter(IValidator<TMessage>? validator = null)
    {
        _validator = validator;
    }

    public void Probe(ProbeContext context)
    {
        context.CreateFilterScope("validation");
    }

    public async Task Send(
        ConsumeContext<TMessage> context,
        IPipe<ConsumeContext<TMessage>> next)
    {
        if (_validator is not null)
        {
            var result = await _validator.ValidateAsync(context.Message);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        await next.Send(context);
    }
}