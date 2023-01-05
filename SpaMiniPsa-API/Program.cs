using Microsoft.EntityFrameworkCore;
using SpaMiniPsa_API.Entities;
using SpaMiniPsa_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["Data:ConnectionStrings:defaultConnection"];
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IDogRepository, DogRepository>();
// TODO: Use this along with args -> `_context.Database.Migrate();`

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(policyBuilder => policyBuilder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

app.Run();
