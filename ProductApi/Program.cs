using ProductApi.Repository;
using ProductApi.Repository.Interface;
using ProductApi.Services;
using ProductApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddSingleton - means creating one instance for the entire apps
//builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddScoped<IProductRepository, DatabaseProductRepository>();

// AddScoped - one instance per request
//builder.Services.AddScoped<IProductService, ProductService>();

//builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () =>
{
    return Results.Ok(new { Status = 200, Successful = true, Message = "OK" });
});

app.Run();
