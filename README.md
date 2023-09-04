[Wiki](https://github.com/etmendz/game-console-dice/wiki)
# GameConsoleDice
How lucky are you? Guess, shake, rattle and roll the dice to find out!

The game's program flow reads like Play -> Ready -> Set -> Go, which implements the basic game construct:

    Start()
    {
        do
        {
            if (GuessAndRoll())
            {
                if (!Continue()) break;
            }
        } while (!GameOver());
    }
    End();

The game UI is designed to align with the basic game construct described above, thus the methods to Start(), Move(), Continue(), GameOver() and End().

The game UX provides the capabilities to support game flow and game play interactions.

Note that the GameConsoleDice project references the GameLibraryDice project.

## GameLibraryDice
The dice and guessing game is defined in this library.

## Native AOT
The GameConsoleDice and GameLibraryDice projects are native AOT compatible/ready.

Publish profiles (.pubxml) are included for the following Runtime Identifiers (RID):

* For win-x64 (ex. Windows 11): dotnet publish -p:PublishProfile=FolderProfile
* For linux-x64 (ex. WSL+Debian): dotnet publish -p:PublishProfile=FolderProfile1
* For linux-arm64 (ex. Raspberry Pi OS): dotnet publish -p:PublishProfile=FolderProfile2

These can be used as basis/pattern for creating publish profiles that target other RIDs not listed above.

Be sure to run the dotnet publish commands above in the same folder where the GameConsoleDice project is.

Although the GameConsoleDice and GameLibraryDice projects are native AOT compatible/ready, publishing to a native AOT build is not required.

## Tools
Scripts are provided to help publish native AOT versions for the following RIDs:

* For win-x64 (ex. Windows 11): publish-nativeaot-win-x64.bat
* For linux-x64 (ex. WSL+Debian): publish-nativeaot-linux-x64.sh
* For linux-arm64 (ex. Raspberry Pi OS): publish-nativeaot-linux-arm64.sh

These can be used as basis/pattern for creating publish scripts that target other RIDs not listed above.

Although the GameConsoleDice and GameLibraryDice projects are native AOT compatible/ready, publishing to a native AOT build is not required.

## Artifacts
Build outputs go to the solution's artifacts\ subdirectory:

    game-console-dice\
        artifacts\
            bin\
                GameConsoleDice\
                    debug\
                    release\
                    release_<RID>\*
                GameLibraryDice\
                    debug\
                    release\
            obj\
                GameConsoleDice\
                    debug\*
                    publish\<RID>\
                    release\*
                    release_<RID>\*
                GameLibraryDice\
                    debug\*
                    release\*
            publish\GameConsoleDice\release\<RID>
        src\
            GameConsoleDice\
                Properties\PublishProfiles\
            GameLibraryDice\
        tools\

---

(c) Mendz, etmendz. All rights reserved.