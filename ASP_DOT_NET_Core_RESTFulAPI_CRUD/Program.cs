using ASP_DOT_NET_Core_RESTFulAPI_CRUD.Services;
using Microsoft.AspNetCore.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. Configure Serilog for logging
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration
        .WriteTo.Console()
        .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
        .ReadFrom.Configuration(context.Configuration); // Load settings from appsettings.json
});

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()  // Allows any origin
               .AllowAnyMethod()  // Allows any HTTP method (GET, POST, etc.)
               .AllowAnyHeader(); // Allows any header
    });
    //options.AddPolicy("AllowSpecific", builder =>
    //{
    //    builder.WithOrigins("http://example.com", "http://anotherdomain.com") // Specify allowed origins
    //           .AllowAnyMethod()
    //           .AllowAnyHeader();
    //});
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adding the following dependency injection container
builder.Services.AddSingleton<DapperDbContext>();
// Add the repository to the DI container
builder.Services.AddScoped<EmployeeRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()){}
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

// Use CORS policy
app.UseRouting();
app.UseCors("AllowAll"); // Apply the CORS policy here
// app.UseCors("AllowSpecific");

app.UseAuthorization();

app.MapControllers();

app.Run();

try
{
    Log.Information("Starting the application");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}