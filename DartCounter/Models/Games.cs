namespace DartCounter.Models;

public class Games
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }
    public int playerAmount { get; set; }
    public string? date { get; set; }
    public string? throwIn { get; set; }
    public string? throwOut { get; set; }
    public int? score { get; set; }
    public int? legs { get; set; }
    public int? sets { get; set; }
    public player? player1 { get; set; }
    public player? player2 { get; set; }
    public string? title { get; set; }
}
