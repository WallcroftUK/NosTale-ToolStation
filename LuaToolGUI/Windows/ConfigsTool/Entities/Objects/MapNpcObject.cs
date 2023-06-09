// WingsEmu
// 
// Developed by NosWings Team

using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

public class MapNpcObject
{
    [YamlMember(Alias = "mapNpcId", ApplyNamingConventions = true)]
    public int MapNpcId { get; set; }

    [YamlMember(Alias = "vnum", ApplyNamingConventions = true)]
    public int NpcMonsterVnum { get; set; }

    [YamlMember(Alias = "posX", ApplyNamingConventions = true)]
    public short PosX { get; set; }

    [YamlMember(Alias = "posY", ApplyNamingConventions = true)]
    public short PosY { get; set; }

    [YamlMember(Alias = "canAttack", ApplyNamingConventions = true)]
    public bool CanAttack { get; set; }

    [YamlMember(Alias = "hasGodMode", ApplyNamingConventions = true)]
    public bool HasGodMode { get; set; } = true;

    [YamlIgnore]
    public int MapId { get; set; }

    [YamlMember(Alias = "effectVnum", ApplyNamingConventions = true)]
    public int Effect { get; set; }

    [YamlMember(Alias = "effectDelay", ApplyNamingConventions = true)]
    public int EffectDelay { get; set; }

    [YamlMember(Alias = "dialogId", ApplyNamingConventions = true)]
    public int DialogId { get; set; }

    [YamlMember(Alias = "questDialogId", ApplyNamingConventions = true)]
    public int? QuestDialog { get; set; }

    [YamlMember(Alias = "directionFacing", ApplyNamingConventions = true)]
    public byte Direction { get; set; }

    [YamlMember(Alias = "canMove", ApplyNamingConventions = true)]
    public bool IsMoving { get; set; }

    [YamlMember(Alias = "isDisabled", ApplyNamingConventions = true)]
    public bool IsDisabled { get; set; }

    [YamlMember(Alias = "isSitting", ApplyNamingConventions = true)]
    public bool IsSitting { get; set; }

    [YamlMember(Alias = "customName", ApplyNamingConventions = true)]
    public string CustomName { get; set; }

    [YamlMember(Alias = "itemShop", ApplyNamingConventions = true)]
    public MapNpcShopObject<MapNpcShopItemObject> ItemShop { get; set; }

    [YamlMember(Alias = "skillShop", ApplyNamingConventions = true)]
    public MapNpcShopObject<MapNpcShopSkillObject> SkillShop { get; set; }

    [YamlIgnore]
    public string TempShopName { get; set; }

    [YamlIgnore]
    public byte TempMenuType { get; set; }

    [YamlIgnore]
    public byte TempShopType { get; set; }
}