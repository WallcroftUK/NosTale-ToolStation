using ToolStationGUI.Windows.ScriptConverter.Events;
using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class Wave
    {
        #region Properties

        [XmlAttribute]
        public byte Delay { get; set; }

        [XmlAttribute]
        public byte Offset { get; set; }

        [XmlAttribute]
        public short RunTimes { get; set; }

        [XmlElement]
        public SendMessage[] SendMessage { get; set; }

        [XmlElement]
        public SummonMonster[] SummonMonster { get; set; }

        [XmlElement]
        public SummonNpc[] SummonNpc { get; set; }

        #endregion
    }
}