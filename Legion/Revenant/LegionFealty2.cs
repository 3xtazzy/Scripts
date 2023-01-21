/*
path: Legion/Revenant/LegionFealty2.cs
fileName: LegionFealty2.cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/Revenant/CoreLR.cs
//cs_include Scripts/Legion/InfiniteLegionDarkCaster.cs
//cs_include Scripts/Story/Legion/SeraphicWar.cs
using Skua.Core.Interfaces;

public class LegionFealty2
{
    public CoreBots Core => CoreBots.Instance;
    public CoreLR LR = new CoreLR();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        LR.ConquestWreath();

        Core.SetOptions(false);
    }
}
