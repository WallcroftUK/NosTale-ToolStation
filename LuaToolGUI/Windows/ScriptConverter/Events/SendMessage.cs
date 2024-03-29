﻿using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class SendMessage
    {
        #region Properties

        [XmlAttribute]
        public byte Type { get; set; }

        [XmlAttribute]
        public string Value { get; set; }

        #endregion
    }
}