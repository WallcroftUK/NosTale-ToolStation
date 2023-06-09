using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class Name
    {
        #region Properties

        [XmlAttribute]
        public string Value { get; set; }

        #endregion
    }
}