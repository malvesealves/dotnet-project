using Restaurants.WebApi.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.ConfigureCors();
builder.Services.ConfigureMediatR();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
