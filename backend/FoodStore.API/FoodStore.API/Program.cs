using FoodStore.API.Application.Services;
using FoodStore.API.Core.Abstractions.Repositories;
using FoodStore.API.Core.Abstractions.Services;
using FoodStore.API.DataAccess;
using FoodStore.API.DataAccess.Repositories;
using FoodStore.API.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddDbContext<FoodStoreDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(FoodStoreDbContext)));
    });

builder.Services.AddHttpClient<IRecipeService, RecipeService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5257");
});

var app = builder.Build();

app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:5173")
          .AllowCredentials()
          .AllowAnyHeader()
          .AllowAnyMethod();
});


app.MapFoodEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();
