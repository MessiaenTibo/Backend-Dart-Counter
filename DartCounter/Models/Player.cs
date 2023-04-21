namespace DartCounter.Models;

public class player
{
    public string? playerID { get; set; }
    public string? username { get; set; }
    public bool? Won { get; set; }
    public int? darts { get; set; }
    public double? threeDartAvg { get; set; }
    public int? highestScore { get; set; }
    public int? highestCheckout { get; set; }
    public checkout? checkouts { get; set; }
    public int? fourtyPlus { get; set; }
    public int? sixtyPlus { get; set; }
    public int? eightyPlus { get; set; }
    public int? hundredPlus { get; set; }
    public int? oneTwentyPlus { get; set; }
    public int? oneFortyPlus { get; set; }
    public int? oneSixtyPlus { get; set; }
    public int? oneEighty { get; set; }
}

