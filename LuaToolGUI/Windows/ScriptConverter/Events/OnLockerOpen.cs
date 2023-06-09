using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Events
{
    [Serializable]
    public class OnLockerOpen
    {
        #region Properties

        [XmlElement]
        public ChangePortalType ChangePortalType { get; set; }

        [XmlElement]
        public object ClearMapMonsters { get; set; }

        [XmlElement]
        public End End { get; set; }

        [XmlElement]
        public GenerateClock GenerateClock { get; set; }

        [XmlElement]
        public GenerateMapClock GenerateMapClock { get; set; }

        [XmlElement]
        public NpcDialog[] NpcDialog { get; set; }

        [XmlElement]
        public NpcDialogEnd[] NpcDialogEnd { get; set; }

        [XmlElement]
        public object RefreshMapItems { get; set; }

        [XmlElement]
        public OnLockerOpen RefreshOnLockerOpen { get; set; }

        [XmlElement]
        public SendMessage[] SendMessage { get; set; }

        [XmlElement]
        public SetButtonLockers SetButtonLockers { get; set; }

        [XmlElement]
        public SetMonsterLockers SetMonsterLockers { get; set; }

        [XmlElement]
        public SpawnPortal[] SpawnPortal { get; set; }

        [XmlElement]
        public StartClock StartClock { get; set; }

        [XmlElement]
        public StartClock StartMapClock { get; set; }

        [XmlElement]
        public object StopClock { get; set; }

        [XmlElement]
        public object StopMapClock { get; set; }

        [XmlElement]
        public object StopMapWaves { get; set; }

        [XmlElement]
        public SummonMonster[] SummonMonster { get; set; }

        #endregion
    }
}