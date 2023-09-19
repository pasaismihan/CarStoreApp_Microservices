using MongoDB.Driver;
using MongoDB.Entities;
using SearchService;
using SearchService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<AuctionSvcHttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseAuthorization();

app.MapControllers();

try
{
await DbInitializer.InitDb(app);
}
catch (Exception e)
{
    
   Console.WriteLine(e);
}

app.Run();
