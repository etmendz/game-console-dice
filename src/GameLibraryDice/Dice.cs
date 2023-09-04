/*
* GameLibraryDice (c) Mendz, etmendz. All rights reserved. 
* Part of GameConsoleDice
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
namespace GameLibraryDice;

/// <summary>
/// Provides methods to roll the dice.
/// </summary>
public static class Dice
{
    /// <summary>
    /// Rolls the dice.
    /// </summary>
    /// <param name="sides">The number of sides per die. Default is 6.</param>
    /// <param name="count">The number of dice. Default is 2.</param>
    /// <returns>Yields each rolled side per die.</returns>
    public static IEnumerable<int> Roll(int sides = 6, int count = 2)
    {
        for (int i = 0; i < count; i++)
        {
            yield return Die.Roll(sides);
        }
    }

    /// <summary>
    /// Rolls the dice asynchronously.
    /// </summary>
    /// <param name="sides">The number of sides per die. Default is 6.</param>
    /// <param name="count">The number of dice. Default is 2.</param>
    /// <returns>Yields each rolled side per die.</returns>
    public static async IAsyncEnumerable<int> RollAsync(int sides = 6, int count = 2)
    {
        for (int i = 0; i < count; i++)
        {
            await Task.Delay(0);
            yield return Die.Roll(sides);
        }
    }
}