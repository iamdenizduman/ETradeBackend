using AuthService.Application;
using AuthService.Infrastructure;
using AuthService.Persistence;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()      // T�m kaynaklara izin
              .AllowAnyMethod()      // T�m HTTP metodlara izin
              .AllowAnyHeader();     // T�m headerlara izin
    });
});


// Extensions
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddPersistenceServices(connectionString);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();