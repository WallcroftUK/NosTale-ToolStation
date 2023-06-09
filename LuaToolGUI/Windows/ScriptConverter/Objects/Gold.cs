using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class Gold
    {
        #region Properties

        [XmlAttribute]
        public long Value { get; set; }

        #endregion
    }
}