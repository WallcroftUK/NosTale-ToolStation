using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class OnTarget
    {
        #region Properties

        [XmlElement]
        public ControlMonsterInRange ControlMonsterInRange { get; set; }

        [XmlElement]
        public Effect Effect { get; set; }

        [XmlElement]
        public Move Move { get; set; }

        #endregion
    }
}