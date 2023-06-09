using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class DailyEntries
    {
        #region Properties

        [XmlAttribute]
        public short Value { get; set; }

        #endregion
    }
}