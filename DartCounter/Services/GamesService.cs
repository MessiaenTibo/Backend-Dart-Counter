namespace DartCounter.Services;

public interface IGamesService
{
    Task<List<Games>> GetAllGames();
    Task<List<Games>> GetGamesByPlayerId(string playerId);
    Task<Games> AddGame(Games game);
    Task<Games> DeleteGame(string id);
}

public class GamesService : IGamesService
{
    private readonly IGamesRepository _gamesRepository;

    public GamesService(IGamesRepository gamesRepository)
    {
        _gamesRepository = gamesRepository;
    }

    public async Task<List<Games>> GetAllGames()
    {
        return await _gamesRepository.GetAllGames();
    }

    public async Task<List<Games>> GetGamesByPlayerId(string playerId)
    {
        return await _gamesRepository.GetGamesByPlayerId(playerId);
    }

    public async Task<Games> AddGame(Games game)
    {
        return await _gamesRepository.AddGame(game);
    }

    public async Task<Games> DeleteGame(string id)
    {
        return await _gamesRepository.DeleteGame(id);
    }
}

