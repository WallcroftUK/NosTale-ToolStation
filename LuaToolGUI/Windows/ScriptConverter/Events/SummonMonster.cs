using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class SummonMonster
    {
        #region Properties

        [XmlAttribute]
        public short Damage { get; set; }

        [XmlElement]
        public Effect Effect { get; set; }

        [XmlAttribute]
        public short HasDelay { get; set; }

        [XmlAttribute]
        public bool IsBonus { get; set; }

        [XmlAttribute]
        public bool IsBoss { get; set; }

        [XmlAttribute]
        public bool IsHostile { get; set; }

        [XmlAttribute]
        public bool IsMeteorite { get; set; }

        [XmlAttribute]
        public bool IsTarget { get; set; }

        [XmlAttribute]
        public bool Move { get; set; }

        [XmlAttribute]
        public byte NoticeRange { get; set; }

        [XmlElement]
        public OnDeath OnDeath { get; set; }

        [XmlElement]
        public OnNoticing OnNoticing { get; set; }

        [XmlAttribute]
        public short PositionX { get; set; }

        [XmlAttribute]
        public short PositionY { get; set; }

        [XmlElement]
        public RemoveAfter RemoveAfter { get; set; }

        [XmlElement]
        public Roam Roam { get; set; }

        [XmlElement]
        public SendMessage[] SendMessage { get; set; }

        [XmlElement]
        public UseSkillOnDamage[] UseSkillOnDamage { get; set; }

        [XmlAttribute]
        public short VNum { get; set; }

        #endregion
    }
}