﻿using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Objects
{
    [Serializable]
    public class Level
    {
        #region Properties

        [XmlAttribute]
        public byte Value { get; set; }

        #endregion
    }
}