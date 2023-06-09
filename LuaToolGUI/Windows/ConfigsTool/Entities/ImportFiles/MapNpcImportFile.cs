// WingsEmu
// 
// Developed by NosWings Team

using System.Collections.Generic;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;

public class MapNpcImportFile
{
    [YamlMember(Alias = "mapId", ApplyNamingConventions = true)]
    public int MapId { get; set; }

    [YamlMember(Alias = "npcs", ApplyNamingConventions = true)]
    public List<MapNpcObject> Npcs { get; set; } = new();
}