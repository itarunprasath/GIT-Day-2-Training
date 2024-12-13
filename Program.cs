using aznira5.Repository;
using aznira5.Services;
using System.Text.Json.Serialization;
using Task1_Score.Repository;
using Task1_Score.Services;
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
    //for SLAB
    services.AddTransient<ISlabsRepo, SlabsRepo>(provider =>
    new SlabsRepo(configuration.GetConnectionString("YourConnectionStringName")));

    services.AddTransient<ISlabsServie, SlabsServie>();

    services.AddTransient<IScoreRepo, ScoreRepo>(provider =>
       new ScoreRepo(configuration.GetConnectionString("YourConnectionStringNames")));

    services.AddTransient<IScoreService, ScoreService>();

    services.AddTransient<IRCRepo, RCRepo>(provider =>
    new RCRepo(configuration.GetConnectionString("YourConnectionStringName")));

    services.AddTransient<IRCService, RCService>();

    services.AddTransient<IUserRepo, UserRepo>(provider =>
    new UserRepo(configuration.GetConnectionString("YourConnectionStringName")));

    services.AddTransient<IUserService, UserService>();

    services.AddTransient<IUsersRepo, UsersRepo>(provider =>
    new UsersRepo(configuration.GetConnectionString("YourConnectionStringName")));

    services.AddTransient<IUsersService, UsersService>();

    //for CMS
    services.AddTransient<IcmsRepo,CmsRepo>(provider =>
    new CmsRepo(configuration.GetConnectionString("YourConnectionStringName1")));

    services.AddTransient<IcmsServices, CmsServices>();

    services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

    // Add other services here

    services.AddTransient<ITestsuRepo, TestsuRepo>(provider =>
    new TestsuRepo(configuration.GetConnectionString("YourConnectionStringName")));

    services.AddTransient<ITestsuService, TestsuService>();
}

