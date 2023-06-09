using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class AddClockTime
    {
        #region Properties

        [XmlAttribute]
        public int Seconds { get; set; }

        #endregion
    }
}