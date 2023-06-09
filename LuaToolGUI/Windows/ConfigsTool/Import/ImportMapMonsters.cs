// Zro

using System;
using System.Collections.Generic;
using System.Linq;
using ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

namespace ToolStationGUI.Windows.ConfigsTool.Import;

public class ImportMapMonsters
{
    public static void Import()
    {
        short map = 0;
        var mobMvPacketsList = new List<int>(); 

        foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("mv") && o[1].Equals("3"))) 
            if (!mobMvPacketsList.Contains(Convert.ToInt32(currentPacket[2]))) 
                mobMvPacketsList.Add(Convert.ToInt32(currentPacket[2]));

        foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("in") || o[0].Equals("c_map"))) 
        {
            if (currentPacket.Length > 3 && currentPacket[0] == "c_map")
            {
                map = short.Parse(currentPacket[2]);
                continue;
            }
            
            if (currentPacket.Length <= 7 || currentPacket[0] != "in" || currentPacket[1] != "3") 
            { 
                continue;
            }
            
            if (ImportedLists.MapMonstersList.FirstOrDefault(s => s.MapId.Equals(map)) == null)
            {
                ImportedLists.MapMonstersList.Add(new()
                {
                    MapId = map
                });
            }

            MapMonsterImportFile MapMob = ImportedLists.MapMonstersList.FirstOrDefault(s => s.MapId.Equals(map));

            MapMonsterObject monster = new()
            { 
                MapId = map, 
                MonsterVNum = short.Parse(currentPacket[2]), 
                MapMonsterId = int.Parse(currentPacket[3]), 
                MapX = short.Parse(currentPacket[4]), 
                MapY = short.Parse(currentPacket[5]), 
                Position = (byte) (currentPacket[6] == string.Empty ? 0 : byte.Parse(currentPacket[6])), 
                IsDisabled = false
            }; 
            monster.IsMoving = mobMvPacketsList.Contains(monster.MapMonsterId);

            if (MapMob.Monsters.FirstOrDefault(s => s.MapMonsterId.Equals(monster.MapMonsterId)) == null)
            {
                MapMob.Monsters.Add(monster);
                continue;
            }

            var mobDto = MapMob.Monsters.FirstOrDefault(s => s.MapMonsterId == monster.MapMonsterId);
            MapMob.Monsters.Remove(mobDto);
            monster.IsMoving = mobDto.IsMoving; 
            MapMob.Monsters.Add(monster);
        }
    }
}