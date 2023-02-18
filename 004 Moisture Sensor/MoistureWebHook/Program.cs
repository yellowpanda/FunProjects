using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();
var app = builder.Build();

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Program");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/moistures", async () =>
    {
        return Results.Ok("Hi");
    })
    .WithName("GetMoistures")
    .WithOpenApi();


app.MapPost("/moistures", (Message message, string code, IConfiguration configuration) =>
    {
        string secret = (string)configuration["code"];
        if (secret != code)
        {
            return Results.Unauthorized();
        }

        logger.LogInformation("Data: " + message.data);
        return Results.Created($"/moistures/", message);
    })
    .WithName("PostMoistures")
    .WithOpenApi();

app.Run();

public class Message
{
    public string @event { get; set; }
    public string data { get; set; }

    public string coreid { get; set; }

    public DateTimeOffset published_at { get; set; }
}
