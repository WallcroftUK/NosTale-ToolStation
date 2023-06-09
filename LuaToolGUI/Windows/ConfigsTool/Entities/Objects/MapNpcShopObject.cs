// WingsEmu
// 
// Developed by NosWings Team

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class MapNpcShopObject<T>
{
    [YamlMember(Alias = "name", ApplyNamingConventions = true)]
    public string Name { get; set; }

    [YamlMember(Alias = "menuType", ApplyNamingConventions = true)]
    public byte MenuType { get; set; }

    [YamlMember(Alias = "shopType", ApplyNamingConventions = true)]
    public byte ShopType { get; set; }

    [YamlMember(Alias = "tabs", ApplyNamingConventions = true)]
    public List<MapNpcShopTabObject<T>> ShopTabs { get; set; }
}