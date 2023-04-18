var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(settings);

builder.Services.AddTransient<IMongoContext, MongoContext>();
builder.Services.AddTransient<IGamesRepository, GamesRepository>();
builder.Services.AddTransient<IGamesService, GamesService>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/games", async (IGamesService gamesService) =>
{
    var games = await gamesService.GetAllGames();
    return Results.Ok(games);
});

app.MapGet("/games/{playerId}", async (IGamesService gamesService, string playerId) =>
{
    var games = await gamesService.GetGamesByPlayerId(playerId);
    return Results.Ok(games);
});

app.Run("http://localhost:5100");
