/// <summary>
/// Configures the web application builder, adds necessary services, and builds the application.
/// </summary>

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});

builder
    .Services.AddMarten(options =>
    {
        options.Connection(builder.Configuration.GetConnectionString("Database")!);
    })
    .UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapCarter();

app.Run();
