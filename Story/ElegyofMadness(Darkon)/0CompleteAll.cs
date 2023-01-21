/*
path: Story/ElegyofMadness(Darkon)/0CompleteAll.cs
fileName: 0CompleteAll.cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/ElegyofMadness(Darkon)/CoreAstravia.cs
using Skua.Core.Interfaces;

public class CompleteAstravia
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();
    public CoreAstravia Astravia => new CoreAstravia();
    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Astravia.CompleteCoreAstravia();

        Core.SetOptions(false);
    }
}
