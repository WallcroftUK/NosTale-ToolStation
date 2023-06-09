using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class ChangePortalType
    {
        #region Properties

        [XmlAttribute]
        public int IdOnMap { get; set; }

        [XmlAttribute]
        public int Map { get; set; }

        [XmlAttribute]
        public sbyte Type { get; set; }

        #endregion
    }
}