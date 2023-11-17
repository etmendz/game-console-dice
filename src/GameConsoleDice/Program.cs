/*
* GameConsoleDice (c) Mendz, etmendz. All rights reserved. 
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
using GameLibrary;

namespace GameConsoleDice;

internal static class Program
{
    private static void Main() => new GameConsole<GameUI, GamePlay>(
        "GameConsoleDice", 
        "Mendz, etmendz. All rights reserved.", 
        "A dice guessing game."
        ).Play(); // Play the game!
}