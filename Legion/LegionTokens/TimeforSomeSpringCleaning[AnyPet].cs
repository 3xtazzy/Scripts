/*
name: TimeforSomeSpringCleaning[AnyPet]
description: Uses the appropriate pet to farm Legion Tokens
tags: legion, legion token
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
public class TimeforSomeSpringCleaning_AnyPet_
{
    public CoreBots Core => CoreBots.Instance;
    public CoreLegion Legion = new();
    public CoreAdvanced Adv = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Legion.LTShogunParagon();

        Core.SetOptions(false);
    }
}
