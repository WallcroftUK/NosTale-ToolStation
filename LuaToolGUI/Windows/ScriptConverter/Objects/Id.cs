using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class Id
    {
        #region Properties

        [XmlAttribute]
        public short Value { get; set; }

        #endregion
    }
}