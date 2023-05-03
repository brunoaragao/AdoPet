var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var assemblies = new Dictionary<string, Assembly>
{
    ["Identity.Api"] = Assembly.Load("Identity.Api")
};

builder.Host.UseSerilog((host, log) =>
{
    log.WriteTo.Console();
    log.MinimumLevel.Debug();
    log.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
});

builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer("Name=ConnectionStrings:IdentityConnection"));

builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options => options.Discovery.CustomEntries.Add("registration_endpoint", "~/connect/register"))
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddProfileService<ProfileService<IdentityUser<Guid>>>()
    .AddAspNetIdentity<IdentityUser<Guid>>();

builder.Services.AddSingleton<ICorsPolicyService>(container =>
{
    var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
    return new DefaultCorsPolicyService(logger)
    {
        AllowAll = true
    };
});

builder.Services.AddMassTransit(x => x.UsingRabbitMq((context, cfg) => cfg.Host(configuration["RabbitMQ:Host"])));

builder.Services.AddMediator(x =>
{
    x.AddConsumers(assemblies["Identity.Api"]);
    x.ConfigureMediator((context, cfg) => cfg.UseConsumeFilter(typeof(ValidationFilter<>), context));
});

builder.Services.AddValidatorsFromAssembly(assemblies["Identity.Api"]);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<IdentityContext>();
    context.Database.Migrate();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();