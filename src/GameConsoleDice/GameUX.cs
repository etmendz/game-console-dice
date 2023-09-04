/*
* GameConsoleDice (c) Mendz, etmendz. All rights reserved. 
* SPDX-License-Identifier: GPL-3.0-or-later 
*/
namespace GameConsoleDice;

/// <summary>
/// Provides the game UX capabilities for game flow and game play interactions.
/// </summary>
internal static class GameUX
{
    /// <summary>
    /// Gets a key input.
    /// </summary>
    /// <param name="check">The key input to check for.</param>
    /// <returns>The key input.</returns>
    public static ConsoleKey GetKey(ConsoleKey check)
    {
        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;
            // Start conditional section for check values with special rules.
            if (check == ConsoleKey.Y)
            {
                if (key == ConsoleKey.N) break; // Check for N
            }
            // End conditional section for check values with special rules.
            if (key == ConsoleKey.Escape) Environment.Exit(0); // [Esc] exits the app.
        } while (key != check); // Loop until the user presses the check key.
        return key;
    }
}