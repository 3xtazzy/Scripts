/*
path: Farm/REP/BeastMasterREP[Mem].cs
fileName: BeastMasterREP[Mem].cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;
public class BeastMasterREP
{
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Farm.BeastMasterREP();

        Core.SetOptions(false);
    }
}
