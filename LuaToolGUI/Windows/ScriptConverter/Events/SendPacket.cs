﻿using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class SendPacket
    {
        #region Properties

        [XmlAttribute]
        public string Value { get; set; }

        #endregion
    }
}