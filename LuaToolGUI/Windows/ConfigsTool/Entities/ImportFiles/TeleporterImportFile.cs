// WingsEmu
// 
// Developed by NosWings Team

using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;

public class TeleporterImportFile
{
    [YamlMember(Alias = "map_id", ApplyNamingConventions = true)]
    public int MapId { get; set; }

    [YamlMember(Alias = "teleporters", ApplyNamingConventions = true)]
    public List<TeleporterObject> Teleporters { get; set; } = new();
}