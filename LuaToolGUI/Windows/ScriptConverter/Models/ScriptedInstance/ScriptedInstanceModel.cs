﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ToolStationGUI.Windows.ScriptConverter.Enums;
using ToolStationGUI.Windows.ScriptConverter.Events;
using ToolStationGUI.Windows.ScriptConverter.Events.Quest;
using ToolStationGUI.Windows.ScriptConverter.Objects;

namespace ToolStationGUI.Windows.ScriptConverter.Models.ScriptedInstance
{
    [XmlRoot("Definition"), Serializable]
    public class ScriptedInstanceModel
    {
        #region Properties

        public Globals Globals { get; set; }

        public InstanceEvent InstanceEvents { get; set; }

        #endregion

        #region Methods

        public string ToRaidLuaString()
        {
            RaidType RType = (RaidType)Globals.Id.Value;
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("-- Script automatically generated by ZroIsHere's XmlToLua code\n" +
                               "-- And Wallcroft ToolStation\n" +
                                 "local Map = require('Map')\n" +
                                 "local Monster = require ('Monster')\n" +
                                 "local Event = require('Event')\n" +
                                 "local MapObject = require('MapObject')\n" +
                                 "local Portal = require('Portal')\n" +
                                 "local Raid = require('Raid')\n" +
                                 "local RaidType = require('RaidType')\n" +
                                 "local PortalType = require('PortalType')\n" +
                                 "local RaidFinishType = require('RaidFinishType')\n" +
                                 "local Location = require('Location')\n" +
                                 "local RaidRequirement = require('RaidRequirement')\n" +
                                 "local RaidDrop = require('RaidDrop')\n" +
                                 "local Drop = require('Drop')\n" +
                                 "local RaidReward = require('RaidReward')\n" +
                                 "local RaidBox = require('RaidBox')\n" +
                                 "local RaidBoxRarity = require('RaidBoxRarity')\n" +
                                 "local MonsterWave = require('MonsterWave')\n");

            builder.AppendLine($"local requirement = RaidRequirement.Create()" +
                             $".WithMinimumLevel({(Globals.LevelMinimum.Value > 99 ? 1 : Globals.LevelMinimum.Value)})" +
                             $".WithMaximumLevel({(Globals.LevelMaximum.Value > 99 ? 99 : Globals.LevelMaximum.Value)})" +
                             $".WithMinimumHeroLevel({(Globals.LevelMinimum.Value > 99 ? Globals.LevelMinimum.Value - 99 : 1)})" +
                             $".WithMaximumHeroLevel({(Globals.LevelMaximum.Value > 99 ? Globals.LevelMaximum.Value - 99 : 80)})" +
                             $".WithMinimumParticipant({(Globals.IsIndividual != null ? Globals.IsIndividual.Value ? 1 : 3 : 3)})" +
                             $".WithMaximumParticipant({(Globals.GiantTeam != null ? 30 : Globals.LargeTeam != null ? 20 : 15)})\n");

            builder.AppendLine($"local raidBox = RaidBox.Create().WithVnum({(Globals.GiftItems.First() != null ? Globals.GiftItems.First().VNum : 302)})" +
                             ".WithBoxRarity(RaidBoxRarity.CreateBoxRarity().WithRarity(1).WithChance(1500))" +
                             ".WithBoxRarity(RaidBoxRarity.CreateBoxRarity().WithRarity(2).WithChance(2000))" +
                             ".WithBoxRarity(RaidBoxRarity.CreateBoxRarity().WithRarity(3).WithChance(3000))" +
                             ".WithBoxRarity(RaidBoxRarity.CreateBoxRarity().WithRarity(4).WithChance(2100))" +
                             ".WithBoxRarity(RaidBoxRarity.CreateBoxRarity().WithRarity(5).WithChance(1000))" +
                             ".WithBoxRarity(RaidBoxRarity.CreateBoxRarity().WithRarity(6).WithChance(300))" +
                             ".WithBoxRarity(RaidBoxRarity.CreateBoxRarity().WithRarity(7).WithChance(100))\n");

            builder.AppendLine($"local reward = RaidReward.Create().WithRaidBox(raidBox).WithDefaultReputation()\n");

            string MapsForFinal = "";

            string Portals = "";
            string AddPortals = "";
            string AddMonsters = "";
            string AddObjects = "";
            string OnObjectivesComplete = "";
            string AddBoss = "";
            string AddWaves = "";
            string AddMapBoss = "";
            string AddFinalObjective = "";
            string AddDrop = "";
            string AfterSlowMo = "";
            foreach (var Map in InstanceEvents.CreateMap)
            {
                builder.AppendLine($"local map_0_{Map.Map} = Map.Create().WithMapId({Map.VNum})\n");
                MapsForFinal += $"map_0_{Map.Map},";

                if (Map.OnMoveOnMap != null && Map.OnMoveOnMap.Any(s => s.Wave != null && s.Wave.Length > 0))
                {
                    string TempWaves = "";
                    foreach (var mapWave in Map.OnMoveOnMap.Where(s => s.Wave != null && s.Wave.Length > 0).Select(s => s.Wave))
                    {
                        foreach (var wave in mapWave.Where(s => s.SummonMonster != null && s.SummonMonster.Length > 0))
                        {
                            if (string.IsNullOrEmpty(TempWaves))
                            {
                                TempWaves = $"MonsterWave.CreateWithDelay({wave.Delay}).AsLoop({(wave.RunTimes == 0 ? 1 : wave.RunTimes)})" + ".WithMonsters({";
                            }
                            foreach (var summonMonster in wave.SummonMonster)
                            {
                                if (string.IsNullOrEmpty(TempWaves))
                                {

                                }
                                TempWaves += $"Monster.CreateWithVnum({summonMonster.VNum}).At({summonMonster.PositionX}, {summonMonster.PositionY}).WithMoveToPosition(boss.Position.X, boss.Position.Y),";
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(TempWaves))
                    {
                        AddWaves += $"map_0_{Map.Map}.AddMonsterWaves(" + "{" + TempWaves + "}),})\n";
                    }
                }

                if (Map.SpawnPortal != null)
                {
                    foreach (var portal in Map.SpawnPortal)
                    {
                        string portalvarname = $"portal_{Map.Map}_{portal.IdOnMap}";
                        Portals += $"local {portalvarname} = Portal{(portal.Type == 1 ? ".CreateLocked()" : ".Create(PortalType.Open)")}.From(map_0_{Map.Map}, {portal.PositionX}, {portal.PositionY}).To(map_0_{portal.ToMap}, {portal.ToX}, {portal.ToY})\n";
                        AddPortals += $"map_0_{Map.Map}.AddPortal({portalvarname})\n";
                    }
                }

                if (Map.SummonMonster != null)
                {
                    string mapmonsters = "";
                    foreach (var monster in Map.SummonMonster)
                    {
                        string strmon = $"Monster.CreateWithVnum({monster.VNum}).At({monster.PositionX}, {monster.PositionY}){(monster.IsTarget ? ".AsObjective()" : monster.IsBoss ? ".AsBoss()" : "")}";
                        if (!monster.IsBoss)
                        {
                            mapmonsters += $"{strmon},";
                            continue;
                        }

                        AddMapBoss = $"map_0_{Map.Map}.AddMonster(boss)";
                        AddFinalObjective = $"map_0_{Map.Map}.OnObjectivesCompleted(" + "{Event.FinishRaid(RaidFinishType.MissionClear)})";
                        AddBoss = $"local boss = {strmon}\n";
                        AddDrop += "local drops = RaidDrop.Create(boss)";
                        string beforegold = "";
                        if (monster.OnDeath != null && monster.OnDeath.ThrowItem != null)
                        {
                            foreach (var item in monster.OnDeath.ThrowItem)
                            {
                                if (item.VNum.Equals(1046))
                                {
                                    AddDrop += $".WithGoldRange({item.MinAmount}, {item.MaxAmount}).WithGoldStackCount({item.PackAmount})";
                                    continue;
                                }

                                if (string.IsNullOrEmpty(beforegold))
                                {
                                    beforegold = ".WithDrops({";
                                }

                                beforegold += $"Drop.Create({item.VNum}, 1),";
                            }
                        }

                        AddDrop += beforegold + $"{(string.IsNullOrEmpty(beforegold) ? ".WithGoldRange(1000, 5000).WithGoldStackCount(15)" : "})")}" + $"{(string.IsNullOrEmpty(beforegold) ? "" : ".WithDropsStackCount(15)")}\n";

                        AfterSlowMo = $"map_0_{Map.Map}.AfterSlowMotion(" + "{" + "Event.ThrowRaidDrops(drops)" + "})\n";
                    }

                    if (!string.IsNullOrEmpty(mapmonsters))
                    {
                        AddMonsters += $"map_0_{Map.Map}.AddMonsters(" + "{" + mapmonsters + "})\n";
                    }
                }

                if (Map.OnLockerOpen != null && Map.SpawnPortal != null)
                {
                    OnObjectivesComplete += $"map_0_{Map.Map}.OnObjectivesCompleted(" + "{" + $"Event.OpenPortal(portal_{Map.OnLockerOpen.ChangePortalType.IdOnMap})" + "})\n";
                }

                if (Map.SpawnButton != null)
                {
                    string spawnbuttons = "";
                    foreach (var button in Map.SpawnButton)
                    {
                        if (button.OnEnable != null)
                        {
                            if (button.OnEnable.Teleport != null)
                            {
                                spawnbuttons += $"MapObject.CreateTeleportLever().At({button.PositionX}, {button.PositionY}).OnSwitch(" + "{" + $"Event.Teleport(map_0_{Map.Map}, {button.OnEnable.Teleport.PositionX}, {button.OnEnable.Teleport.PositionY}, {button.OnEnable.Teleport.DestinationX}, {button.OnEnable.Teleport.DestinationY}, 4)" + "}),";
                            }
                        }

                        if (button.OnFirstEnable != null)
                        {
                            spawnbuttons +=
                                $"MapObject.CreateTrigger().At({button.PositionX}, {button.PositionY}){(button.OnFirstEnable.RefreshRaidGoals != null ? ".AsRaidObjective()" : "")}";

                            if (button.OnFirstEnable.SummonMonster == null && button.OnFirstEnable.Teleport == null)
                            {
                                spawnbuttons += ",";
                                continue;
                            }

                            spawnbuttons += ".OnTrigger({";

                            if (button.OnFirstEnable.SummonMonster != null)
                            {
                                string monsumm = "";
                                foreach (var summonMonster in button.OnFirstEnable.SummonMonster)
                                {
                                    monsumm +=
                                        $"Monster.CreateWithVnum({summonMonster.VNum}).At({summonMonster.PositionX}, {summonMonster.PositionY}),";
                                }

                                spawnbuttons += "Event.MonsterSummon({" + monsumm + "}),";
                            }

                            if (button.OnFirstEnable.ChangePortalType != null)
                            {
                                foreach (var changePortalType in button.OnFirstEnable.ChangePortalType)
                                {
                                    spawnbuttons += $"Event.OpenPortal(portal_{changePortalType.Map}_{changePortalType.IdOnMap}),";
                                }
                            }

                            spawnbuttons += "}),";
                        }
                    }

                    if (!string.IsNullOrEmpty(spawnbuttons))
                    {
                        AddObjects += $"map_0_{Map.Map}.AddObjects(" + "{" + spawnbuttons + "})\n";
                    }
                }
            }
            builder.AppendLine(Portals);
            builder.AppendLine(AddPortals);
            builder.AppendLine(AddMonsters);
            builder.AppendLine(AddObjects);
            builder.AppendLine(OnObjectivesComplete);
            builder.AppendLine(AddBoss);
            builder.AppendLine(AddDrop);
            builder.AppendLine(AddWaves);
            builder.AppendLine(AddMapBoss);
            builder.AppendLine(AddFinalObjective);
            builder.AppendLine(AfterSlowMo);
            builder.AppendLine($"local raid = Raid.Create(RaidType.{RType.ToString()})" +
                             ".WithMaps({" + $"{MapsForFinal}" + "})" +
                             $".WithSpawn(Location.InMap(map_0_0).At({Globals.StartX.Value}, {Globals.StartY.Value}))" +
                             $".WithRequirement(requirement)" +
                             $".WithReward(reward)" +
                             $".WithDuration(40*60)");
            builder.AppendLine("return raid");

            return builder.ToString();
        }

        public string ToTsLuaString()
        {
            #region Required hardcode 

            StringBuilder builder = new();

            builder.AppendLine($"""
                -- Script automatically generated by ZroIsHere's XmlToLua tool
                -- Replace all %REPLACE for the value in the case
                local Map = require('Map')
                local Monster = require('Monster')
                local Event = require('Event')
                local MapObject = require('MapObject')
                local MapNpc = require('MapNpc')
                local Portal = require('Portal')
                local Location = require('Location')
                local TimeSpace = require('TimeSpace')
                local PortalType = require("PortalType")
                local PortalMinimapOrientation = require('PortalMinimapOrientation')
                local TimeSpaceObjective = require('TimeSpaceObjective')
                local TimeSpaceTaskType = require('TimeSpaceTaskType')
                local TimeSpaceTask = require('TimeSpaceTask')
                local TimeSpaceFinishType = require('TimeSpaceFinishType')

                local objectives = TimeSpaceObjective.Create()
                    .WithGoToExit(){( InstanceEvents.CreateMap.Any(s => s.SummonNpc != null && s.SummonNpc.Any(x => x.IsProtected)) ? ".WithProtectNPC()" : "" )}

                """);

            #endregion

            #region Minimap inside file

            builder.AppendLine("--     [ 0][ 1][ 2][ 3][ 4][ 5][ 6][ 7][ 8][ 9][10]");
            for (byte i = 0; i < 12; i++)
            {
                List<byte> list = new List<byte>();
                foreach (var Map in InstanceEvents.CreateMap.Where(s => s.IndexY.Equals(i)))
                {
                    list.Add(Map.IndexX);
                }
                string GridLine = $"-- [{(i < 10 ? $" {i}" : i)}]";
                for (byte x = 0; x < 11; x++)
                {
                    GridLine += $"[{(list.Contains(x) ? $"{(InstanceEvents.CreateMap.First(s => s.IndexY.Equals(i) && s.IndexX.Equals(x)).Map == 1 ? "ST" : "XX")}" : "  ")}]";
                }
                builder.AppendLine(GridLine);
            }
            builder.AppendLine("");

            #endregion

            string MapsForTsVar = "";
            StringBuilder MapsVars = new();
            StringBuilder PortalsVars = new();
            StringBuilder MapPortalsVars = new();
            List<StringBuilder> MapsConfigs = new();

            foreach (var Map in InstanceEvents.CreateMap)
            {
                #region Map var

                TimeSpaceTaskType TaskType = TimeSpaceTaskType.None;
                string TaskClock = "";
                string TaskText = "";//.WithTaskText("sasda")
                string StartDialog = ".WithNoDialogTaskStart()";//.WithOnStartDialog(8004)
                string FinishDialog = "";//.WithOnFinishDialog(8004)
                string StartShout = "";//.WithOnStartShout("TS_0_TEXT_0")
                string FinishShout = "";//.WithOnFinishShout("TS_0_TEXT_0")

                if (Map.OnCharacterDiscoveringMap != null)
                {
                    if (Map.OnCharacterDiscoveringMap.SendMessage != null)
                    {
                        StartShout = $".WithTaskText(\"{Map.OnCharacterDiscoveringMap.SendMessage.First().Value}\")";
                    }

                    if (Map.OnCharacterDiscoveringMap.NpcDialog != null)
                    {
                        StartDialog = $".WithOnStartDialog({Map.OnCharacterDiscoveringMap.NpcDialog.First().Value})";
                    }


                    if ((Map.SpawnButton != null && Map.SpawnButton.Any(s => s.OnFirstEnable != null && s.OnFirstEnable.SummonMonster != null)) ||
                        Map.OnCharacterDiscoveringMap.SummonMonster != null ||
                        Map.SummonMonster != null)
                    {
                        TaskType = TimeSpaceTaskType.KillAllMonsters;
                    }
                }

                if (Map.OnMapClean != null) 
                {
                    if (Map.OnMapClean.NpcDialog != null)
                    {
                        FinishDialog = $".WithOnFinishDialog({Map.OnMapClean.NpcDialog.First().Value})";
                    }
                }

                if (Map.SpawnButton != null && 
                    Map.SpawnButton.Any(s => s.OnFirstEnable != null && (s.OnFirstEnable.ChangePortalType != null || (
                        s.OnFirstEnable.SummonMonster != null && 
                            s.OnFirstEnable.SummonMonster.Any(x => x.OnDeath != null && 
                            x.OnDeath.NpcDialog != null)))))
                {
                    SpawnButton MapObject = Map.SpawnButton.FirstOrDefault(s => s.OnFirstEnable != null && s.OnFirstEnable.NpcDialog != null || (s.OnFirstEnable.SummonMonster != null && s.OnFirstEnable.SummonMonster.Any(x => x.OnDeath != null && x.OnDeath.NpcDialog != null)));
                    if (MapObject != null)
                    {
                        bool Assigned = false;

                        if (MapObject.OnFirstEnable.NpcDialog != null)
                        {
                            FinishDialog = $".WithOnFinishDialog({MapObject.OnFirstEnable.NpcDialog.First().Value})";
                            Assigned = true;
                        }

                        if (!Assigned)
                        {
                            FinishDialog = $".WithOnFinishDialog({MapObject.OnFirstEnable.SummonMonster.First(s => s.OnDeath != null && s.OnDeath.NpcDialog != null).OnDeath.NpcDialog.First().Value})";
                        }
                    }
                }

                if (Map.GenerateClock != null)
                {
                    TaskClock = $", {Map.GenerateClock.Value / 10}";
                }

                if (Map.GenerateMapClock != null)
                {
                    TaskClock = $", {Map.GenerateMapClock.Value / 10}";
                }

                if (string.IsNullOrEmpty(FinishDialog) && Map.OnCharacterDiscoveringMap != null && 
                    Map.OnCharacterDiscoveringMap.NpcDialog != null && 
                    Map.OnCharacterDiscoveringMap.NpcDialog.Count() > 1)
                {
                    FinishDialog = $".WithOnFinishDialog({Map.OnCharacterDiscoveringMap.NpcDialog[1].Value})";
                }

                string MapVarName = $"map_{Map.Map}";
                MapsVars.AppendLine($"""
                    local {MapVarName} = Map.Create().WithMapId({Map.VNum}).SetMapCoordinates({Map.IndexX}, {Map.IndexY}).WithTask(
                        TimeSpaceTask.Create(TimeSpaceTaskType.{TaskType}{TaskClock}){TaskText}{StartDialog}{FinishDialog}{StartShout}{FinishShout}
                    )
                    """);
                MapsForTsVar += $"{MapVarName}, ";

                #endregion

                #region Portals

                if (Map.SpawnPortal != null)
                {
                    foreach (var Portal in Map.SpawnPortal)
                    {
                        #region Portal var

                        string PortalVarName = $"portal_{Map.Map}_to_{Portal.ToMap}";
                        PortalMinimapOrientation orientation = PortalMinimapOrientation.North;

                        if (Portal.PositionX - Portal.ToX == 1)
                        {
                            orientation = PortalMinimapOrientation.West;
                        }

                        if (Portal.PositionX - Portal.ToX == -1)
                        {

                            orientation = PortalMinimapOrientation.East;
                        }

                        if (Portal.PositionY - Portal.ToY == -1)
                        {
                            orientation = PortalMinimapOrientation.South;
                        }

                        PortalsVars.AppendLine($"""
                    local {PortalVarName} = Portal.Create(PortalType.{(PortalType)Portal.Type}).From(map_{Map.Map}, {Portal.PositionX}, {Portal.PositionY}).To(map_{Portal.ToMap}, {Portal.ToX}, {Portal.ToY}).MinimapOrientation(PortalMinimapOrientation.{orientation})
                    """);

                        #endregion

                        #region Map portal var

                        MapPortalsVars.AppendLine($"{MapVarName}.AddPortal({PortalVarName})");

                        #endregion
                    }
                }

                #endregion

                #region Map config

                StringBuilder MapConfig = new();
                bool StartWithObject = false;

                #region Map npcs

                StringBuilder MapNpcsContent = new();

                if (Map.SummonNpc != null)
                {
                    foreach (var Npc in Map.SummonNpc)
                    {
                        MapNpcsContent.AppendLine($"    MapNpc.CreateNpcWithVnum({Npc.VNum}).At({Npc.PositionX}, {Npc.PositionY}).Facing(6),");
                    }
                }

                if (!string.IsNullOrEmpty(MapNpcsContent.ToString()))
                {
                    MapConfig.AppendLine($$"""
                    {{MapVarName}}.AddNpcs({
                    {{MapNpcsContent.ToString()}}
                    })
                    """);
                }

                #endregion

                #region Map monsters

                StringBuilder MapMonstersContent = new();//TODO: Do this in a void

                if (Map.OnCharacterDiscoveringMap != null && Map.OnCharacterDiscoveringMap.SummonMonster != null)
                {
                    Dictionary<int, SummonMonster> OnDeathDict = new();
                    int i = 1;
                    foreach (var Monster in Map.OnCharacterDiscoveringMap.SummonMonster)
                    {
                        MapMonstersContent.AppendLine($"    Monster.CreateWithVnum({Monster.VNum}).At({Monster.PositionX}, {Monster.PositionY}).Facing(1),");
                        if (Monster.OnDeath != null && Monster.OnDeath.SummonMonster != null)
                        {
                            foreach (var OnDeathMonster in Monster.OnDeath.SummonMonster)
                            {
                                OnDeathDict.Add(i, OnDeathMonster);
                                i++;
                            }
                        }
                    }
                    moreondeath:
                    Dictionary<int, SummonMonster> MoreOnDeath = new();
                    foreach (var Monster in OnDeathDict)
                    {
                        OnDeathDict.Remove(Monster.Key);
                        MapMonstersContent.AppendLine($"    Monster.CreateWithVnum({Monster.Value.VNum}).At({Monster.Value.PositionX}, {Monster.Value.PositionY}).Facing(1).SpawnAfterMobsKilled({Monster.Key}),");
                        if (Monster.Value.OnDeath != null && Monster.Value.OnDeath.SummonMonster != null)
                        {
                            foreach (var OnDeathMonster in Monster.Value.OnDeath.SummonMonster)
                            {
                                MoreOnDeath.Add(i, OnDeathMonster);
                                i++;
                            }
                        }
                    }

                    if (MoreOnDeath.Count > 0)
                    {
                        OnDeathDict = MoreOnDeath;
                        goto moreondeath;
                    }
                }

                if (Map.SummonMonster != null)
                {
                    Dictionary<int, SummonMonster> OnDeathDict = new();
                    int i = 1;
                    foreach (var Monster in Map.SummonMonster)
                    {
                        MapMonstersContent.AppendLine($"    Monster.CreateWithVnum({Monster.VNum}).At({Monster.PositionX}, {Monster.PositionY}).Facing(1),");
                        if (Monster.OnDeath != null && Monster.OnDeath.SummonMonster != null)
                        {
                            foreach (var OnDeathMonster in Monster.OnDeath.SummonMonster)
                            {
                                OnDeathDict.Add(i, OnDeathMonster);
                                i++;
                            }
                        }
                    }
                    moreondeath:
                    Dictionary<int, SummonMonster> MoreOnDeath = new();
                    foreach (var Monster in OnDeathDict)
                    {
                        OnDeathDict.Remove(Monster.Key);
                        MapMonstersContent.AppendLine($"    Monster.CreateWithVnum({Monster.Value.VNum}).At({Monster.Value.PositionX}, {Monster.Value.PositionY}).Facing(1).SpawnAfterMobsKilled({Monster.Key}),");
                        if (Monster.Value.OnDeath != null && Monster.Value.OnDeath.SummonMonster != null)
                        {
                            foreach (var OnDeathMonster in Monster.Value.OnDeath.SummonMonster)
                            {
                                MoreOnDeath.Add(i, OnDeathMonster);
                                i++;
                            }
                        }
                    }

                    if (MoreOnDeath.Count > 0)
                    {
                        OnDeathDict = MoreOnDeath;
                        goto moreondeath;
                    }
                }

                if (Map.SpawnButton != null && Map.SpawnButton.Any(s => s.OnFirstEnable != null && s.OnFirstEnable.SummonMonster != null))
                {
                    foreach(var MapObject in Map.SpawnButton.Where(s => s.OnFirstEnable != null && s.OnFirstEnable.SummonMonster != null))
                    {
                        Dictionary<int, SummonMonster> OnDeathDict = new();
                        int i = 1;
                        foreach (var Monster in MapObject.OnFirstEnable.SummonMonster)
                        {
                            MapMonstersContent.AppendLine($"    Monster.CreateWithVnum({Monster.VNum}).At({Monster.PositionX}, {Monster.PositionY}).Facing(1).SpawnAfterTaskStart(),");
                            if (Monster.OnDeath != null && Monster.OnDeath.SummonMonster != null)
                            {
                                foreach (var OnDeathMonster in Monster.OnDeath.SummonMonster)
                                {
                                    OnDeathDict.Add(i, OnDeathMonster);
                                    i++;
                                }
                            }
                        }
                    moreondeath:
                        Dictionary<int, SummonMonster> MoreOnDeath = new();
                        foreach (var Monster in OnDeathDict)
                        {
                            OnDeathDict.Remove(Monster.Key);
                            MapMonstersContent.AppendLine($"    Monster.CreateWithVnum({Monster.Value.VNum}).At({Monster.Value.PositionX}, {Monster.Value.PositionY}).Facing(1).SpawnAfterMobsKilled({Monster.Key}).SpawnAfterTaskStart(),");
                            if (Monster.Value.OnDeath != null && Monster.Value.OnDeath.SummonMonster != null)
                            {
                                foreach (var OnDeathMonster in Monster.Value.OnDeath.SummonMonster)
                                {
                                    MoreOnDeath.Add(i, OnDeathMonster);
                                    i++;
                                }
                            }
                        }

                        if (MoreOnDeath.Count > 0)
                        {
                            OnDeathDict = MoreOnDeath;
                            goto moreondeath;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(MapMonstersContent.ToString()))
                {
                    MapConfig.AppendLine($$"""
                    {{MapVarName}}.AddMonsters({
                    {{MapMonstersContent.ToString()}}
                    })
                    """);
                }

                #endregion

                #region Map objects

                StringBuilder MapObjectsContent = new();

                if (Map.SpawnButton != null)
                {
                    foreach(var Button in Map.SpawnButton)
                    {
                        StringBuilder ObjectEvents = new();
                        MapObjectType ObjectType = (MapObjectType)Button.VNumDisabled;

                        if (Button.OnFirstEnable != null && 
                            Button.OnFirstEnable.SummonMonster != null && 
                            Button.OnFirstEnable.SummonMonster.Any(s => s.OnDeath != null && s.OnDeath.ChangePortalType != null))
                        {
                            ObjectEvents.AppendLine($"  Event.TryStartTaskForMap({MapVarName}),");
                            StartWithObject = true;
                        }

                        if (!string.IsNullOrEmpty(ObjectEvents.ToString()))
                        {
                            MapObjectsContent.AppendLine($$"""
                                MapObject.Create{{ObjectType}}().At({{Button.PositionX}}, {{Button.PositionY}}).OnTrigger({
                                {{ObjectEvents}}
                                }),
                            """);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(MapObjectsContent.ToString()))
                {
                    MapConfig.AppendLine($$"""
                        {{MapVarName}}.AddObjects({
                        {{MapObjectsContent.ToString()}}
                        })
                        """);
                }

                #endregion

                #region Map join

                StringBuilder MapJoinContent = new();

                if (!StartWithObject)
                {
                    MapJoinContent.AppendLine($"    Event.TryStartTaskForMap({MapVarName}),");
                }

                if (Map.OnCharacterDiscoveringMap != null && Map.OnCharacterDiscoveringMap.ChangePortalType != null)
                {
                    foreach (var Portal in Map.OnCharacterDiscoveringMap.ChangePortalType)
                    {
                        string PortalVar = $"Event.OpenPortal(portal_{Map.Map}_to_{Map.SpawnPortal.FirstOrDefault(s => s.IdOnMap.Equals(Portal.IdOnMap)).ToMap})";
                        if (!MapJoinContent.ToString().Contains(PortalVar))
                        {
                            MapJoinContent.AppendLine($"    {PortalVar}, -- Probably this take error some times if the portal to open is in other map");
                        }
                    }
                }

                if (!string.IsNullOrEmpty(MapJoinContent.ToString()))
                {
                    MapConfig.AppendLine($$"""
                        {{MapVarName}}.OnMapJoin({
                        {{MapJoinContent.ToString()}}
                        })
                        """);
                }

                #endregion

                #region Task finish

                StringBuilder TaskFinishContent = new();
                if (Map.OnMapClean != null && Map.OnMapClean.ChangePortalType != null)
                {
                    foreach (var Portal in Map.OnMapClean.ChangePortalType)
                    {
                        string PortalVar = $"Event.OpenPortal(portal_{Map.Map}_to_{Map.SpawnPortal.FirstOrDefault(s => s.IdOnMap.Equals(Portal.IdOnMap)).ToMap})";
                        if (!TaskFinishContent.ToString().Contains(PortalVar))
                        {
                            TaskFinishContent.AppendLine($" {PortalVar}, -- Probably this take error some times if the portal to open is in other map");
                        }
                    }
                }

                if (Map.SpawnButton != null && Map.SpawnButton.Any(s => s.OnFirstEnable != null && (s.OnFirstEnable.ChangePortalType != null || s.OnFirstEnable.SummonMonster != null && s.OnFirstEnable.SummonMonster.Any(x => x.OnDeath != null && x.OnDeath.ChangePortalType != null))))
                {
                    bool Assigned = false;

                    if (Map.SpawnButton.FirstOrDefault(s => s.OnFirstEnable != null && s.OnFirstEnable.ChangePortalType != null) != null)
                    {
                        foreach (var Portal in Map.SpawnButton.First(s => s.OnFirstEnable != null && s.OnFirstEnable.ChangePortalType != null).OnFirstEnable.ChangePortalType)
                        {
                            string PortalVar = $"Event.OpenPortal(portal_{Map.Map}_to_{Map.SpawnPortal.FirstOrDefault(s => s.IdOnMap.Equals(Portal.IdOnMap)).ToMap})";
                            if (!TaskFinishContent.ToString().Contains(PortalVar))
                            {
                                TaskFinishContent.AppendLine($" {PortalVar}, -- Probably this take error some times if the portal to open is in other map");
                            }
                        }
                        Assigned = true;
                    }

                    if (!Assigned)
                    {
                        foreach (var Portal in Map.SpawnButton.First(s => s.OnFirstEnable != null && s.OnFirstEnable.SummonMonster != null && s.OnFirstEnable.SummonMonster.Any(x => x.OnDeath != null && x.OnDeath.ChangePortalType != null)).OnFirstEnable.SummonMonster.First(s => s.OnDeath != null && s.OnDeath.ChangePortalType != null).OnDeath.ChangePortalType)
                        {
                            string PortalVar = $"Event.OpenPortal(portal_{Map.Map}_to_{Map.SpawnPortal.FirstOrDefault(s => s.IdOnMap.Equals(Portal.IdOnMap)).ToMap})";
                            if (!TaskFinishContent.ToString().Contains(PortalVar))
                            {
                                TaskFinishContent.AppendLine($" {PortalVar}, -- Probably this take error some times if the portal to open is in other map");
                            }
                        }
                    }
                }

                if (Map.OnMapClean != null && Map.OnMapClean.ChangePortalType != null)
                {
                    foreach (var Portal in Map.OnMapClean.ChangePortalType)
                    {
                        string PortalVar = $"Event.OpenPortal(portal_{Map.Map}_to_{Map.SpawnPortal.FirstOrDefault(s => s.IdOnMap.Equals(Portal.IdOnMap)).ToMap})";
                        if (!TaskFinishContent.ToString().Contains(PortalVar))
                        {
                            TaskFinishContent.AppendLine($" {PortalVar}, -- Probably this take error some times if the portal to open is in other map");
                        }
                    }
                }

                if (!string.IsNullOrEmpty(TaskFinishContent.ToString()))//
                {
                    MapConfig.AppendLine($$"""
                        {{MapVarName}}.OnTaskFinish({
                        {{TaskFinishContent.ToString()}}
                        })
                        """);
                }

                #endregion

                #region Task fail

                StringBuilder TaskFailContent = new();

                if (TaskType == TimeSpaceTaskType.KillAllMonsters && !string.IsNullOrEmpty(TaskClock))
                {
                    TaskFailContent.AppendLine($"   Event.FinishTimeSpace(TimeSpaceFinishType.{TimeSpaceFinishType.TIME_IS_UP}),");
                }

                if (!string.IsNullOrEmpty(TaskFailContent.ToString()))
                {
                    MapConfig.AppendLine($$"""
                        {{MapVarName}}.OnTaskFail({
                        {{TaskFailContent.ToString()}}
                        })
                        """);
                }

                #endregion

                MapsConfigs.Add(MapConfig);

                #endregion
            }

            builder.AppendLine(MapsVars.ToString());
            builder.AppendLine(PortalsVars.ToString());
            builder.AppendLine(MapPortalsVars.ToString());
            MapsConfigs.ForEach(delegate(StringBuilder config)
            {
                builder.AppendLine(config.ToString());
            });

            #region TsVar

            builder.AppendLine($$"""
                local ts = TimeSpace.Create(%REPLACE)  -- TimeSpace ID
                    .SetMaps({{{MapsForTsVar}}})
                    .SetSpawn(Location.InMap(map_1).At(%REPLACE))  -- Coordenates x, y of the start
                    .SetLives({{Globals.Lives.Value}})
                    .SetObjectives(objectives)
                    .SetDurationInSeconds(300) -- Duration of the timespace. Default 300
                    .SetBonusPointItemDropChance(5000) -- Drop chance of points in ts. Default 5000
                return ts
                """);

            #endregion

            return builder.ToString();
        }

        #endregion
    }
}