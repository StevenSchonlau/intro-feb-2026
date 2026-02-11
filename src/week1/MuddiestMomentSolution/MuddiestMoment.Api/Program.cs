using Marten;
using MuddiestMoment.Api.Student;

var builder = WebApplication.CreateBuilder(args);

//fail early
var connectionString = builder.Configuration.GetConnectionString("db-mm") ?? throw new Exception("No Connection String"); //will look in several places for connection string - returns null if not found
                //looks in appsettings.json, then "ASPNETCORE_ENVIRONMENT" env appsettings.ENVIRONMENT.json
                //launch settings has environment variable for this
                //last place is env variables ConnectionStrings__<name of cs>
                //will keep going and last one overrides


//Console.WriteLine($"Using Connection String {connectionString}");

builder.Services.AddMarten(config =>
{
    config.Connection(connectionString);
}).UseLightweightSessions();


builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddValidation(); //newer .NET to opt into services to handle api validation
//end of services config

var app = builder.Build();

//extension methods (new 10.0 way)

app.MapStudentEndpoints();

app.MapOpenApi();

//app.MapPost("/student/moments", () =>
//{
//    return "Howdy!";
//});


app.MapDefaultEndpoints(); // more explicit means more intentional revealing
app.Run(); // starts the api - "blocking loop"

