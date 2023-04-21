namespace DartCounter.Validators;

public class GamesValidator : AbstractValidator<Games>
{
    public GamesValidator()
    {
        RuleFor(Games => Games.PlayerAmount).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(Games => Games.Date).NotNull().NotEmpty();
        RuleFor(Games => Games.ThrowIn).NotNull().NotEmpty();
        RuleFor(Games => Games.ThrowOut).NotNull().NotEmpty();
        RuleFor(Games => Games.Score).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(Games => Games.Legs).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(Games => Games.Sets).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(Games => Games.Player1).NotNull().NotEmpty();
    }
}

