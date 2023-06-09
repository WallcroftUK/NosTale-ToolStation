using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class TimespaceType
    {
        #region Properties

        [XmlAttribute]
        public short Value { get; set; }

        #endregion
    }
}