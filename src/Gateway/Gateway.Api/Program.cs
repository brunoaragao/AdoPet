var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddHttpClient("Adopty", client => client.BaseAddress = new Uri(configuration["Services:Adopty:Url"]!));
services.AddHttpClient("Identity", client => client.BaseAddress = new Uri(configuration["Services:Identity:Url"]!));

services.AddScoped<IAdoptyService, AdoptyService>();
services.AddScoped<IIdentityService, IdentityService>();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = configuration["Services:Identity:Url"];
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

services.AddControllers();

services.AddEndpointsApiExplorer();

services.AddSwaggerGen(options => options.AddPasswordSecurityDefinition(configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId("api-gateway-swagger-ui-client");
        options.OAuthAppName("API Gateway Swagger UI Client");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();