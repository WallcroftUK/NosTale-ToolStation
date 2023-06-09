using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class FamExp
    {
        #region Properties

        [XmlAttribute]
        public int Value { get; set; }

        #endregion
    }
}