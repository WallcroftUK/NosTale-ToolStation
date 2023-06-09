// WingsEmu
// 
// Developed by NosWings Team

using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;

public class MapMonsterImportFile
{
    
    [YamlMember(Alias = "mapId", ApplyNamingConventions = true)]
    public int MapId { get; set; }

    [YamlMember(Alias = "monsters", ApplyNamingConventions = true)]
    public List<MapMonsterObject> Monsters { get; set; } = new();
}