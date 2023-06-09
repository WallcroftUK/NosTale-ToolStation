// Zro

using System.Collections.Generic;
using System.Linq;
using ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

namespace ToolStationGUI.Windows.ConfigsTool.Import;

public class ImportPortals
{
    public static void Import()
    {
        var listPortals1 = new List<PortalObject>();
        var listPortals2 = new List<PortalObject>();

        short map = 0;

        var lodPortal = new PortalObject
        {
            SourceMapId = 150,
            SourceX = 172,
            SourceY = 171,
            DestinationMapId = 98,
            Type = -1,
            DestinationX = 6,
            DestinationY = 36,
            IsDisabled = false
        };
        listPortals2.Add(lodPortal);

        var weddingPortal = new PortalObject
        {
            SourceMapId = 2586,
            SourceX = 34,
            SourceY = 54,
            DestinationMapId = 145,
            Type = -1,
            DestinationX = 61,
            DestinationY = 165,
            IsDisabled = false
        };
        listPortals2.Add(weddingPortal);

        var glacerusCavernPortal = new PortalObject
        {
            SourceMapId = 2587,
            SourceX = 42,
            SourceY = 3,
            DestinationMapId = 189,
            Type = -1,
            DestinationX = 48,
            DestinationY = 156,
            IsDisabled = false,
            RaidType = 17
        };
        listPortals2.Add(glacerusCavernPortal);

        foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("c_map") || o[0].Equals("gp")))
        {
            if (currentPacket.Length > 3 && currentPacket[0] == "c_map")
            {
                map = short.Parse(currentPacket[2]);
                continue;
            }

            if (currentPacket.Length <= 4 || currentPacket[0] != "gp") continue;

            var portal = new PortalObject
            {
                SourceMapId = map,
                SourceX = short.Parse(currentPacket[1]),
                SourceY = short.Parse(currentPacket[2]),
                DestinationMapId = short.Parse(currentPacket[3]),
                Type = sbyte.Parse(currentPacket[4]),
                DestinationX = -1,
                DestinationY = -1,
                IsDisabled = false
            };

            if (listPortals1.Any(s =>
                    s.SourceMapId == map && s.SourceX == portal.SourceX && s.SourceY == portal.SourceY &&
                    s.DestinationMapId == portal.DestinationMapId))
                continue;

            listPortals1.Add(portal);
        }

        listPortals1 = listPortals1.OrderBy(s => s.SourceMapId).ThenBy(s => s.DestinationMapId)
            .ThenBy(s => s.SourceY).ThenBy(s => s.SourceX).ToList();
        foreach (var portal in listPortals1)
        {
            var p = listPortals1.Except(listPortals2).FirstOrDefault(s =>
                s.SourceMapId == portal.DestinationMapId && s.DestinationMapId == portal.SourceMapId);
            if (p == null) continue;

            portal.DestinationX = p.SourceX;
            portal.DestinationY = p.SourceY;
            p.DestinationY = portal.SourceY;
            p.DestinationX = portal.SourceX;
            listPortals2.Add(p);
            listPortals2.Add(portal);
        }

        foreach (var portal in listPortals2)
        {
            PortalImportFile PImp = ImportedLists.PortalsList.FirstOrDefault(s => s.MapId.Equals(portal.SourceMapId));
            if (PImp == null)
            {
                ImportedLists.PortalsList.Add(new()
                {
                    MapId = portal.SourceMapId
                });
                PImp = ImportedLists.PortalsList.FirstOrDefault(s => s.MapId.Equals(portal.SourceMapId));
            }
            PImp.Portals.Add(portal);
        }
    }
}