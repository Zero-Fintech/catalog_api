using Microsoft.EntityFrameworkCore;
using Zero.Catalog.Data;

var builder = WebApplication.CreateBuilder(args);

// TODO: Get application assembly and register core functionality
//var applicationAssembly = typeof(AddProduct).Assembly;
//builder.Services.AddCore(applicationAssembly);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CatalogDbContext>(options =>
{
    options.UseInMemoryDatabase("catalog");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }