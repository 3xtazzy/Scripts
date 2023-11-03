/*
name: Complete Elegy of Madness Story, then farm Higure sword
description: This will complete the Astravia story and farm the seasonal Higure sword.
tags: story, quest, elegy-of-madness, darkon, complete, all, higure
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/ElegyofMadness(Darkon)/CoreAstravia.cs

using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Models.Quests;
using Skua.Core.Options;
using System.Collections.Generic;

public class FarmHigure
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv => new();
    private CoreArmyLite Army = new();
    private static CoreArmyLite sArmy = new();
    public CoreAstravia Astravia => new CoreAstravia();

    public string OptionsStorage = "ArmyHigure";
    public List<IOption> Options = new List<IOption>()
    {
        sArmy.player1,
        sArmy.player2,
        sArmy.player3,
        sArmy.player4,
        sArmy.player5,
        sArmy.player6,
        sArmy.packetDelay,
        CoreBots.Instance.SkipOptions
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Core.QuestRewards(7326, 8001, 8257, 8396, 8602, 8641, 8688, 9394));

        Core.SetOptions();

        Higure();
        EndCredits();

        Core.SetOptions(false);
    }

    void Higure()
    {
        Core.PrivateRooms = true;
        Core.PrivateRoomNumber = Army.getRoomNr();

        #region prerequisites 
        Core.Logger("Checking quest completion and Doing / continuing");
        Astravia.CompleteCoreAstravia();
        #endregion prerequisites 

        #region Space check & Adding items to droplog.

        // Define a default dictionary with item names and quantities
        var itemQuantities = new Dictionary<string, int>
            {
                { "Darkon's Receipt", 66 },
                { "La's Gratitude", 66 },
                { "Astravian Medal", 66 },
                { "A Melody", 66 },
                { "Suki's Prestige", 66 },
                { "Ancient Remnant", 66 },
                { "Mourning Flower", 66 },
                { "Unfinished Musical Score", 66 },
                { "Bounty Hunter Dubloon", 222 }
            };

        // Add all items to the drops
        Core.Logger("Adding all drops & requirements to DropLog");

        foreach (int QuestID in new[] { 7326, 8001, 8257, 8396, 8602, 8641, 8688, 9394 })
        {
            Core.EnsureLoad(QuestID)
                .Requirements
                .Concat(Core.EnsureLoad(QuestID).Rewards)
                .ToList()
                .ForEach(item => Core.AddDrop(item.ID));
        }

        // Log how many of each item you have and how many you need
        Core.Logger("Required Items & Quants");
        foreach (var (item, quant) in itemQuantities)
        {
            var quantityInInventory = Bot.Inventory.Contains(item) ? Bot.Inventory.GetQuantity(item) : 0;
            var remainingQuantity = Math.Max(0, quant - quantityInInventory);

            Core.Logger($"{item} - Have: {quantityInInventory}, Need: {remainingQuantity}");
        }

        #endregion Space check & Adding items to droplog.

        #region GetItems
        // Use a switch statement to handle each item
        foreach (var (item, quant) in itemQuantities)
        {
            Army.waitForParty("whitemap", item);

            var quantityInInventory = Bot.Inventory.Contains(item) ? Bot.Inventory.GetQuantity(item) : 0;
            var remainingQuantity = Math.Max(0, quant - quantityInInventory);

            Core.Logger($"{item} - Have: {quantityInInventory}, Need: {remainingQuantity}");

            if (Core.CheckInventory(item, remainingQuantity))
                // Skip to the next case if you already have enough of this item
                continue;


            Core.FarmingLogger(item, quant);
            switch (item)
            {
                case "Darkon's Receipt":
                    Core.EquipClass(ClassType.Solo);
                    Core.RegisterQuests(7326);
                    Army.AggroMonCells("Boss2");
                    Army.AggroMonStart("tercessuinotlim");
                    Army.DivideOnCells("Boss2");
                    while (!Bot.ShouldExit && !Core.CheckInventory("Darkon's Receipt", remainingQuantity))
                        Bot.Combat.Attack("*");
                    Army.AggroMonStop(true);
                    Core.CancelRegisteredQuests();
                    break;
                case "La's Gratitude":
                    Core.RegisterQuests(8001);
                    Core.EquipClass(ClassType.Farm);
                    Army.AggroMonCells("r6", "r7", "r8");
                    Army.AggroMonStart("astravia");
                    Army.DivideOnCells("r6", "r7", "r8");
                    while (!Bot.ShouldExit && !Core.CheckInventory("La's Gratitude", remainingQuantity))
                        Bot.Combat.Attack("*");
                    Army.AggroMonStop(true);
                    Core.CancelRegisteredQuests();
                    break;
                case "Astravian Medal":
                    Core.RegisterQuests(8257);
                    Core.EquipClass(ClassType.Farm);
                    Army.AggroMonCells("r11", "r6", "r3", "r4");
                    Army.AggroMonStart("astraviacastle");
                    Army.DivideOnCells("r11", "r6", "r3", "r4");
                    while (!Bot.ShouldExit && !Core.CheckInventory("Astravian Medal", remainingQuantity))
                        Bot.Combat.Attack("*");
                    Army.AggroMonStop(true);
                    Core.CancelRegisteredQuests();
                    break;
                case "A Melody":
                    Core.RegisterQuests(8396);
                    Core.EquipClass(ClassType.Farm);
                    Army.AggroMonCells("r11", "r3", "r2");
                    Army.AggroMonStart("astraviajudge");
                    Army.DivideOnCells("r11", "r3", "r2");
                    while (!Bot.ShouldExit && !Core.CheckInventory("A Melody", remainingQuantity))
                        Bot.Combat.Attack("*");
                    Army.AggroMonStop(true);
                    Core.CancelRegisteredQuests();
                    break;
                case "Suki's Prestige":
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(8602);
                    Army.AggroMonCells("r4", "r7", "r8", "r6");
                    Army.AggroMonStart("astraviapast");
                    Army.DivideOnCells("r4", "r7", "r8", "r6");
                    while (!Bot.ShouldExit && !Core.CheckInventory("Suki's Prestige", remainingQuantity))
                        Bot.Combat.Attack("*");
                    Army.AggroMonStop(true);
                    Core.CancelRegisteredQuests();
                    break;
                case "Ancient Remnant":
                    Core.EquipClass(ClassType.Solo);
                    Core.RegisterQuests(8641);
                    Army.AggroMonCells("r10a", "r6", "r7");
                    Army.AggroMonStart("firstobservatory");
                    Army.DivideOnCells("r10a", "r6", "r7");
                    while (!Bot.ShouldExit && !Core.CheckInventory("Ancient Remnant", remainingQuantity))
                        if (Bot.Map.PlayerCount < 3)
                        {
                            Core.OneTimeMessage("Ancient Remnant - SoloMode", "Players Missing, Soloing", false);
                            Army.AggroMonStop(true);
                            while (!Bot.ShouldExit && !Core.CheckInventory("Ancient Remnant", remainingQuantity))
                            {
                                Core.EquipClass(ClassType.Farm);
                                Core.HuntMonsterMapID("firstobservatory", 12, "Turret Pieces", 12);
                                Core.HuntMonsterMapID("firstobservatory", 9, "Creature Samples", 6);
                                Core.EquipClass(ClassType.Solo);
                                Core.HuntMonsterMapID("firstobservatory", 13, "Alprecha Observed", 1);
                            }
                        }
                        else Bot.Combat.Attack("*");
                    Army.AggroMonStop(true);
                    Core.CancelRegisteredQuests();
                    break;
                case "Mourning Flower":
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(8688);
                    Army.AggroMonCells("r11", "r9", "r6");
                    Army.AggroMonStart("genesisgarden");
                    Army.DivideOnCells("r11", "r9", "r6");
                    while (!Bot.ShouldExit && !Core.CheckInventory("Mourning Flower", remainingQuantity))
                        Bot.Combat.Attack("*");
                    Army.AggroMonStop(true);
                    Core.CancelRegisteredQuests();
                    break;
                case "Unfinished Musical Score":
                    Core.EquipClass(ClassType.Solo);
                    Army.AggroMonCells("r9");
                    Army.AggroMonStart("theworld");
                    Army.DivideOnCells("r9");
                    while (!Bot.ShouldExit && !Core.CheckInventory("Unfinished Musical Score", remainingQuantity))
                        Bot.Combat.Attack("*");
                    Army.AggroMonStop(true);
                    Core.CancelRegisteredQuests();
                    break;
                case "Bounty Hunter Dubloon":
                    Core.EquipClass(ClassType.Solo);
                    Core.FarmingLogger("Bounty Hunter Dubloon", 222);
                    Core.RegisterQuests(9394);
                    while (!Bot.ShouldExit && !Core.CheckInventory("Bounty Hunter Dubloon", remainingQuantity))
                        Core.HuntMonsterMapID("dreadspace", 48, "Trobble Captured");
                    Bot.Wait.ForPickup("Bounty Hunter Dubloon");
                    Core.CancelRegisteredQuests();
                    break;
            }
        }
        #endregion GetItems

        #region Ensure items are in inv, and buy sword.
        Core.JumpWait();

        // Check the inventory for each item in the dictionary
        foreach (var (item, quant) in itemQuantities)
        {
            if (!Core.CheckInventory(item, quant))
            {
                // Handle the case where an item is missing or doesn't meet the required quantity
                Core.Logger($"Missing or insufficient {item} in inventory.");
            }
        }

        // Buy Higure Sword
        Adv.BuyItem("pirates", 2338, 79817, shopItemID: 12169);
        #endregion Ensure items are in inv, and buy sword.
    }

    void EndCredits()
    {
        Core.Logger($"Made by Jecht And Finished By 🥔Tato🥔");
        //⠄⠄⠄⠄⠄⠄⠄⠄⢀⢀⣴⣿⣿⣷⣶⣤⣄⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⢀⣤⡶⠿⢘⣥⠢⠐⠗⣹⣿⣿⣿⣤⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠘⣅⣂⠹⣪⣭⣥⣶⣿⡿⠿⢭⡻⣿⣷⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⢀⣤⣤⡀⠄⣭⣧⣾⡿⠿⡋⢅⡪⠅⣢⣿⡿⠟⢁⣶⣶⣶⣤⣠⣄⡀⠄⠄
        //⢠⣴⣿⣿⣟⣤⣤⡉⠭⣑⡨⢔⣊⣵⣶⡿⠛⢉⣴⡾⠿⠿⣿⣿⣿⣎⠻⣿⣦⡀
        //⣼⣧⢻⣿⣿⣿⡈⣿⢰⢰⠌⣻⣭⣭⣶⡷⣠⡤⠶⠾⠛⢓⣒⣮⣝⡻⠸⣼⣿⣿
        //⣿⣝⢶⣿⣿⣿⡃⠄⢏⣸⡄⢻⡿⣿⣟⣵⠶⢛⣛⣛⣛⡒⠦⣝⠿⣿⣦⡙⣿⡿
        //⠻⣿⣿⣿⣿⣿⣷⣦⣜⡿⣿⣄⢓⡘⠃⣴⣾⣿⣿⣿⣿⢹⣯⣶⣅⢺⣿⡇⠻⠁
        //⠄⠈⠛⠻⣿⣿⣿⣿⣿⣿⣿⡾⣿⣷⣾⣝⣻⢿⣿⣿⣿⠸⣛⣿⡟⣢⢻⣿⠄⠄
        //⠄⠄⠄⠄⠘⢿⣿⣿⣿⣿⣿⣷⣦⣭⣿⣿⣿⣦⣵⡾⢃⣾⣿⣿⢱⡿⣸⠋⠄⠄
        //⠄⠄⠄⠄⠄⠄⢻⣿⢿⣿⣿⠻⣿⣿⡿⠿⣟⣛⣉⣰⣿⣿⣿⠇⠛⠃⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⠉⠲⣝⣫⣓⡙⣿⣜⣛⣛⣛⣻⡯⠹⠛⠁⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⠙⠛⢻⡈⢿⡿⠟⠛⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
    }

    #region ArmyHunts
    // void ArmyHunt(string? item, int quant, bool isTemp, string AggroMonStart, string[] Cells, int[] RegisterQuests)
    // {
    //     Core.DL_Enable();
    //     Core.PrivateRooms = true;
    //     Core.PrivateRoomNumber = Army.getRoomNr();

    //     if (Bot.Config!.Get<bool>("sellToSync"))
    //         Army.SellToSync(item, quant);

    //     Core.EquipClass(ClassType.Farm);
    //     Core.RegisterQuests(RegisterQuests);

    //     if (item != null && isTemp == false)
    //         Core.AddDrop(item);

    //     Army.waitForParty(AggroMonStart);

    //     Army.AggroMonCells(Cells);
    //     Army.AggroMonStart(AggroMonStart);
    //     Army.DivideOnCells(Cells);

    //     while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
    //         Bot.Combat.Attack("*");

    //     Core.JumpWait();
    //     Army.AggroMonStop(true);

    //     while (!Bot.ShouldExit && Bot.Player.InCombat)
    //     {
    //         Core.JumpWait();
    //         Bot.Sleep(2500);
    //     }
    //     Army.waitForParty(AggroMonStart, item);
    // }

    // void ArmyHunt(string? item, int quant, bool isTemp, string AggroMonStart, string Cell, int RegisterQuest)
    // {
    //     Core.DL_Enable();
    //     Core.PrivateRooms = true;
    //     Core.PrivateRoomNumber = Army.getRoomNr();

    //     if (Bot.Config!.Get<bool>("sellToSync"))
    //         Army.SellToSync(item, quant);

    //     Core.EquipClass(ClassType.Farm);
    //     Core.RegisterQuests(RegisterQuest);

    //     if (item != null && isTemp == false)
    //         Core.AddDrop(item);

    //     Army.waitForParty(AggroMonStart);

    //     Army.AggroMonCells(Cell);
    //     Army.AggroMonStart(AggroMonStart);
    //     Army.DivideOnCells(Cell);

    //     while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
    //         Bot.Combat.Attack("*");

    //     Core.JumpWait();
    //     Army.AggroMonStop(true);

    //     while (!Bot.ShouldExit && Bot.Player.InCombat)
    //     {
    //         Core.JumpWait();
    //         Bot.Sleep(2500);
    //     }
    //     Army.waitForParty(AggroMonStart, item);
    // }
    #endregion ArmyHunts
}