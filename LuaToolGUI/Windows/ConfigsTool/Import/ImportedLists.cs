// Zro

using ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStationGUI.Windows.ConfigsTool.Import
{
    public class ImportedLists
    {
        public static List<string[]> Packets = new();
        public static List<MapNpcImportFile> MapNpcsList = new();
        public static List<MapMonsterImportFile> MapMonstersList = new();
        public static List<TeleporterImportFile> TeleporterList = new();
        public static List<RecipeImportFile> RecipesItemList = new();
        public static List<RecipeImportFile> RecipesNpcList = new();
        public static List<PortalImportFile> PortalsList = new();

        public static List<MapNpcObject> AllMapNpcObjects = new();
        public static List<int> AllExistingMapNpcId = new();
        public static List<TeleporterObject> AllExistingMapTeleporters = new();
    }
}