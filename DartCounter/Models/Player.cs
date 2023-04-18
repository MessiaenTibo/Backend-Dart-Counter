namespace DartCounter.Models;

public class Player
{
    public string? PlayerID { get; set; }
    public string? Username { get; set; }
    public bool? Won { get; set; }
    public int? Darts { get; set; }
    public double? ThreeDartAvg { get; set; }
    public int? HighestFinish { get; set; }
    public int? HighestCheckout { get; set; }
    public Checkout? Checkouts { get; set; }
    public int? FourtyPlus { get; set; }
    public int? SixtyPlus { get; set; }
    public int? EightyPlus { get; set; }
    public int? HundredPlus { get; set; }
    public int? OneTwentyPlus { get; set; }
    public int? OneFortyPlus { get; set; }
    public int? OneSixtyPlus { get; set; }
    public int? OneEighty { get; set; }
}

