using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class InstanceEvent
    {
        #region Properties

        [XmlElement]
        public CreateMap[] CreateMap { get; set; }

        #endregion
    }
}