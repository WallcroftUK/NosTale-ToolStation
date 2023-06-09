using System;

namespace ToolStationGUI.Windows.ScriptConverter.Objects.Quest
{
    [Serializable]
    public class KillObjective
    {
        #region Properties

        public int CurrentAmount { get; set; }

        public int GoalAmount { get; set; }

        public short MonsterVNum { get; set; }

        #endregion
    }
}