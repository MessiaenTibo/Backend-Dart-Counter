namespace DartCounter.DataContext;

public interface IMongoContext
{
    IMongoClient Client { get; }
    IMongoDatabase Database { get; }
    IMongoCollection<Games> GamesCollection { get; }
}

public class MongoContext : IMongoContext
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;

    private readonly DatabaseSettings _settings;


    public IMongoClient Client
    {
        get
        {
            return _client;
        }
    }
    public IMongoDatabase Database => _database;

    public MongoContext(IOptions<DatabaseSettings> dbOptions)
    {
        _settings = dbOptions.Value;
        _client = new MongoClient(_settings.ConnectionString);
        _database = _client.GetDatabase(_settings.DatabaseName);
    }

    public IMongoCollection<Games> GamesCollection
    {
        get
        {
            return _database.GetCollection<Games>(_settings.GamesCollection);
        }
    }
}
