namespace DartCounter.Validators;

public class GamesValidator : AbstractValidator<Games>
{
    public GamesValidator()
    {
        RuleFor(Games => Games.playerAmount).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(Games => Games.date).NotNull().NotEmpty();
        RuleFor(Games => Games.throwIn).NotNull().NotEmpty();
        RuleFor(Games => Games.throwOut).NotNull().NotEmpty();
        RuleFor(Games => Games.score).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(Games => Games.legs).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(Games => Games.sets).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(Games => Games.player1).NotNull().NotEmpty();
    }
}

