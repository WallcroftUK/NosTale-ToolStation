// WingsEmu
// 
// Developed by NosWings Team

using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class PortalObject
{
    [YamlMember(Alias = "destinationMapId", ApplyNamingConventions = true)]
    public int DestinationMapId { get; set; }

    [YamlMember(Alias = "destinationMapX", ApplyNamingConventions = true)]
    public short DestinationX { get; set; }

    [YamlMember(Alias = "destinationMapY", ApplyNamingConventions = true)]
    public short DestinationY { get; set; }

    [YamlMember(Alias = "isDisabled", ApplyNamingConventions = true)]
    public bool IsDisabled { get; set; }

    [YamlMember(Alias = "sourceMapId", ApplyNamingConventions = true)]
    public int SourceMapId { get; set; }

    [YamlMember(Alias = "sourceMapX", ApplyNamingConventions = true)]
    public short SourceX { get; set; }

    [YamlMember(Alias = "sourceMapY", ApplyNamingConventions = true)]
    public short SourceY { get; set; }

    [YamlMember(Alias = "type", ApplyNamingConventions = true)]
    public short Type { get; set; }

    [YamlMember(Alias = "raidType", ApplyNamingConventions = true)]
    public short? RaidType { get; set; }

    [YamlMember(Alias = "mapNameId", ApplyNamingConventions = true)]
    public short? MapNameId { get; set; }
}