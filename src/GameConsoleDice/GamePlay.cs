/*
* GameConsoleDice (c) Mendz, etmendz. All rights reserved. 
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
using GameLibrary;

namespace GameConsoleDice;

internal class GamePlay : IGamePlay<int, IEnumerable<int>>
{
    /// <summary>
    /// Gets or set the number of sides per die. Default is 6.
    /// </summary>
    public int Sides { get; set; } = 6;

    /// <summary>
    /// Gets or sets the number of dice. Default is 2.
    /// </summary>
    public int Count { get; set; } = 2;

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
    public bool Start()
    {
        LastGuess = 0;
        LastRoll = 0;
        IsWon = false;
        WinCount = 0;
        RollCount = 0;
        Luck = 0;
        Quit = false;
        return true;
    }

    /// <summary>
    /// Rolls the dice.
    /// </summary>
    /// <param name="guess">The guess.</param>
    /// <returns>Yields the rolled side per die.</returns>
    public IEnumerable<int> Action(int guess)
    {
        int rolls = 0;
        foreach (int roll in Dice.Roll(Sides, Count))
        {
            rolls += roll;
            yield return roll;
        }
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
    public bool Continue()
    {
        IsWon = false;
        return true;
    }

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