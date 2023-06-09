// Zro

using ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Events;
using YamlDotNet.Core.Tokens;
using static System.Formats.Asn1.AsnWriter;

namespace ToolStationGUI.Windows.ConfigsTool.Import
{
    public class ImportMapNpcs
    {
        public static void Import()
        {
            int map = 0;
            var npcMvPacketsList = new List<int>();
            var effPacketsDictionary = new Dictionary<int, short>();

            //Mv packets
            foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("mv") && o[1].Equals("2")))
            {
                if (long.Parse(currentPacket[2]) >= 20000) continue;

                if (!npcMvPacketsList.Contains(Convert.ToInt32(currentPacket[2])))
                    npcMvPacketsList.Add(Convert.ToInt32(currentPacket[2]));
            }

            //EffPackets
            foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("eff") && o[1].Equals("2")))
            {
                if (long.Parse(currentPacket[2]) >= 20000) continue;

                if (!effPacketsDictionary.ContainsKey(Convert.ToInt32(currentPacket[2])))
                    effPacketsDictionary.Add(Convert.ToInt32(currentPacket[2]), Convert.ToInt16(currentPacket[3]));
            }

            //ImportMapNpcs
            foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("in") || o[0].Equals("at")))
            {
                if (currentPacket.Length > 5 && currentPacket[0] == "at")
                {
                    map = short.Parse(currentPacket[2]);
                    continue;
                }
                
                if (currentPacket.Length < 7 || currentPacket[0] != "in" || currentPacket[1] != "2") continue;

                var npc = new MapNpcObject
                {
                    MapId = map,
                    PosX = short.Parse(currentPacket[4]),
                    PosY = short.Parse(currentPacket[5]),
                    NpcMonsterVnum = short.Parse(currentPacket[2]),
                };
                var MapNpcImportFile = ImportedLists.MapNpcsList.FirstOrDefault(s => s.MapId.Equals(map));
                if (MapNpcImportFile == null)
                {
                    ImportedLists.MapNpcsList.Add(new()
                    {
                        MapId = map
                    });
                    MapNpcImportFile = ImportedLists.MapNpcsList.FirstOrDefault(s => s.MapId.Equals(map));
                }

                if (MapNpcImportFile.Npcs.FirstOrDefault(s => s.MapId.Equals(npc.MapId) && s.PosX.Equals(npc.PosX) && s.PosY.Equals(npc.PosY) && s.NpcMonsterVnum.Equals(npc.NpcMonsterVnum)) != null)
                {
                    continue;
                }

                if (long.Parse(currentPacket[3]) > 20000) continue;

                npc.MapNpcId = short.Parse(currentPacket[3]);

                if (ImportedLists.AllExistingMapNpcId.Contains(npc.MapNpcId))
                {
                    continue;
                }
                if (effPacketsDictionary.ContainsKey(npc.MapNpcId))
                    npc.Effect = (short) (npc.NpcMonsterVnum == 453 /*Lod*/ ? 855 : effPacketsDictionary[npc.MapNpcId]);

                npc.EffectDelay = npc.Effect != 0 ? 4750 : 0;
                npc.IsMoving = npcMvPacketsList.Contains(npc.MapNpcId);
                npc.Direction = byte.Parse(currentPacket[6]);
                npc.DialogId = short.Parse(currentPacket[9]);
                npc.IsSitting = currentPacket[13] != "1";
                npc.IsDisabled = false;

                TeleporterImportFile tpfile = ImportedLists.TeleporterList.FirstOrDefault(s => s.MapId.Equals(map));
                if (tpfile == null)
                {
                    ImportedLists.TeleporterList.Add(new()
                    {
                        MapId = map
                    });
                    tpfile = ImportedLists.TeleporterList.FirstOrDefault(s => s.MapId.Equals(map));
                }
                // Levers teleporters
                if (npc.MapId == 51 && npc.PosX == 90 && npc.PosY == 9)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 18,
                        MapY = 11
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 51 && npc.PosX == 18 && npc.PosY == 10)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 90,
                        MapY = 10
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 51 && npc.PosX == 38 && npc.PosY == 19)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 29,
                        MapY = 45
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 51 && npc.PosX == 29 && npc.PosY == 43)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 38,
                        MapY = 20
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 85 && npc.PosX == 7 && npc.PosY == 18)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 41,
                        MapY = 33
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 85 && npc.PosX == 40 && npc.PosY == 32)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 7,
                        MapY = 20
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 85 && npc.PosX == 45 && npc.PosY == 44)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 6,
                        MapY = 56
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 85 && npc.PosX == 5 && npc.PosY == 55)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 44,
                        MapY = 45
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 85 && npc.PosX == 10 && npc.PosY == 69)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 44,
                        MapY = 78
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                if (npc.MapId == 85 && npc.PosX == 43 && npc.PosY == 77)
                {
                    TeleporterObject tp = new()
                    {
                        Index = 0,
                        Type = 1,
                        MapNpcId = npc.MapNpcId,
                        MapId = npc.MapId,
                        MapX = 10,
                        MapY = 70
                    };
                    ImportedLists.AllExistingMapTeleporters.Add(tp);
                    tpfile.Teleporters.Add(tp);
                }
                MapNpcImportFile.Npcs.Add(npc);
                ImportedLists.AllMapNpcObjects.Add(npc);
                ImportedLists.AllExistingMapNpcId.Add(npc.MapNpcId);
            }

            //ImportShops
            foreach (var currentPacket in ImportedLists.Packets.Where(o => o.Length > 6 && o[0].Equals("shop") && o[1].Equals("2")))
            {
                short mapnpcid = short.Parse(currentPacket[2]);
                MapNpcObject mapnpcobj = ImportedLists.AllMapNpcObjects.FirstOrDefault(s => s.MapNpcId.Equals(mapnpcid));
                if (mapnpcobj == null) continue;

                var name = string.Empty;
                for (var j = 6; j < currentPacket.Length; j++) name += $"{currentPacket[j]} ";

                name = name.Trim();

                byte menutype = byte.Parse(currentPacket[4]);
                byte shoptype = byte.Parse(currentPacket[5]);
                if (menutype == 1)
                {
                    mapnpcobj.SkillShop = new()
                    {
                        Name = name,
                        MenuType = 1,
                        ShopType = shoptype,
                    };
                    mapnpcobj.SkillShop.ShopTabs = new();
                }
                else
                {
                    mapnpcobj.ItemShop = new()
                    {
                        Name = name,
                        MenuType = 0,
                        ShopType = shoptype,
                    };
                    mapnpcobj.ItemShop.ShopTabs = new();
                }
            }

            //ImportShopsItems
            byte tabid = 0;
            foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("n_inv") || o[0].Equals("shopping")))
            {
                if (currentPacket[0].Equals("n_inv"))
                {
                    int mapnpcid = int.Parse(currentPacket[2]);
                    MapNpcObject mapnpcobj = ImportedLists.AllMapNpcObjects.FirstOrDefault(s => s.MapNpcId.Equals(mapnpcid));
                    if (mapnpcobj == null) continue;

                    if (mapnpcobj.ItemShop == null)
                    {
                        mapnpcobj.ItemShop = new()
                        {
                            Name = mapnpcobj.TempShopName,
                            MenuType = mapnpcobj.TempMenuType,
                            ShopType = mapnpcobj.TempShopType,
                        };
                        mapnpcobj.ItemShop.ShopTabs = new();
                    }

                    MapNpcShopTabObject<MapNpcShopItemObject> Tab = mapnpcobj.ItemShop.ShopTabs.FirstOrDefault(s => s.ShopTabId.Equals(tabid));
                    for (var i = 5; i < currentPacket.Length; i++)
                    {
                        var item = currentPacket[i].Split('.');
                        if (Tab == null)
                        {
                            mapnpcobj.ItemShop.ShopTabs.Add(new()
                            {
                                ShopTabId = tabid,
                                Items = new List<MapNpcShopItemObject>()
                            }); 
                            Tab = mapnpcobj.ItemShop.ShopTabs.FirstOrDefault(s => s.ShopTabId.Equals(tabid));
                        }

                        if (Tab.Items.FirstOrDefault(s => s.ItemVnum.Equals(short.Parse(item[2]))) != null)
                        {
                            continue;
                        }

                        switch (item.Length)
                        {
                            case 5:
                                Tab.Items.Add(new()
                                {
                                    ItemVnum = short.Parse(item[2])
                                });
                                break;
                            case 6:
                                Tab.Items.Add(new()
                                {
                                    ItemVnum = short.Parse(item[2]),
                                    Rarity = sbyte.Parse(item[3]),
                                    Upgrade = byte.Parse(item[4])
                                });
                                break;
                        }
                    }
                    if (mapnpcobj.ItemShop.ShopTabs.Count() < 1)
                    {
                        mapnpcobj.ItemShop = null;
                    }
                    continue;
                }
                if (currentPacket.Length > 3) tabid = byte.Parse(currentPacket[1]);
            }

            //ImportShopsSkills
            tabid = 0;
            foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("n_inv") || o[0].Equals("shopping")))
            {
                if (currentPacket[0].Equals("n_inv"))
                {
                    int mapnpcid = int.Parse(currentPacket[2]);
                    MapNpcObject mapnpcobj = ImportedLists.AllMapNpcObjects.FirstOrDefault(s => s.MapNpcId.Equals(mapnpcid));
                    if (mapnpcobj == null) continue;

                    if (mapnpcobj.SkillShop == null)
                    {
                        mapnpcobj.SkillShop = new()
                        {
                            Name = mapnpcobj.TempShopName,
                            MenuType = mapnpcobj.TempMenuType,
                            ShopType = mapnpcobj.TempShopType,
                        };
                        mapnpcobj.SkillShop.ShopTabs = new();
                    }

                    MapNpcShopTabObject<MapNpcShopSkillObject> Tab = mapnpcobj.SkillShop.ShopTabs.FirstOrDefault(s => s.ShopTabId.Equals(tabid));
                    for (var i = 5; i < currentPacket.Length; i++)
                    {
                        if (!currentPacket[i].Contains(".") && !currentPacket[i].Contains("|"))
                        {
                            if (Tab == null)
                            {
                                mapnpcobj.SkillShop.ShopTabs.Add(new()
                                {
                                    ShopTabId = tabid,
                                    Items = new List<MapNpcShopSkillObject>()
                                });
                                Tab = mapnpcobj.SkillShop.ShopTabs.FirstOrDefault(s => s.ShopTabId.Equals(tabid));
                            }

                            if (Tab.Items.FirstOrDefault(s => s.SkillVnum.Equals(short.Parse(currentPacket[i]))) != null)
                            {
                                continue;
                            }
                            Tab.Items.Add(new()
                            {
                                SkillVnum = short.Parse(currentPacket[i])
                            });
                        }
                    }

                    if (mapnpcobj.SkillShop.ShopTabs.Count() < 1)
                    {
                        mapnpcobj.SkillShop = null;
                    }

                    continue;
                }
                if (currentPacket.Length > 3) tabid = byte.Parse(currentPacket[1]);
            }
        }
    }
}