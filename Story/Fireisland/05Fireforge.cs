/*
path: Story/FireIsland/05Fireforge.cs
fileName: 05Fireforge.cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/FireIsland/CoreFireIsland.cs

using Skua.Core.Interfaces;

public class Fireforge
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFireIsland FI = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        FI.Fireforge();

        Core.SetOptions(false);
    }
}
