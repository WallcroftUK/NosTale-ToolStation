using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class OnMapClean
    {
        #region Properties

        [XmlElement]
        public AddClockTime AddClockTime { get; set; }

        [XmlElement]
        public AddClockTime AddMapClockTime { get; set; }

        [XmlElement]
        public ChangePortalType[] ChangePortalType { get; set; }

        [XmlElement]
        public NpcDialog[] NpcDialog { get; set; }

        [XmlElement]
        public object RefreshMapItems { get; set; }

        [XmlElement]
        public OnMapClean RefreshOnMapClean { get; set; }

        [XmlElement]
        public SendMessage[] SendMessage { get; set; }

        [XmlElement]
        public SendPacket[] SendPacket { get; set; }

        [XmlElement]
        public object StopMapClock { get; set; }

        [XmlElement]
        public object StopMapWaves { get; set; }

        [XmlElement]
        public SummonMonster[] SummonMonster { get; set; }

        #endregion
    }
}