using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

string connectionString = "Data Source=LittleMSI;Initial Catalog=TestAPI_1;Integrated Security=True;Trust Server Certificate=True";

builder.Services.AddDbContext<MyDBContext>(option =>
{
    option.UseSqlServer(connectionString);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
