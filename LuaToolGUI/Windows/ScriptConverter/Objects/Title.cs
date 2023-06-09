using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class Title
    {
        #region Properties

        [XmlAttribute]
        public string Value { get; set; }

        #endregion
    }
}
