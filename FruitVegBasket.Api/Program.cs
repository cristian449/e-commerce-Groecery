using FruitVegBasket.Api.Constants;
using FruitVegBasket.Api.Data;
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
          .ToListAsync()
);

app.MapGet("/offers", async (DataContext context) =>
    await context.Offers
          .AsNoTracking()
          .ToListAsync()
);

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

