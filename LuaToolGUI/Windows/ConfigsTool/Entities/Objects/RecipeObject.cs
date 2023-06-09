// WingsEmu
// 
// Developed by NosWings Team

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class RecipeObject
{
    [YamlMember(Alias = "itemVnum", ApplyNamingConventions = true)]
    public int ItemVnum { get; set; }

    [YamlMember(Alias = "quantity", ApplyNamingConventions = true)]
    public int Quantity { get; set; }

    [YamlMember(Alias = "producerItemVnum", ApplyNamingConventions = true)]
    public int? ProducerItemVnum { get; set; }

    [YamlMember(Alias = "producerNpcVnum", ApplyNamingConventions = true)]
    public int? ProducerNpcVnum { get; set; }

    [YamlMember(Alias = "producerMapNpcId", ApplyNamingConventions = true)]
    public int? ProducerMapNpcId { get; set; }

    [YamlMember(Alias = "items", ApplyNamingConventions = true)]
    public List<RecipeItemObject> Items { get; set; } = new();
}