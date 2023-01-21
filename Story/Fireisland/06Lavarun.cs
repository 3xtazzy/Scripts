/*
path: Story/FireIsland/06Lavarun.cs
fileName: 06Lavarun.cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/FireIsland/CoreFireIsland.cs

using Skua.Core.Interfaces;

public class Lavarun
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFireIsland FI = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        FI.Lavarun();

        Core.SetOptions(false);
    }
}
