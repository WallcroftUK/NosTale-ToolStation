// WingsEmu
// 
// Developed by NosWings Team

using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class RecipeItemObject
{
    [YamlMember(Alias = "itemVnum", ApplyNamingConventions = true)]
    public short ItemVnum { get; set; }

    [YamlMember(Alias = "quantity", ApplyNamingConventions = true)]
    public short Quantity { get; set; }
}