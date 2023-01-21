/*
path: Story/FireIsland/02Pyrewatch.cs
fileName: 02Pyrewatch.cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/FireIsland/CoreFireIsland.cs

using Skua.Core.Interfaces;

public class Pyrewatch
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFireIsland FI = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        FI.Pyrewatch();

        Core.SetOptions(false);
    }
}
