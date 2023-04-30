var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(settings);

builder.Services.AddValidatorsFromAssemblyContaining<GamesValidator>();
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

app.MapPost("/games", async (IValidator<Games> validator, Games game, IGamesService gamesService) =>
{
    var newGame = await validator.ValidateAsync(game);
    if (!newGame.IsValid)
        return Results.BadRequest(newGame.Errors);
    await gamesService.AddGame(game);
    return Results.Ok(newGame);
});

app.MapDelete("/games/{id}", async (IGamesService gamesService, string id) =>
{
    await gamesService.DeleteGame(id);
    return Results.Ok();
});

app.Run();
