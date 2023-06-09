// WingsEmu
// 
// Developed by NosWings Team

using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class TeleporterObject
{
    [YamlMember(Alias = "index", ApplyNamingConventions = true)]
    public short Index { get; set; }

    [YamlMember(Alias = "type", ApplyNamingConventions = true)]
    public byte Type { get; set; }

    [YamlIgnore]
    public int MapId { get; set; }

    [YamlMember(Alias = "mapNpcId", ApplyNamingConventions = true)]
    public int MapNpcId { get; set; }

    [YamlMember(Alias = "mapX", ApplyNamingConventions = true)]
    public short MapX { get; set; }

    [YamlMember(Alias = "mapY", ApplyNamingConventions = true)]
    public short MapY { get; set; }
}