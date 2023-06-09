using ToolStationGUI.Windows.ScriptConverter.Events;
using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class CreateMap
    {
        #region Properties

        [XmlElement]
        public OnMapClean OnMapClean { get; set; }

        [XmlAttribute]
        public bool DropAllowed { get; set; }

        [XmlElement]
        public GenerateMapClock GenerateClock { get; set; }

        [XmlElement]
        public GenerateMapClock GenerateMapClock { get; set; }

        [XmlAttribute]
        public byte IndexX { get; set; }

        [XmlAttribute]
        public byte IndexY { get; set; }

        [XmlAttribute]
        public bool IsWaitingRoom { get; set; }

        [XmlAttribute]
        public int Map { get; set; }

        [XmlElement]
        public OnAreaEntry[] OnAreaEntry { get; set; }

        [XmlElement]
        public OnCharacterDiscoveringMap OnCharacterDiscoveringMap { get; set; }

        [XmlElement]
        public OnLockerOpen OnLockerOpen { get; set; }

        [XmlElement]
        public OnMoveOnMap[] OnMoveOnMap { get; set; }

        [XmlElement]
        public SetButtonLockers SetButtonLockers { get; set; }

        [XmlElement]
        public SetMonsterLockers SetMonsterLockers { get; set; }

        [XmlElement]
        public SpawnButton[] SpawnButton { get; set; }

        [XmlElement]
        public SpawnPortal[] SpawnPortal { get; set; }

        [XmlElement]
        public StartClock StartClock { get; set; }

        [XmlElement]
        public SummonMonster[] SummonMonster { get; set; }

        [XmlElement]
        public SummonNpc[] SummonNpc { get; set; }

        [XmlAttribute]
        public short VNum { get; set; }

        [XmlAttribute]
        public short XpRate { get; set; }

        #endregion
    }
}