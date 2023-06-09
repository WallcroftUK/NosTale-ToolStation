using ToolStationGUI.Windows.ScriptConverter.Events.Quest;
using ToolStationGUI.Windows.ScriptConverter.Objects;
using System;

namespace ToolStationGUI.Windows.ScriptConverter.Models.Quest
{
    [Serializable]
    public class Reward
    {
        #region Properties

        public short Buff { get; set; }

        public bool DisplayRewardWindow { get; set; }

        public Item[] DrawOneItems { get; set; }

        public byte ForceHeroUp { get; set; }

        public byte ForceJobUp { get; set; }

        public byte ForceLevelUp { get; set; }

        public Item[] GiftItems { get; set; }

        public long QuestId { get; set; }

        public Script Script { get; set; }

        public TeleportTo TeleportPosition { get; set; }

        #endregion
    }
}