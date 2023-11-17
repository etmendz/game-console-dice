/*
* GameConsoleDice (c) Mendz, etmendz. All rights reserved. 
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
using GameLibrary;

namespace GameConsoleDice;

/// <summary>
/// Provides methods to roll a die.
/// </summary>
public static class Die
{
    /// <summary>
    /// Rolls a die.
    /// </summary>
    /// <param name="sides">The number of sides on the die. Default is 6.</param>
    /// <returns>The rolled side.</returns>
    public static int Roll(int sides = 6) => Random.Shared.Next(1, sides + 1);
}