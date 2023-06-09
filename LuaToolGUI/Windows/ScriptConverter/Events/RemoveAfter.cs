using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class RemoveAfter
    {
        #region Properties

        [XmlAttribute]
        public short Value { get; set; }

        #endregion
    }
}