var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Program");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/moistures", async (Message message) =>
{
    logger.LogInformation("Data: "+message.data);
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
