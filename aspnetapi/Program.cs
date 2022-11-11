using aspnetapi.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000","https://appname.azurestaticapps.net");
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( SwaggerGenOptions=>
{
    SwaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo{ Title = "ASP.net API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
app.UseSwaggerUI(SwaggerUIOptions =>
{
    SwaggerUIOptions.DocumentTitle = "ASP.NET API";
    SwaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API json");
    SwaggerUIOptions.RoutePrefix = String.Empty;
});
/*}*/

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

//get all stocks endpoint
app.MapGet("/get-all-stocks", async () => await StocksRepository.GetStocksAsync())
    .WithTags("Stocks endpoints");


app.MapGet("/get-stock-by-id/{stockId}", async(int stockId) =>
{
    Stock stockToReturn = await StocksRepository.GetStockByIdAsync(stockId);
    if(stockToReturn != null)
    {
        return Results.Ok(stockToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Stocks endpoints");

app.MapPost("/create-stock", async (Stock stockToCreate) =>
{
    bool createScuccessful=await StocksRepository.CreateStockAsync(stockToCreate);
    if (createScuccessful)
    {
        return Results.Ok("create was successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Stocks endpoints");



app.MapPut("/update-stock", async (Stock stockToUpdate) =>
{
    bool updateScuccessful = await StocksRepository.UpdateStockAsync(stockToUpdate);
    if (updateScuccessful)
    {
        return Results.Ok("create was successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Stocks endpoints");



app.MapDelete("/delete-stock-by-id/{stockId}", async (int stockId) =>
{
    bool deleteScuccessful = await StocksRepository.DeleteStockAsync(stockId);
    if (deleteScuccessful)
    {
        return Results.Ok("Delete was successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Stocks endpoints");

/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
*/
app.Run();

/*internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/