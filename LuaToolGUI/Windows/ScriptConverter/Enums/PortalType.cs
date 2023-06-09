using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStationGUI.Windows.ScriptConverter.Enums
{
    public enum PortalType : sbyte
    {
        MapPortal = -1,
        TsNormal = 0,
        Locked = 1,
        Open = 2,
        Miniland = 3,
        TSEnd = 4,
        TSEndClosed = 5,
        Exit = 6,
        ExitClosed = 7,
        Raid = 8,
        Effect = 9,
        AngelRaid = 10,
        DemonRaid = 11,
        TimeSpace = 12,
        ShopTeleport = 20
    }
}
