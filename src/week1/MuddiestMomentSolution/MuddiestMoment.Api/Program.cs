using MuddiestMoment.Api.Student;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddValidation(); //newer .NET to opt into services to handle api validation
//end of services config

var app = builder.Build();

//extension methods (new 10.0 way)

app.MapStudentEndpoints();


//app.MapPost("/student/moments", () =>
//{
//    return "Howdy!";
//});


app.MapDefaultEndpoints();
app.Run(); // starts the api - "blocking loop"

