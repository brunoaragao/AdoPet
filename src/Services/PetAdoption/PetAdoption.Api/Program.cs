var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdoptionContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("PetAdoptionContext")!));

builder.Services.AddScoped<IAdopterRepository, AdopterRepository>();
builder.Services.AddScoped<IShelterRepository, ShelterRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationErrorsToModelStateBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddValidatorsFromAssembly(Assembly.Load("PetAdoption.Application"));

builder.Services.AddMediatR(options =>
    options.RegisterServicesFromAssembly(Assembly.Load("PetAdoption.Application")));

builder.Services.AddControllers(options =>
    options.SuppressAsyncSuffixInActionNames = false);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AdoptionContext>();
    context.Database.Migrate();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();