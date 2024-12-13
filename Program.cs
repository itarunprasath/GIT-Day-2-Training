using System.Text.Json.Serialization;
using TrainingDay4.Repository;
using TrainingDay4.Services;

var builder = WebApplication.CreateBuilder(args);
// Build configuration with environment-specific files
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services, configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{

    services.AddTransient<ISlabsRepo, SlabsRepo>(provider =>
    new SlabsRepo(configuration.GetConnectionString("YourConnectionStringName")));

    services.AddTransient<ISlabsServie, SlabsServie>();

    services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

    // Add other services here
}
