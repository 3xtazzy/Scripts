/*
name: DirtyDeedsDoneDirtCheap
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;
public class DirtyDeedsDoneDirtCheap
{
    public CoreBots Core => CoreBots.Instance;
    public CoreNation Nation = new();
    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Nation.DirtyDeedsDoneDirtCheap();

        Core.SetOptions(false);
    }
}
