# MoteMancer Mods

This is basic repository with source code for MoteMancer mods.

At the moment it contains Longer Reach Range which will modify base reach range from 9 to 9999. It's just a basic project that contains basic code for replacing a single value. Main logic file https://github.com/MaciejGorczyca/MoteMancerMods/blob/main/LongerReachRange/LongerReachRange.cs

Modify dependencies/references and file locations for LongerReachRange.csproj manually if they can't be found. Usually these files are needed: `0Harmony.dll`, `BepInEx.dll`, `BepInEx.Harmony.dll`, `UnityEngine.dll`, `UnityEngine.CoreModule.dll`, `Assembly-CSharp.dll`, `Assembly-CSharp-firstpass.dll`

Based partially on https://github.com/akarnokd/ThePlanetCrafterMods structure