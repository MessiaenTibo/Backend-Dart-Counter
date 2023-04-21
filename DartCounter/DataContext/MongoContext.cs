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

    private string ConnectionStringValue { get; set; }
    private string DatabaseNameValue { get; set; }
    private string GamesCollectionValue { get; set; }


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
        SecretClientOptions options = new SecretClientOptions()
        {
            Retry =
            {
                Delay= TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(16),
                MaxRetries = 5,
                Mode = RetryMode.Exponential
            }
        };
        var client = new SecretClient(new Uri("https://keyvault-dartcounter.vault.azure.net/"), new DefaultAzureCredential(), options);

        KeyVaultSecret ConnectionString = client.GetSecret("ConnectionString");
        KeyVaultSecret DatabaseName = client.GetSecret("DatabaseName");
        KeyVaultSecret GamesCollection = client.GetSecret("GamesCollection");

        ConnectionStringValue = ConnectionString.Value;
        DatabaseNameValue = DatabaseName.Value;
        GamesCollectionValue = GamesCollection.Value;

        _settings = dbOptions.Value;
        _client = new MongoClient(ConnectionStringValue);
        _database = _client.GetDatabase(DatabaseNameValue);
    }

    public IMongoCollection<Games> GamesCollection
    {
        get
        {
            return _database.GetCollection<Games>(GamesCollectionValue);
        }
    }
}
