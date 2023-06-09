// WingsEmu
// 
// Developed by NosWings Team

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class MapNpcShopTabObject<T>
{
    [YamlMember(Alias = "shopTabId", ApplyNamingConventions = true)]
    public int ShopTabId { get; set; }

    [YamlMember(Alias = "items", ApplyNamingConventions = true)]
    public List<T> Items { get; set; }
}