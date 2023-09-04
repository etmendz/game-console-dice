/*
* GameConsoleDice (c) Mendz, etmendz. All rights reserved. 
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
using System.Reflection;

namespace GameConsoleDice;

/// <summary>
/// Defines a game.
/// </summary>
internal static class Game
{
    /// <summary>
    /// Plays the game.
    /// </summary>
    public static void Play()
    {
        Ready();
        Set();
        Go();
    }

    /// <summary>
    /// Shows the game's splash screen.
    /// </summary>
    private static void Splash()
    {
        Console.CursorVisible = false;
        Console.WriteLine($"GameConsoleDice {Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion} (c) {DateTime.Now.Year} Mendz, etmendz. All rights reserved.");
        Console.WriteLine();
    }

    /// <summary>
    /// Ready?
    /// </summary>
    private static void Ready() => Splash();

    /// <summary>
    /// Set?
    /// </summary>
    private static void Set()
    {
        Console.WriteLine("Press [Enter] to start playing...");
        GameUX.GetKey(ConsoleKey.Enter);
    }

    /// <summary>
    /// Go!
    /// </summary>
    private static void Go()
    {
        GameUI gameUI = new();
        gameUI.Start();
        do
        {
            if (gameUI.GuessAndRoll())
            {
                if (!gameUI.Continue()) break;
            }
        } while (!gameUI.GameOver());
        gameUI.End();
    }
}