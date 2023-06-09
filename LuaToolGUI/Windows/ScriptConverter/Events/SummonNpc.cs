using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class SummonNpc
    {
        #region Properties

        [XmlAttribute]
        public byte Dir { get; set; }

        [XmlElement]
        public Effect Effect { get; set; }

        [XmlAttribute]
        public bool IsHostile { get; set; }

        [XmlAttribute]
        public bool IsMate { get; set; }

        [XmlAttribute]
        public bool IsProtected { get; set; }

        [XmlAttribute]
        public bool IsTsReward { get; set; }

        [XmlAttribute]
        public bool Move { get; set; }

        [XmlElement]
        public OnDeath OnDeath { get; set; }

        [XmlAttribute]
        public short PositionX { get; set; }

        [XmlAttribute]
        public short PositionY { get; set; }

        [XmlElement]
        public Roam Roam { get; set; }

        [XmlAttribute]
        public short VNum { get; set; }

        #endregion
    }
}