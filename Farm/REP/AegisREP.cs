/*
name: AegisREP
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
public class AegisREP
{
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    public CoreAdvanced Adv = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        //Adv.BestGear(GenericGearBoost.dmgAll);
        //Adv.BestGear(GenericGearBoost.rep);
        Farm.AegisREP();

        Core.SetOptions(false);
    }
}
