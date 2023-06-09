// WingsEmu
// 
// Developed by NosWings Team

using System.Collections.Generic;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;

public class PortalImportFile
{
    [YamlMember(Alias = "portals", ApplyNamingConventions = true)]
    public List<PortalObject> Portals { get; set; } = new();
    
    [YamlIgnore]
    public int MapId { get; set; }
}