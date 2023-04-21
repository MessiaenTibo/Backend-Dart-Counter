namespace DartCounter.Models;

public class Games
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public int PlayerAmount { get; set; }
    public string? Date { get; set; }
    public string? ThrowIn { get; set; }
    public string? ThrowOut { get; set; }
    public int? Score { get; set; }
    public int? Legs { get; set; }
    public int? Sets { get; set; }
    public Player? Player1 { get; set; }
    public Player? Player2 { get; set; }
    public string? Title { get; set; }
}
