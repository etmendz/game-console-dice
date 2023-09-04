namespace GameLibraryDice;

/// <summary>
/// Defines a dice guessing game.
/// </summary>
/// <param name="sides">The number of sides per die. Default is 6.</param>
/// <param name="count">The number of dice. Default is 2.</param>
public class Guess(int sides = 6, int count = 2)
{
    /// <summary>
    /// Gets or set the number of sides per die.
    /// </summary>
    public int Sides { get; set; } = sides;

    /// <summary>
    /// Gets or sets the number of dice.
    /// </summary>
    public int Count { get; set; } = count;

    /// <summary>
    /// Gets the last guess.
    /// </summary>
    public int LastGuess { get; private set; }

    /// <summary>
    /// Gets the last roll.
    /// </summary>
    public int LastRoll { get; private set; }

    /// <summary>
    /// Gets the win state.
    /// </summary>
    public bool IsWon { get; private set; }

    /// <summary>
    /// Gets the win count.
    /// </summary>
    public int WinCount { get; private set; }

    /// <summary>
    /// Gets the roll count.
    /// </summary>
    public int RollCount { get; private set; }

    /// <summary>
    /// Gets the luck rate.
    /// </summary>
    public double Luck { get; private set; }

    /// <summary>
    /// Gets or sets the quit state.
    /// </summary>
    public bool Quit { get; set; }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void Start()
    {
        LastGuess = 0;
        LastRoll = 0;
        IsWon = false;
        WinCount = 0;
        RollCount = 0;
        Luck = 0;
        Quit = false;
    }

    /// <summary>
    /// Rolls the dice.
    /// </summary>
    /// <param name="guess">The guess.</param>
    /// <returns>Yields the rolled side per die.</returns>
    public IEnumerable<int> Roll(int guess)
    {
        int rolls = 0;
        foreach (int roll in Dice.Roll(Sides, Count))
        {
            rolls += roll;
            yield return roll;
        }
        EvaluateRoll(guess, rolls);
    }

    /// <summary>
    /// Rolls the dice asynchronously.
    /// </summary>
    /// <param name="guess">The guess.</param>
    /// <returns>Yields the rolled side per die.</returns>
    public async IAsyncEnumerable<int> RollAsync(int guess)
    {
        int rolls = 0;
        await foreach (int roll in Dice.RollAsync(Sides, Count))
        {
            rolls += roll;
            yield return roll;
        }
        EvaluateRoll(guess, rolls);
    }

    /// <summary>
    /// Evaluates the roll.
    /// </summary>
    /// <param name="guess">The guess.</param>
    /// <param name="rolls">The total rolled sides.</param>
    private void EvaluateRoll(int guess, int rolls)
    {
        LastGuess = guess;
        LastRoll = rolls;
        IsWon = guess == rolls;
        if (IsWon) WinCount++;
        RollCount++;
        Luck = (double)WinCount / (double)RollCount;
    }

    /// <summary>
    /// Continues the game.
    /// </summary>
    public void Continue() => IsWon = false;

    /// <summary>
    /// Determines if it's game over.
    /// </summary>
    /// <returns>True if game over, else false.</returns>
    public bool GameOver() => IsWon || Quit;

    /// <summary>
    /// Ends the game.
    /// </summary>
    public void End() => Quit = true;
}