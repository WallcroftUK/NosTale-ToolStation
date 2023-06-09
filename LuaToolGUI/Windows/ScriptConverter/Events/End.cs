using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class End
    {
        #region Properties

        [XmlAttribute]
        public byte Type { get; set; }

        #endregion
    }
}