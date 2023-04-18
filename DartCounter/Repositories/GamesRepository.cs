namespace DartCounter.Repositories;

public interface IGamesRepository
{
    Task<List<Games>> GetAllGames();
    Task<List<Games>> GetGamesByPlayerId(string playerId);
    Task<Games> AddGame(Games game);
    Task<Games> DeleteGame(string id);
}

public class GamesRepository : IGamesRepository
{
    private readonly IMongoContext _context;

    public GamesRepository(IMongoContext context)
    {
        _context = context;
    }

    public async Task<List<Games>> GetAllGames()
    {
        return await _context.GamesCollection.Find(_ => true).ToListAsync();
    }

    public async Task<List<Games>> GetGamesByPlayerId(string playerId)
    {
        return await _context.GamesCollection.Find(x => x.player1.PlayerID == playerId || x.player2.PlayerID == playerId).ToListAsync();
    }

    public async Task<Games> AddGame(Games game)
    {
        await _context.GamesCollection.InsertOneAsync(game);
        return game;
    }

    public async Task<Games> DeleteGame(string id)
    {
        var game = await _context.GamesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        await _context.GamesCollection.DeleteOneAsync(x => x.Id == id);
        return game;
    }
}

