using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class Reputation
    {
        #region Properties

        [XmlAttribute]
        public int Value { get; set; }

        #endregion
    }
}