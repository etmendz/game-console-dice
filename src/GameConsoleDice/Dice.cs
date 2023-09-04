namespace GameConsoleDice;

/// <summary>
/// Represents a cube dice with 6 sides.
/// </summary>
internal static class Dice
{
    private static readonly string _one = 
        "---------" + Environment.NewLine +
        "|       |" + Environment.NewLine +
        "|   *   |" + Environment.NewLine +
        "|       |" + Environment.NewLine +
        "---------";
    public static string One { get => _one; }

    private static readonly string _two = 
        "---------" + Environment.NewLine +
        "|     * |" + Environment.NewLine +
        "|       |" + Environment.NewLine +
        "| *     |" + Environment.NewLine +
        "---------";
    public static string Two { get => _two; }


    private static readonly string _three = 
        "---------" + Environment.NewLine +
        "|     * |" + Environment.NewLine +
        "|   *   |" + Environment.NewLine +
        "| *     |" + Environment.NewLine +
        "---------";
    public static string Three { get => _three; }

    private static readonly string _four = 
        "---------" + Environment.NewLine +
        "| *   * |" + Environment.NewLine +
        "|       |" + Environment.NewLine +
        "| *   * |" + Environment.NewLine +
        "---------";
    public static string Four { get => _four; }

    private static readonly string _five = 
        "---------" + Environment.NewLine +
        "| *   * |" + Environment.NewLine +
        "|   *   |" + Environment.NewLine +
        "| *   * |" + Environment.NewLine +
        "---------";
    public static string Five { get => _five; }

    private static readonly string _six = 
        "---------" + Environment.NewLine +
        "| *   * |" + Environment.NewLine +
        "| *   * |" + Environment.NewLine +
        "| *   * |" + Environment.NewLine +
        "---------";
    public static string Six { get => _six; }

    /// <summary>
    /// Draws the dice.
    /// </summary>
    /// <param name="side">The side to draw.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the side passed is invalid.</exception>
    public static void Draw(int side) => Console.WriteLine(side switch
    {
        1 => One,
        2 => Two,
        3 => Three,
        4 => Four,
        5 => Five,
        6 => Six,
        _ => throw new ArgumentOutOfRangeException(nameof(side))
    });
}
