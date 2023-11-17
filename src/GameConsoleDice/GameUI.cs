/*
* GameConsoleDice (c) Mendz, etmendz. All rights reserved. 
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
using GameLibrary;
using System.Reflection;
using System.Resources;

namespace GameConsoleDice;

/// <summary>
/// Defines the game UI to guess and roll dice.
/// </summary>
internal class GameUI : IGameUI<GamePlay>
{
    private readonly GameConsoleUX _gameConsoleUX = new();

    /// <summary>
    /// Gets or sets the game play.
    /// </summary>
    public GamePlay GamePlay { get; set; }

    /// <summary>
    /// Creates an instance of the game UI.
    /// </summary>
    public GameUI() => GamePlay = new();

    /// <summary>
    /// Starts the game.
    /// </summary>
    /// <returns>True if a game is started, else false.</returns>
    public bool Start()
    {
        bool start = GamePlay.Start();
        if (start) Render();
        return start;
    }

    /// <summary>
    /// Renders the game UI.
    /// </summary>
    public void Render()
    {
        Console.Clear();
        Console.WriteLine($"Last Guess: {GamePlay.LastGuess}\tLast Roll: {GamePlay.LastRoll}");
        Console.WriteLine();
    }

    /// <summary>
    /// Refreshes the game UI.
    /// </summary>
    public void Refresh() => Render();

    /// <summary>
    /// Waits for a guess entry, then rolls the dice.
    /// </summary>
    /// <returns>True if a valid guess was made, else false.</returns>
    /// <remarks>An empty entry will exit the game.</remarks>
    public bool Action() 
    {
        bool guessed = false;
        Console.Write("Guess a number between 1 to 12: ");
        Console.CursorVisible = true;
        string? entry = Console.ReadLine();
        Console.CursorVisible = false;
        if (string.IsNullOrEmpty(entry)) GamePlay.End();
        else
        {
            guessed = Int32.TryParse(entry, out int guess) && (guess >= 1 && guess <= 12);
            if (guessed)
            {
                Console.WriteLine();
                GameActionInfo gameActionInfo = new() { Input = guess };
                if (GamePlay.Action(gameActionInfo))
                {
                    foreach (int roll in (int[])gameActionInfo.Output!)
                    {
                        ShakeRattleAndRoll();
                        GameDice.Draw(roll); // Reveal!
                    }
                }
            }
        }
        return guessed;
    }

    /// <summary>
    /// Randomly simulates various strengths of dice throws.
    /// </summary>
    /// <remarks>
    /// Can randomize from a full side roll (on 4 sides) up to 10 full side rolls (4 sides * 10 = 40).
    /// </remarks>
    private static void ShakeRattleAndRoll()
    {
        ConsoleColor foregroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        (int left, int top) = Console.GetCursorPosition();
        int delay = 10; // Start fast...
        int last = 0, r;
        for (int i = 1; i < Random.Shared.Next(4, 41); i++)
        {
            Task.Delay(delay).Wait(); // Allow the user to see the shaking, rattling and rolling dice.
            do
            {
                r = Random.Shared.Next(1, 7);
            } while (r == last); // The new random number must be different from the last.
            GameDice.Draw(r);
            last = r;
            delay += 10; // End slow...
            Console.SetCursorPosition(left, top);
        }
        Console.ForegroundColor = foregroundColor;
    }

    /// <summary>
    /// Prompts to continue the game.
    /// </summary>
    /// <returns>True if the player opts to continue, else false.</returns>
    public bool Continue()
    {
        Console.WriteLine();
        ConsoleColor foregroundColor = Console.ForegroundColor;
        if (GamePlay.IsWon)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new ResourceManager("GameConsoleDice.Won", Assembly.GetExecutingAssembly()).GetString(Random.Shared.Next(1, 13).ToString()) ?? "You win!!!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new ResourceManager("GameConsoleDice.Lose", Assembly.GetExecutingAssembly()).GetString(Random.Shared.Next(1, 13).ToString()) ?? "You lose!");
        }
        Console.ForegroundColor = foregroundColor;
        Console.WriteLine();
        Console.WriteLine($"You guessed {GamePlay.WinCount} out of {GamePlay.RollCount} rolls.");
        Console.WriteLine();
        Console.WriteLine("Your luck is at {0:P2}.", GamePlay.Luck);
        Console.WriteLine();
        Console.Write("Guess and roll again? (Y/N): "); // Prompt to continue or not.
        if (_gameConsoleUX.GetYN() == ConsoleKey.Y)
        {
            GamePlay.Continue();
            Refresh();
        }
        else
        {
            GamePlay.End();
            Console.WriteLine();
        }
        return !GamePlay.Quit;
    }

    /// <summary>
    /// Checks if the game is over.
    /// </summary>
    /// <returns>True if game over, else false.</returns>
    public bool GameOver() => GamePlay.GameOver();

    /// <summary>
    /// Ends the game.
    /// </summary>
    public void End()
    {
        GamePlay.End();
        Console.WriteLine();
        Console.WriteLine("Thanks for playing!");
        Task.Delay(1500).Wait();
    }
}