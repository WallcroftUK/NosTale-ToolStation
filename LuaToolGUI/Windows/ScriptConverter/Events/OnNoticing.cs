using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class OnNoticing
    {
        #region Properties

        [XmlElement]
        public Effect Effect { get; set; }

        [XmlElement]
        public Move Move { get; set; }

        [XmlAttribute]
        public byte Range { get; set; }

        #endregion
    }
}