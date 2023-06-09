// WingsEmu
// 
// Developed by NosWings Team

using System.Collections.Generic;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;

public class RecipeImportFile
{
    [YamlMember(Alias = "recipes", ApplyNamingConventions = true)]
    public List<RecipeObject> Recipes { get; set; } = new();
    
    [YamlIgnore]
    public int Identity { get; set; }
}