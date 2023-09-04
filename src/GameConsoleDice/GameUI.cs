/*
* GameConsoleDice (c) Mendz, etmendz. All rights reserved. 
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
using GameLibraryDice;
using System.Reflection;
using System.Resources;

namespace GameConsoleDice;

/// <summary>
/// Defines the game UI.
/// </summary>
internal class GameUI
{
    /// <summary>
    /// Gets the guessing game.
    /// </summary>
    public Guess Guess { get; private set; }

    /// <summary>
    /// Creates an instance of the <see cref="GameUI"/>.
    /// </summary>
    public GameUI() => Guess = new();

    /// <summary>
    /// Starts the game.
    /// </summary>
    /// <returns>True if a game is started, else false.</returns>
    public void Start()
    {
        Guess.Start();
        Render();
    }

    /// <summary>
    /// Renders the game UI.
    /// </summary>
    public void Render()
    {
        Console.Clear();
        Console.WriteLine($"Last Guess: {Guess.LastGuess}\tLast Roll: {Guess.LastRoll}");
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
    public bool GuessAndRoll() 
    {
        bool guessed = false;
        Console.Write("Guess a number between 1 to 12: ");
        Console.CursorVisible = true;
        string? entry = Console.ReadLine();
        Console.CursorVisible = false;
        if (string.IsNullOrEmpty(entry)) Guess.End();
        else
        {
            guessed = Int32.TryParse(entry, out int guess) && (guess >= 1 && guess <= 12);
            if (guessed)
            {
                Console.WriteLine();
                foreach (int roll in Guess.Roll(guess))
                {
                    ShakeRattleAndRoll();
                    Dice.Draw(roll); // Reveal!
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
            Dice.Draw(r);
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
        if (Guess.IsWon)
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
        Console.WriteLine($"You guessed {Guess.WinCount} out of {Guess.RollCount} rolls.");
        Console.WriteLine();
        Console.WriteLine("Your luck is at {0:P2}.", Guess.Luck);
        Console.WriteLine();
        Console.Write("Guess and roll again? (Y/N): "); // Prompt to continue or not.
        if (GameUX.GetKey(ConsoleKey.Y) == ConsoleKey.Y)
        {
            Guess.Continue();
            Refresh();
        }
        else
        {
            Guess.End();
            Console.WriteLine();
        }
        return !Guess.Quit;
    }

    /// <summary>
    /// Checks if the game is over.
    /// </summary>
    /// <returns>True if game over, else false.</returns>
    public bool GameOver() => Guess.GameOver();

    /// <summary>
    /// Ends the game.
    /// </summary>
    public void End()
    {
        Guess.End();
        Console.WriteLine();
        Console.WriteLine("Thanks for playing!");
        Task.Delay(3000).Wait();
    }
}