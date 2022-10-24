using FileStorage.AppConfiguration.ServicesExtensions;
using FileStorage.AppConfiguration.ApplicationExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogConfiguration();
builder.Services.AddVersioningConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

app.UseSerilogConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
