using FilmsApi.Entity.Models;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetValue<string>("allowedOrigins");
//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });

    options.AddPolicy("free", config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello World!");

app.MapGet("/generos", () =>
{
    var genders = new List<Gender>
    {
        new Gender
        {
            Id = 1,
            Name = "Acción"
        },
        new Gender
        {
            Id = 2,
            Name = "Aventura"
        },
        new Gender
        {
            Id = 3,
            Name = "Comedia"
        }
    };

    return genders;
});

app.Run();
