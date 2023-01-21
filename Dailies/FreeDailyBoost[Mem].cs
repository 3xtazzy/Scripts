/*
path: Dailies/FreeDailyBoost[Mem].cs
fileName: FreeDailyBoost[Mem].cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;

public class FreeDailyBoost
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreDailies Daily = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Daily.FreeDailyBoost();

        Core.SetOptions(false);
    }
}
