using ToolStationGUI.Windows.ScriptConverter.Events.Quest;
using ToolStationGUI.Windows.ScriptConverter.Objects.Quest;
using System;
using System.Xml.Serialization;

namespace ToolStationGUI.Windows.ScriptConverter.Models.Quest
{
    [XmlRoot("Definition"), Serializable]
    public class QuestModel
    {
        #region Properties

        public KillObjective[] KillObjectives { get; set; }

        public LootObjective[] LootObjectives { get; set; }

        public short QuestDataVNum { get; set; }

        public QuestGiver QuestGiver { get; set; }

        public short QuestGoalType { get; set; }

        public Reward Reward { get; set; }

        public Script Script { get; set; }

        public WalkObjective WalkObjective { get; set; }

        #endregion
    }
}