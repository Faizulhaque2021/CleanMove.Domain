using CleanMove.Application;
using CleanMove.Infrustructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register Configuration
 ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Database Service 
builder.Services.AddDbContext<MoveDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b=> b.MigrationsAssembly("CleanMove.API")));
builder.Services.AddScoped<IMoveService, MoveService>();
builder.Services.AddScoped<IMoveRepository, MoveRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
