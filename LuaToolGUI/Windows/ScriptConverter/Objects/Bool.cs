using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class Bool
    {
        #region Properties

        [XmlAttribute]
        public bool Value { get; set; }

        #endregion
    }
}