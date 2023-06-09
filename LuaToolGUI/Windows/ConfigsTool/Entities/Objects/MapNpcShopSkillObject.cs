// WingsEmu
// 
// Developed by NosWings Team

using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class MapNpcShopSkillObject
{
    [YamlMember(Alias = "skillVnum", ApplyNamingConventions = true)]
    public short SkillVnum { get; set; }
}