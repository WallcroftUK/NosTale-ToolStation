using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStationGUI.Windows.ScriptConverter.Enums
{
    public enum TimeSpaceFinishType : byte
    {
        TIME_IS_UP = 1,
        NPC_DIED = 2,
        OUT_OF_LIVES = 3,
        TEAM_MEMBER_OUT_OF_LIVES = 4,
        SUCCESS = 5,
        SUCCESS_HIGH_SCORE = 6,
    }
}
