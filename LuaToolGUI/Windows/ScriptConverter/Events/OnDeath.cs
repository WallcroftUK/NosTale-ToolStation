using ToolStationGUI.Windows.ScriptConverter.Objects;
using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class OnDeath
    {
        #region Properties

        [XmlElement]
        public AddClockTime AddClockTime { get; set; }

        [XmlElement]
        public AddClockTime AddMapClockTime { get; set; }

        [XmlElement]
        public ChangePortalType[] ChangePortalType { get; set; }

        [XmlElement]
        public object ClearMapMonsters { get; set; }

        [XmlElement]
        public End End { get; set; }

        [XmlElement]
        public NpcDialog[] NpcDialog { get; set; }

        [XmlElement]
        public object RefreshMapItems { get; set; }

        [XmlElement]
        public object RefreshRaidGoals { get; set; }

        [XmlElement]
        public object RemoveButtonLocker { get; set; }

        [XmlElement]
        public object RemoveMonsterLocker { get; set; }

        [XmlElement]
        public SendMessage[] SendMessage { get; set; }

        [XmlElement]
        public SendPacket[] SendPacket { get; set; }

        [XmlElement]
        public object StopClock { get; set; }

        [XmlElement]
        public object StopMapClock { get; set; }

        [XmlElement]
        public object StopMapWaves { get; set; }

        [XmlElement]
        public SummonMonster[] SummonMonster { get; set; }

        [XmlElement]
        public SummonNpc[] SummonNpc { get; set; }

        [XmlElement]
        public ThrowItem[] ThrowItem { get; set; }

        [XmlElement]
        public Wave[] Wave { get; set; }

        #endregion
    }
}