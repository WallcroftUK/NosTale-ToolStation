// WingsEmu
// 
// Developed by NosWings Team

using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class MapMonsterObject
{
    
    [YamlIgnore]
    public int MapId { get; set; }

    [YamlMember(Alias = "mapMonsterId", ApplyNamingConventions = true)]
    public int MapMonsterId { get; set; }

    [YamlMember(Alias = "vnum", ApplyNamingConventions = true)]
    public int MonsterVNum { get; set; }

    [YamlMember(Alias = "mapX", ApplyNamingConventions = true)]
    public short MapX { get; set; }

    [YamlMember(Alias = "mapY", ApplyNamingConventions = true)]
    public short MapY { get; set; }

    [YamlMember(Alias = "position", ApplyNamingConventions = true)]
    public byte Position { get; set; } = 2;

    [YamlMember(Alias = "canMove", ApplyNamingConventions = true)]
    public bool IsMoving { get; set; } = true;

    [YamlMember(Alias = "isDisabled", ApplyNamingConventions = true)]
    public bool IsDisabled { get; set; }
}