using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class OnTraversal
    {
        #region Properties

        [XmlElement]
        public End End { get; set; }

        [XmlElement]
        public NpcDialog[] NpcDialog { get; set; }

        [XmlElement]
        public Teleport Teleport { get; set; }

        #endregion
    }
}