var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var assemblies = new Dictionary<string, Assembly>
{
    ["Adopty"] = Assembly.GetExecutingAssembly()
};

builder.Host.UseSerilog((host, log) =>
{
    log.WriteTo.Console();
    log.MinimumLevel.Debug();
    log.MinimumLevel.Override(
        "Microsoft",
        LogEventLevel.Warning);
});

builder.Services.AddDbContext<AdoptyContext>(
    options => options.UseSqlServer(
        "Name=ConnectionStrings:AdoptyConnection"));

builder.Services.AddScoped<IAdopterRepository, AdopterRepository>();
builder.Services.AddScoped<IAdoptionRepository, AdoptionRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IShelterRepository, ShelterRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AccountRegisteredConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(configuration["RabbitMQ:Host"]);
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddMediator((x) =>
{
    x.AddConsumers(
        assemblies["Adopty"]);
    x.ConfigureMediator(
        (context, cfg) => cfg.UseConsumeFilter(
            typeof(ValidationFilter<>),
            context));
});

builder.Services.AddValidatorsFromAssembly(
    assemblies["Adopty"]);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AdoptyContext>();
    context.Database.Migrate();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();