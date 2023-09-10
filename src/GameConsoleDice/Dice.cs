/*
* GameConsoleDice (c) Mendz, etmendz. All rights reserved. 
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
namespace GameConsoleDice;

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
}