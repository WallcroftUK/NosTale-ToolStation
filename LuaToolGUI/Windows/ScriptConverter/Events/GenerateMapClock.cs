using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class GenerateMapClock
    {
        #region Properties

        [XmlAttribute]
        public int Value { get; set; }

        #endregion
    }
}