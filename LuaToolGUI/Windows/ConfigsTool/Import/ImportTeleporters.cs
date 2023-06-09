// Zro

using ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStationGUI.Windows.ConfigsTool.Import
{
    public class ImportTeleporters
    {

        public static void Import()
        {
            var existingNpcs = ImportedLists.AllExistingMapNpcId;
            var existingTeleporters = ImportedLists.AllExistingMapTeleporters;
            TeleporterObject tpobj = new();

            foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("at") || o[0].Equals("n_run") &&
                                                                            (o[1].Equals("16") || o[1].Equals("26") ||
                                                                             o[1].Equals("45") || o[1].Equals("301") ||
                                                                             o[1].Equals("132") ||
                                                                             o[1].Equals("5002") ||
                                                                             o[1].Equals("5012"))))
            {
                if (currentPacket.Length > 4 && currentPacket[0] == "n_run")
                {
                    if (!existingNpcs.Contains(int.Parse(currentPacket[4])))
                    {
                        tpobj = null;
                        continue;
                    }

                    tpobj = new()
                    {
                        MapNpcId = int.Parse(currentPacket[4]),
                        Index = short.Parse(currentPacket[2])
                    };
                    continue;
                }

                if (currentPacket.Length <= 5 || currentPacket[0] != "at")
                {
                    continue;
                }

                short map = short.Parse(currentPacket[2]);
                var teleportedimportfile = ImportedLists.TeleporterList.FirstOrDefault(s => s.MapId.Equals(map));
                if (teleportedimportfile == null)
                {
                    ImportedLists.TeleporterList.Add(new()
                    {
                        MapId = map
                    }); 
                    teleportedimportfile = ImportedLists.TeleporterList.FirstOrDefault(s => s.MapId.Equals(map));
                }

                if (tpobj == null)
                {
                    continue;
                }

                tpobj.MapX = short.Parse(currentPacket[3]);
                tpobj.MapY = short.Parse(currentPacket[4]);

                if (existingTeleporters.Any(x => x.MapNpcId == tpobj.MapNpcId && x.Index == tpobj.Index))
                {
                    continue;
                }

                teleportedimportfile.Teleporters.Add(tpobj);
                tpobj = null;
            }
        }
    }
}