[Wiki](https://github.com/etmendz/game-console-dice/wiki)
# GameConsoleDice
How lucky are you? Guess, shake, rattle and roll the dice to find out!

Uses the [GameLibrary](https://github.com/etmendz/game-library/wiki) framework to define the game play, game UI and overall game flow.

## Native AOT
The GameConsoleDice project is native AOT compatible/ready.

Publish profiles (.pubxml) are included for the following Runtime Identifiers (RID):

* For win-x64 (ex. Windows 11): dotnet publish -p:PublishProfile=FolderProfile
* For linux-x64 (ex. WSL+Debian): dotnet publish -p:PublishProfile=FolderProfile1
* For linux-arm64 (ex. Raspberry Pi OS): dotnet publish -p:PublishProfile=FolderProfile2

These can be used as basis/pattern for creating publish profiles that target other RIDs not listed above.

Be sure to run the dotnet publish commands above in the same folder where the GameConsoleDice project is.

Although the GameConsoleDice project is native AOT compatible/ready, publishing to a native AOT build is not required.

## Tools
Scripts are provided to help publish native AOT versions for the following RIDs:

* For win-x64 (ex. Windows 11): publish-nativeaot-win-x64.bat
* For linux-x64 (ex. WSL+Debian): publish-nativeaot-linux-x64.sh
* For linux-arm64 (ex. Raspberry Pi OS): publish-nativeaot-linux-arm64.sh

These can be used as basis/pattern for creating publish scripts that target other RIDs not listed above.

Although the GameConsoleDice project is native AOT compatible/ready, publishing to a native AOT build is not required.

## Artifacts
Build outputs go to the solution's artifacts\ subdirectory:

    game-console-dice\
        artifacts\
            bin\
                GameConsoleDice\
                    debug\
                    release\
                    release_<RID>\*
            obj\
                GameConsoleDice\
                    debug\*
                    publish\<RID>\
                    release\*
                    release_<RID>\*
            publish\GameConsoleDice\release\<RID>
        src\
            GameConsoleDice\
                Properties\PublishProfiles\
        tools\

---

(c) Mendz, etmendz. All rights reserved.