using ToolStationGUI.Windows.ScriptConverter.Objects;
using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class OnCharacterDiscoveringMap
    {
        #region Properties

        [XmlElement]
        public Effect Effect { get; set; }

        [XmlElement]
        public ChangePortalType[] ChangePortalType { get; set; }

        [XmlElement]
        public GenerateClock GenerateClock { get; set; }

        [XmlElement]
        public GenerateMapClock GenerateMapClock { get; set; }

        [XmlElement]
        public NpcDialog[] NpcDialog { get; set; }

        [XmlElement]
        public NpcDialogEnd[] NpcDialogEnd { get; set; }

        [XmlElement]
        public OnMapClean OnMapClean { get; set; }

        [XmlElement]
        public OnMoveOnMap OnMoveOnMap { get; set; }

        [XmlElement]
        public object RefreshRaidGoals { get; set; }

        [XmlElement]
        public SendMessage[] SendMessage { get; set; }

        [XmlElement]
        public SendPacket[] SendPacket { get; set; }

        [XmlElement]
        public SetButtonLockers SetButtonLockers { get; set; }

        [XmlElement]
        public SetMonsterLockers SetMonsterLockers { get; set; }

        [XmlElement]
        public SpawnPortal[] SpawnPortal { get; set; }

        [XmlElement]
        public StartClock StartClock { get; set; }

        [XmlElement]
        public StartClock StartMapClock { get; set; }

        [XmlElement]
        public object StopClock { get; set; }

        [XmlElement]
        public object StopMapClock { get; set; }

        [XmlElement]
        public SummonMonster[] SummonMonster { get; set; }

        [XmlElement]
        public SummonNpc[] SummonNpc { get; set; }

        [XmlElement]
        public Wave[] Wave { get; set; }

        #endregion
    }
}