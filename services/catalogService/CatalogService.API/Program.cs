using CatalogService.Application;
using CatalogService.Persistence;

var builder = WebApplication.CreateBuilder(args);


// ioc
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration.GetConnectionString("MongoDb"), builder.Configuration.GetConnectionString("DatabaseName"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
