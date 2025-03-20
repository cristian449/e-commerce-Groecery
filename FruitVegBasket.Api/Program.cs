using FruitVegBasket.Api.Constants;
using FruitVegBasket.Api.Data;
using FruitVegBasket.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString(DatabaseConstants.GroceryConnectionStringKey)));

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

var mastersGroup = app.MapGroup("/masters").AllowAnonymous();

mastersGroup.MapGet("/categories", async (DataContext context) =>
    await context.Categories
          .AsNoTracking()
          .ToArrayAsync()
);

app.MapGet("/offers", async (DataContext context) =>
    await context.Offers
          .AsNoTracking()
          .ToArrayAsync()
          
);

app.MapGet("/popular-products", async (DataContext context, int? count) =>
{
    if (!count.HasValue || count <= 0)
        count = 6;

    var randomProducts = await context.Products
                            .AsNoTracking()
                            .OrderBy(p => Guid.NewGuid())
                            .Take(count.Value)
                            .Select(Product.DtoSelector)
                            .ToArrayAsync();
    return TypedResults.Ok(randomProducts);
});


app.Run("https://localhost:5503");



//Error has been fixed, installed SQL server and server manager, as well as just in case allowed the port
//past the firewall in case that was the issue

////// There is a problem with updating database, some sort of SQL exception error
////// A network-related or instance-specific error occurred while establishing a connection to SQL Server.
////// The server was not found or was not accessible. Verify that the instance name is correct and
////// that SQL Server is configured to allow remote connections.
////// (provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)
////// Dont know how to fix this yet, will look into it later and might have to start again
////// with a new project if i cant fix this

