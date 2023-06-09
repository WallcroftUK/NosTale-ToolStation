// Zro

using System.Linq;
using ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

namespace ToolStationGUI.Windows.ConfigsTool.Import;

public class ImportItemsRecipes
{
    public static void Import()
    {
        short productionToolsForAdventurers = 1035;
        short productionToolsForSwordsmen = 1039;
        short producesToolsForArchers = 1040;
        short producesToolsForSorcerers = 1041;
        short productionToolsForAccessories = 1047;
        short productionToolsForGemsCellonsAndCrystals = 1072;
        short productionToolsForRawMaterials = 1073;
        short productionToolsForGlovesAndShoes = 1083;
        short groupTimeSpacePiece = 1092;
        short individualTimeSpacePiece = 1093;
        short raidTimeSpacePiece = 1094;
        short huntingTimeSpacePiece = 1095;
        short laboratoryTimeSpacePiece = 1096;
        short constructionPlanLevel1 = 1235;
        short constructionPlanLevel2 = 1236;
        short bootCombinationRecipeA = 1237;
        short bootCombinationRecipeB = 1238;
        short gloveCombinationRecipeA = 1239;
        short gloveCombinationRecipeB = 1240;
        short consumablesRecipe = 1241;
        short amirArmourParchment = 1312;
        short amirWeaponParchmentA = 1313;
        short amirWeaponParchmentB = 1314;
        short amirWeaponSpecifications = 1315;
        short amirWeaponSpecificationBookCover = 1316;
        short basiliskTimeSpacePiece = 1317;
        short hellKnightTimeSpacePiece = 1318;
        short treekunTimeSpacePiece = 1319;
        short chrysosTimeSpacePiece = 1320;
        short robberGangBlueprints = 1887;
        short ancelloanAccessoryProductionScroll = 5884;
        short ancelloanWeaponProductionScroll = 5885;
        short ancelloanSecondaryWeaponProductionScroll = 5886;
        short ancelloanArmourProductionScroll = 5887;
        short charredMaskParchment = 5900;
        short grenigasAccessoriesParchment = 5901;
        short orcLoaAccessoriesProductionScroll = 5750;
        short orcLoaWeaponsProductionScroll = 5751;
        short orcLoaSecondaryWeaponsProductionScroll = 5752;
        short orcLoaArmourProductionScroll = 5753;
        short oldVikingCostume7DaysSketch = 5902;
        short fafnirBugleBlueprints = 5903;

        // Production Tools for Adventurers
        InsertRecipe(6, productionToolsForAdventurers, 1, new short[] { 1027, 10, productionToolsForAdventurers, 1, 2038, 8 });
        InsertRecipe(16, productionToolsForAdventurers, 1, new short[] { 1027, 8, productionToolsForAdventurers, 1, 2042, 6 });
        InsertRecipe(204, productionToolsForAdventurers, 1, new short[] { 1027, 15, productionToolsForAdventurers, 1, 2042, 10 });
        InsertRecipe(206, productionToolsForAdventurers, 1, new short[] { 1027, 8, productionToolsForAdventurers, 1, 2046, 7 });
        InsertRecipe(501, productionToolsForAdventurers, 1, new short[] { 500, 1, 1027, 14, productionToolsForAdventurers, 1 });

        // Production Tools for Swordsmen
        InsertRecipe(22, productionToolsForSwordsmen, 1, new short[] { 1027, 30, productionToolsForSwordsmen, 1, 2035, 32 });
        InsertRecipe(26, productionToolsForSwordsmen, 1, new short[] { 1027, 43, productionToolsForSwordsmen, 1, 2035, 44 });
        InsertRecipe(30, productionToolsForSwordsmen, 1, new short[] { 1027, 54, productionToolsForSwordsmen, 1, 2036, 56 });
        InsertRecipe(73, productionToolsForSwordsmen, 1, new short[] { 1027, 33, productionToolsForSwordsmen, 1, 2035, 10, 2039, 23 });
        InsertRecipe(76, productionToolsForSwordsmen, 1, new short[] { 1027, 53, productionToolsForSwordsmen, 1, 2036, 14, 2040, 39 });
        InsertRecipe(96, productionToolsForSwordsmen, 1, new short[] { 1027, 20, productionToolsForSwordsmen, 1, 2034, 6, 2046, 14 });
        InsertRecipe(100, productionToolsForSwordsmen, 1, new short[] { 1027, 35, productionToolsForSwordsmen, 1, 2035, 12, 2047, 23 });
        InsertRecipe(104, productionToolsForSwordsmen, 1, new short[] { 1027, 53, productionToolsForSwordsmen, 1, 2036, 18, 2048, 35 });

        // Production Tools for Archers
        InsertRecipe(36, producesToolsForArchers, 1, new short[] { 1027, 30, producesToolsForArchers, 1, 2039, 32 });
        InsertRecipe(40, producesToolsForArchers, 1, new short[] { 1027, 43, producesToolsForArchers, 1, 2039, 35 });
        InsertRecipe(44, producesToolsForArchers, 1, new short[] { 1027, 54, producesToolsForArchers, 1, 2040, 56 });
        InsertRecipe(81, producesToolsForArchers, 1, new short[] { 1027, 33, producesToolsForArchers, 1, 2035, 32 });
        InsertRecipe(84, producesToolsForArchers, 1, new short[] { 1027, 53, producesToolsForArchers, 1, 2036, 54 });
        InsertRecipe(109, producesToolsForArchers, 1, new short[] { 1027, 20, producesToolsForArchers, 1, 2042, 8, 2046, 12 });
        InsertRecipe(113, producesToolsForArchers, 1, new short[] { 1027, 35, producesToolsForArchers, 1, 2043, 13, 2047, 22 });
        InsertRecipe(117, producesToolsForArchers, 1, new short[] { 1027, 53, producesToolsForArchers, 1, 2044, 20, 2048, 33 });

        // Production Tools for Sorcerers
        InsertRecipe(50, producesToolsForSorcerers, 1, new short[] { 1027, 30, producesToolsForSorcerers, 1, 2039, 32 });
        InsertRecipe(54, producesToolsForSorcerers, 1, new short[] { 1027, 43, producesToolsForSorcerers, 1, 2039, 45 });
        InsertRecipe(58, producesToolsForSorcerers, 1, new short[] { 1027, 54, producesToolsForSorcerers, 1, 2040, 56 });
        InsertRecipe(89, producesToolsForSorcerers, 1, new short[] { 1027, 33, producesToolsForSorcerers, 1, 2035, 34 });
        InsertRecipe(92, producesToolsForSorcerers, 1, new short[] { 1027, 53, producesToolsForSorcerers, 1, 2036, 54 });
        InsertRecipe(122, producesToolsForSorcerers, 1, new short[] { 1027, 20, producesToolsForSorcerers, 1, 2042, 14, 2046, 6 });
        InsertRecipe(126, producesToolsForSorcerers, 1, new short[] { 1027, 35, producesToolsForSorcerers, 1, 2043, 28, 2047, 7 });
        InsertRecipe(130, producesToolsForSorcerers, 1, new short[] { 1027, 53, producesToolsForSorcerers, 1, 2044, 42, 2048, 11 });

        // Production Tools for Accessories
        InsertRecipe(508, productionToolsForAccessories, 1, new short[] { 1027, 24, 1032, 5, productionToolsForAccessories, 1 });
        InsertRecipe(509, productionToolsForAccessories, 1, new short[] { 1027, 25, 1031, 5, productionToolsForAccessories, 1 });
        InsertRecipe(510, productionToolsForAccessories, 1, new short[] { 1027, 26, 1031, 7, productionToolsForAccessories, 1 });
        InsertRecipe(514, productionToolsForAccessories, 1, new short[] { 1027, 33, 1033, 10, productionToolsForAccessories, 1 });
        InsertRecipe(516, productionToolsForAccessories, 1, new short[] { 1027, 35, 1032, 12, productionToolsForAccessories, 1 });
        InsertRecipe(517, productionToolsForAccessories, 1, new short[] { 1027, 36, 1034, 15, productionToolsForAccessories, 1 });
        InsertRecipe(522, productionToolsForAccessories, 1, new short[] { 1027, 43, 1033, 20, productionToolsForAccessories, 1 });
        InsertRecipe(523, productionToolsForAccessories, 1, new short[] { 1027, 44, 1031, 24, productionToolsForAccessories, 1 });
        InsertRecipe(525, productionToolsForAccessories, 1, new short[] { 1027, 46, 1034, 28, productionToolsForAccessories, 1 });
        InsertRecipe(531, productionToolsForAccessories, 1, new short[] { 1027, 54, 1032, 36, productionToolsForAccessories, 1 });
        InsertRecipe(534, productionToolsForAccessories, 1, new short[] { 1027, 57, 1033, 42, productionToolsForAccessories, 1 });

        // Production Tools for Gems, Cellons and Crystals
        InsertRecipe(1016, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 99, 1015, 10, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1018, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 5, 1017, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1019, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 10, 1018, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1020, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 17, 1019, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1021, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 25, 1020, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1022, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 35, 1021, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1023, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 50, 1022, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1024, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 75, 1023, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1025, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 110, 1024, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1026, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 160, 1025, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1029, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 20, 1028, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1030, productionToolsForGemsCellonsAndCrystals, 1, new short[] { 1014, 50, 1029, 5, productionToolsForGemsCellonsAndCrystals, 1 });
        InsertRecipe(1031, productionToolsForGemsCellonsAndCrystals, 4, new short[] { 1028, 1, productionToolsForGemsCellonsAndCrystals, 1, 2097, 5 });
        InsertRecipe(1032, productionToolsForGemsCellonsAndCrystals, 4, new short[] { 1028, 1, productionToolsForGemsCellonsAndCrystals, 1, 2097, 5 });
        InsertRecipe(1033, productionToolsForGemsCellonsAndCrystals, 4, new short[] { 1028, 1, productionToolsForGemsCellonsAndCrystals, 1, 2097, 5 });
        InsertRecipe(1034, productionToolsForGemsCellonsAndCrystals, 4, new short[] { 1028, 1, productionToolsForGemsCellonsAndCrystals, 1, 2097, 5 });

        // Production Tools for Raw Materials
        InsertRecipe(2035, productionToolsForRawMaterials, 1, new short[] { 1014, 5, productionToolsForRawMaterials, 1, 2034, 5 });
        InsertRecipe(2036, productionToolsForRawMaterials, 1, new short[] { 1014, 10, productionToolsForRawMaterials, 1, 2035, 5 });
        InsertRecipe(2037, productionToolsForRawMaterials, 1, new short[] { 1014, 20, productionToolsForRawMaterials, 1, 2036, 5 });
        InsertRecipe(2039, productionToolsForRawMaterials, 1, new short[] { 1014, 5, productionToolsForRawMaterials, 1, 2038, 5 });
        InsertRecipe(2040, productionToolsForRawMaterials, 1, new short[] { 1014, 10, productionToolsForRawMaterials, 1, 2039, 5 });
        InsertRecipe(2041, productionToolsForRawMaterials, 1, new short[] { 1014, 20, productionToolsForRawMaterials, 1, 2040, 5 });
        InsertRecipe(2043, productionToolsForRawMaterials, 1, new short[] { 1014, 5, productionToolsForRawMaterials, 1, 2042, 5 });
        InsertRecipe(2044, productionToolsForRawMaterials, 1, new short[] { 1014, 10, productionToolsForRawMaterials, 1, 2043, 5 });
        InsertRecipe(2045, productionToolsForRawMaterials, 1, new short[] { 1014, 20, productionToolsForRawMaterials, 1, 2044, 5 });
        InsertRecipe(2047, productionToolsForRawMaterials, 1, new short[] { 1014, 5, productionToolsForRawMaterials, 1, 2046, 5 });
        InsertRecipe(2048, productionToolsForRawMaterials, 1, new short[] { 1014, 10, productionToolsForRawMaterials, 1, 2047, 5 });
        InsertRecipe(2049, productionToolsForRawMaterials, 1, new short[] { 1014, 20, productionToolsForRawMaterials, 1, 2048, 5 });

        // Production Tools for Gloves and Shoes
        InsertRecipe(718, productionToolsForGlovesAndShoes, 1, new short[] { 1027, 5, 1028, 1, productionToolsForGlovesAndShoes, 1, 2042, 4 });
        InsertRecipe(703, productionToolsForGlovesAndShoes, 1, new short[] { 1027, 7, 1028, 2, productionToolsForGlovesAndShoes, 1, 2034, 5 });
        InsertRecipe(705, productionToolsForGlovesAndShoes, 1, new short[] { 1027, 9, 1028, 3, productionToolsForGlovesAndShoes, 1, 2035, 3 });
        InsertRecipe(719, productionToolsForGlovesAndShoes, 1, new short[] { 1027, 12, 1028, 4, productionToolsForGlovesAndShoes, 1, 2047, 5 });
        InsertRecipe(722, productionToolsForGlovesAndShoes, 1, new short[] { 1027, 5, 1028, 1, productionToolsForGlovesAndShoes, 1, 2046, 5 });
        InsertRecipe(723, productionToolsForGlovesAndShoes, 1, new short[] { 1027, 7, 1028, 2, productionToolsForGlovesAndShoes, 1, 2046, 7 });
        InsertRecipe(724, productionToolsForGlovesAndShoes, 1, new short[] { 1027, 9, 1028, 3, productionToolsForGlovesAndShoes, 1, 2047, 4 });
        InsertRecipe(725, productionToolsForGlovesAndShoes, 1, new short[] { 1027, 14, 1028, 4, productionToolsForGlovesAndShoes, 1, 2047, 7 });
        InsertRecipe(325, productionToolsForGlovesAndShoes, 1, new short[] { productionToolsForGlovesAndShoes, 1, 2044, 10, 2048, 10, 2093, 50 });

        // Group Time-Space Piece
        InsertRecipe(1800, groupTimeSpacePiece, 1, new short[] { 1012, 12, 1028, 3, groupTimeSpacePiece, 1 });
        InsertRecipe(1801, groupTimeSpacePiece, 1, new short[] { 1012, 15, 1028, 4, groupTimeSpacePiece, 1 });
        InsertRecipe(1802, groupTimeSpacePiece, 1, new short[] { 1012, 18, 1028, 6, groupTimeSpacePiece, 1 });
        InsertRecipe(1803, groupTimeSpacePiece, 1, new short[] { 1012, 20, 1029, 2, groupTimeSpacePiece, 1 });
        InsertRecipe(1804, groupTimeSpacePiece, 1, new short[] { 1012, 24, 1029, 3, groupTimeSpacePiece, 1 });
        InsertRecipe(1805, groupTimeSpacePiece, 1, new short[] { 1012, 31, 1029, 5, groupTimeSpacePiece, 1 });
        InsertRecipe(1806, groupTimeSpacePiece, 1, new short[] { 1012, 40, 1029, 7, groupTimeSpacePiece, 1 });

        // Individual Time-Space Piece
        InsertRecipe(1807, individualTimeSpacePiece, 1, new short[] { 1012, 3, 1028, 1, individualTimeSpacePiece, 1 });
        InsertRecipe(1808, individualTimeSpacePiece, 1, new short[] { 1012, 5, 1028, 2, individualTimeSpacePiece, 1 });
        InsertRecipe(1809, individualTimeSpacePiece, 1, new short[] { 1012, 7, 1028, 3, individualTimeSpacePiece, 1 });
        InsertRecipe(1810, individualTimeSpacePiece, 1, new short[] { 1012, 9, 1028, 4, individualTimeSpacePiece, 1 });
        InsertRecipe(1811, individualTimeSpacePiece, 1, new short[] { 1012, 11, 1029, 1, individualTimeSpacePiece, 1 });
        InsertRecipe(1812, individualTimeSpacePiece, 1, new short[] { 1012, 13, 1029, 1, individualTimeSpacePiece, 1 });
        InsertRecipe(1813, individualTimeSpacePiece, 1, new short[] { 1012, 15, 1029, 1, individualTimeSpacePiece, 1 });
        InsertRecipe(1814, individualTimeSpacePiece, 1, new short[] { 1012, 17, 1029, 2, individualTimeSpacePiece, 1 });
        InsertRecipe(1815, individualTimeSpacePiece, 1, new short[] { 1012, 19, 1029, 2, individualTimeSpacePiece, 1 });
        InsertRecipe(1816, individualTimeSpacePiece, 1, new short[] { 1012, 21, 1029, 3, individualTimeSpacePiece, 1 });

        // Raid Time-Space Piece
        InsertRecipe(1826, raidTimeSpacePiece, 1, new short[] { 1012, 2, 1028, 2, raidTimeSpacePiece, 1, 2006, 30 });
        InsertRecipe(1827, raidTimeSpacePiece, 1, new short[] { 1012, 4, 1029, 2, raidTimeSpacePiece, 1, 2010, 40 });
        InsertRecipe(1817, raidTimeSpacePiece, 1, new short[] { 1012, 6, 1029, 3, raidTimeSpacePiece, 1, 2011, 30 });
        InsertRecipe(1818, raidTimeSpacePiece, 1, new short[] { 1012, 8, 1029, 4, raidTimeSpacePiece, 1, 2091, 30, 2092, 3 });
        InsertRecipe(1820, raidTimeSpacePiece, 1, new short[] { 1012, 10, 1029, 5, raidTimeSpacePiece, 1, 2094, 40, 2172, 30 });

        // Hunting Time-Space Piece
        InsertRecipe(1822, huntingTimeSpacePiece, 1, new short[] { 1012, 5, huntingTimeSpacePiece, 1, 2073, 10 });
        InsertRecipe(1823, huntingTimeSpacePiece, 1, new short[] { 1012, 7, huntingTimeSpacePiece, 1, 2091, 15 });
        InsertRecipe(1824, huntingTimeSpacePiece, 1, new short[] { 1012, 10, huntingTimeSpacePiece, 1, 2073, 15 });
        InsertRecipe(1825, huntingTimeSpacePiece, 1, new short[] { 1012, 12, huntingTimeSpacePiece, 1, 2094, 10 });

        // Laboratory Time-Space Piece
        InsertRecipe(1828, laboratoryTimeSpacePiece, 1, new short[] { 1012, 15, 1029, 2, laboratoryTimeSpacePiece, 1, 2177, 30 });
        InsertRecipe(1829, laboratoryTimeSpacePiece, 1, new short[] { 1012, 15, 1029, 2, laboratoryTimeSpacePiece, 1, 2179, 30 });
        InsertRecipe(1830, laboratoryTimeSpacePiece, 1, new short[] { 1012, 15, 1029, 2, laboratoryTimeSpacePiece, 1, 2180, 30 });

        // Construction Plan (Level 1)
        InsertRecipe(3121, constructionPlanLevel1, 1, new short[] { constructionPlanLevel1, 1, 2036, 50, 2037, 30, 2040, 20, 2105, 10, 2189, 20, 2205, 20 });
        InsertRecipe(3122, constructionPlanLevel1, 1, new short[] { constructionPlanLevel1, 1, 2040, 50, 2041, 30, 2048, 20, 2109, 10, 2190, 20, 2206, 20 });
        InsertRecipe(3123, constructionPlanLevel1, 1, new short[] { constructionPlanLevel1, 1, 2044, 20, 2048, 50, 2049, 30, 2117, 10, 2191, 20, 2207, 20 });
        InsertRecipe(3124, constructionPlanLevel1, 1, new short[] { constructionPlanLevel1, 1, 2036, 20, 2044, 50, 2045, 30, 2118, 10, 2192, 20, 2208, 20 });

        // Construction Plan (Level 2)
        InsertRecipe(3125, constructionPlanLevel2, 1, new short[] { constructionPlanLevel2, 1, 2037, 70, 2041, 40, 2048, 20, 2105, 20, 2189, 30, 2193, 30, 2197, 20, 2205, 40 });
        InsertRecipe(3126, constructionPlanLevel2, 1, new short[] { constructionPlanLevel2, 1, 2041, 70, 2044, 20, 2049, 40, 2109, 20, 2190, 30, 2194, 30, 2198, 20, 2206, 40 });
        InsertRecipe(3127, constructionPlanLevel2, 1, new short[] { constructionPlanLevel2, 1, 2036, 20, 2045, 40, 2049, 70, 2117, 20, 2191, 30, 2195, 30, 2199, 20, 2207, 40 });
        InsertRecipe(3128, constructionPlanLevel2, 1, new short[] { constructionPlanLevel2, 1, 2037, 40, 2040, 20, 2045, 70, 2118, 20, 2192, 30, 2196, 30, 2200, 20, 2208, 40 });

        // Boot Combination Recipe A
        InsertRecipe(384, bootCombinationRecipeA, 1, new short[] { 1027, 30, 1032, 10, bootCombinationRecipeA, 1, 2010, 10, 2044, 30, 2208, 10 });
        InsertRecipe(385, bootCombinationRecipeA, 1, new short[] { 1027, 30, 1031, 10, bootCombinationRecipeA, 1, 2010, 10, 2036, 30, 2205, 10 });
        InsertRecipe(386, bootCombinationRecipeA, 1, new short[] { 1027, 30, 1033, 10, bootCombinationRecipeA, 1, 2010, 10, 2040, 30, 2206, 10 });
        InsertRecipe(387, bootCombinationRecipeA, 1, new short[] { 1027, 30, 1034, 10, bootCombinationRecipeA, 1, 2010, 10, 2048, 30, 2207, 10 });

        // Boot Combination Recipe B
        InsertRecipe(388, bootCombinationRecipeB, 1, new short[] { 1027, 50, 1030, 5, bootCombinationRecipeB, 1, 2010, 20, 2204, 10, 2210, 5 });
        InsertRecipe(389, bootCombinationRecipeB, 1, new short[] { 1027, 50, 1030, 5, bootCombinationRecipeB, 1, 2010, 20, 2201, 10, 2209, 5 });
        InsertRecipe(390, bootCombinationRecipeB, 1, new short[] { 1027, 50, 1030, 5, bootCombinationRecipeB, 1, 2010, 20, 2202, 10, 2211, 5 });
        InsertRecipe(391, bootCombinationRecipeB, 1, new short[] { 1027, 50, 1030, 5, bootCombinationRecipeB, 1, 2010, 20, 2203, 10, 2212, 5 });

        // Glove Combination Recipe A
        InsertRecipe(376, gloveCombinationRecipeA, 1, new short[] { 1027, 30, 1032, 10, gloveCombinationRecipeA, 1, 2010, 10, 2044, 30, 2208, 10 });
        InsertRecipe(377, gloveCombinationRecipeA, 1, new short[] { 1027, 30, 1031, 10, gloveCombinationRecipeA, 1, 2010, 10, 2036, 30, 2205, 10 });
        InsertRecipe(378, gloveCombinationRecipeA, 1, new short[] { 1027, 30, 1033, 10, gloveCombinationRecipeA, 1, 2010, 10, 2040, 30, 2206, 10 });
        InsertRecipe(379, gloveCombinationRecipeA, 1, new short[] { 1027, 30, 1034, 10, gloveCombinationRecipeA, 1, 2010, 10, 2048, 30, 2207, 10 });

        // Glove Combination Recipe B
        InsertRecipe(380, gloveCombinationRecipeB, 1, new short[] { 1027, 50, 1030, 5, gloveCombinationRecipeB, 1, 2010, 20, 2204, 10, 2210, 5 });
        InsertRecipe(381, gloveCombinationRecipeB, 1, new short[] { 1027, 50, 1030, 5, gloveCombinationRecipeB, 1, 2010, 20, 2201, 10, 2209, 5 });
        InsertRecipe(382, gloveCombinationRecipeB, 1, new short[] { 1027, 50, 1030, 5, gloveCombinationRecipeB, 1, 2010, 20, 2202, 10, 2211, 5 });
        InsertRecipe(383, gloveCombinationRecipeB, 1, new short[] { 1027, 50, 1030, 5, gloveCombinationRecipeB, 1, 2010, 20, 2203, 10, 2212, 5 });

        // Consumables Recipe
        InsertRecipe(1245, consumablesRecipe, 1, new short[] { consumablesRecipe, 1, 2029, 5, 2097, 5, 2196, 5, 2208, 5, 2215, 1 });
        InsertRecipe(1246, consumablesRecipe, 1, new short[] { consumablesRecipe, 1, 2029, 5, 2097, 5, 2193, 5, 2206, 5 });
        InsertRecipe(1247, consumablesRecipe, 1, new short[] { consumablesRecipe, 1, 2029, 5, 2097, 5, 2194, 5, 2207, 5 });
        InsertRecipe(1248, consumablesRecipe, 1, new short[] { consumablesRecipe, 1, 2029, 5, 2097, 5, 2195, 5, 2205, 5 });
        InsertRecipe(1249, consumablesRecipe, 1, new short[] { consumablesRecipe, 1, 2029, 5, 2097, 5, 2196, 7, 2206, 7, 2214, 1 });

        // Amir's Armour Parchment
        InsertRecipe(409, amirArmourParchment, 1, new short[] { 298, 1, amirArmourParchment, 1, 2049, 70, 2227, 80, 2254, 5, 2265, 80 });
        InsertRecipe(410, amirArmourParchment, 1, new short[] { 296, 1, amirArmourParchment, 1, 2037, 70, 2246, 80, 2255, 5, 2271, 80 });
        InsertRecipe(411, amirArmourParchment, 1, new short[] { 272, 1, amirArmourParchment, 1, 2041, 70, 2252, 5, 2253, 80, 2270, 80 });
        InsertRecipe(4740, amirArmourParchment, 1, new short[] { 4738, 1, amirArmourParchment, 1, 2049, 70, 2227, 80, 2254, 10, 2265, 70 });
        InsertRecipe(4742, amirArmourParchment, 1, new short[] { 4739, 1, amirArmourParchment, 1, 2037, 80, 2246, 90, 2255, 10, 2271, 90 });

        // Amir's Weapon Parchment A
        InsertRecipe(400, amirWeaponParchmentA, 1, new short[] { 263, 1, amirWeaponParchmentA, 1, 2036, 60, 2218, 40, 2250, 10 });
        InsertRecipe(403, amirWeaponParchmentA, 1, new short[] { 266, 1, amirWeaponParchmentA, 1, 2040, 60, 2217, 40, 2249, 10 });
        InsertRecipe(406, amirWeaponParchmentA, 1, new short[] { 269, 1, amirWeaponParchmentA, 1, 2048, 60, 2224, 40, 2251, 10 });
        InsertRecipe(402, amirWeaponParchmentA, 1, new short[] { 292, 1, amirWeaponParchmentA, 1, 2040, 60, 2217, 50, 2249, 5, 2263, 30, 2279, 3 });
        InsertRecipe(405, amirWeaponParchmentA, 1, new short[] { 290, 1, amirWeaponParchmentA, 1, 2044, 60, 2224, 50, 2251, 5, 2262, 3, 2275, 30 });
        InsertRecipe(408, amirWeaponParchmentA, 1, new short[] { 294, 1, amirWeaponParchmentA, 1, 2036, 60, 2218, 50, 2222, 3, 2250, 5, 2276, 30 });
        InsertRecipe(4722, amirWeaponParchmentA, 1, new short[] { 4720, 1, amirWeaponParchmentA, 1, 2036, 65, 2218, 50, 2250, 5, 2249, 5 });
        InsertRecipe(4760, amirWeaponParchmentA, 1, new short[] { 4759, 1, amirWeaponParchmentA, 1, 2040, 60, 2217, 50, 2249, 7, 2262, 5, 2275, 40 });

        // Amir's Weapon Parchment B
        InsertRecipe(401, amirWeaponParchmentB, 1, new short[] { 400, 1, amirWeaponParchmentB, 1, 2037, 99, 2222, 3, 2231, 70, 2257, 99 });
        InsertRecipe(404, amirWeaponParchmentB, 1, new short[] { 403, 1, amirWeaponParchmentB, 1, 2041, 99, 2219, 3, 2226, 70, 2277, 99 });
        InsertRecipe(407, amirWeaponParchmentB, 1, new short[] { 406, 1, amirWeaponParchmentB, 1, 2049, 99, 2245, 3, 2261, 70, 2269, 99 });
        InsertRecipe(4724, amirWeaponParchmentB, 1, new short[] { 4722, 1, amirWeaponParchmentB, 1, 2049, 99, 2222, 3, 2277, 70, 2257, 70 });

        // Amir's Weapon Specifications
        InsertRecipe(349, amirWeaponSpecifications, 1, new short[] { amirWeaponSpecifications, 1, 2241, 5, 2247, 35, 2266, 80 });
        InsertRecipe(353, amirWeaponSpecifications, 1, new short[] { amirWeaponSpecifications, 1, 2232, 80, 2259, 35, 2272, 5 });
        InsertRecipe(356, amirWeaponSpecifications, 1, new short[] { amirWeaponSpecifications, 1, 2228, 35, 2244, 80, 2258, 5 });
        InsertRecipe(4725, amirWeaponSpecifications, 1, new short[] { amirWeaponSpecifications, 1, 2241, 5, 2247, 35, 2266, 80 });
        InsertRecipe(4726, amirWeaponSpecifications, 1, new short[] { amirWeaponSpecifications, 1, 2232, 80, 2259, 35, 2272, 5 });
        InsertRecipe(352, amirWeaponSpecifications, 1, new short[] { 402, 1, amirWeaponSpecifications, 1, 2045, 60, 2230, 70, 2238, 3, 2244, 70, 2247, 99 });
        InsertRecipe(351, amirWeaponSpecifications, 1, new short[] { 405, 1, amirWeaponSpecifications, 1, 2037, 60, 2237, 3, 2243, 70, 2266, 70, 2274, 99 });
        InsertRecipe(355, amirWeaponSpecifications, 1, new short[] { 408, 1, amirWeaponSpecifications, 1, 2049, 60, 2225, 70, 2232, 70, 2236, 3, 2273, 99 });
        InsertRecipe(4761, amirWeaponSpecifications, 1, new short[] { 4760, 1, amirWeaponSpecifications, 1, 2045, 60, 2230, 70, 2238, 5, 2244, 60, 2247, 80 });

        // Amir's Weapon Specification Book Cover
        InsertRecipe(amirWeaponSpecifications, amirWeaponSpecificationBookCover, 1, new short[] { amirArmourParchment, 10, amirWeaponParchmentA, 10, amirWeaponParchmentB, 10, amirWeaponSpecificationBookCover, 1 });

        // Basilisk Time-Space Piece
        InsertRecipe(1833, basiliskTimeSpacePiece, 1, new short[] { basiliskTimeSpacePiece, 1 });

        // Hell Knight Time-Space Piece
        InsertRecipe(1834, hellKnightTimeSpacePiece, 1, new short[] { hellKnightTimeSpacePiece, 1 });
        InsertRecipe(1835, hellKnightTimeSpacePiece, 1, new short[] { hellKnightTimeSpacePiece, 1 });
        InsertRecipe(1836, hellKnightTimeSpacePiece, 1, new short[] { hellKnightTimeSpacePiece, 1 });

        // Treekun Time-Space Piece
        InsertRecipe(1837, treekunTimeSpacePiece, 1, new short[] { treekunTimeSpacePiece, 1 });
        InsertRecipe(1838, treekunTimeSpacePiece, 1, new short[] { treekunTimeSpacePiece, 1 });
        InsertRecipe(1839, treekunTimeSpacePiece, 1, new short[] { treekunTimeSpacePiece, 1 });

        // Chrysos Time-Space Piece
        InsertRecipe(1840, chrysosTimeSpacePiece, 1, new short[] { chrysosTimeSpacePiece, 1 });
        InsertRecipe(1841, chrysosTimeSpacePiece, 1, new short[] { chrysosTimeSpacePiece, 1 });
        InsertRecipe(1842, chrysosTimeSpacePiece, 1, new short[] { chrysosTimeSpacePiece, 1 });

        // Robber Gang's Blueprints
        InsertRecipe(4034, robberGangBlueprints, 1, new short[] { 2353, 20, 2356, 5, 2359, 5, 2371, 2, robberGangBlueprints, 1 });
        InsertRecipe(4035, robberGangBlueprints, 1, new short[] { 2353, 20, 2356, 5, 2360, 5, 2371, 2, robberGangBlueprints, 1 });

        // Ancelloan's Accessory Production Scroll
        InsertRecipe(4942, ancelloanAccessoryProductionScroll, 1, new short[] { 4940, 1, 2805, 15, 2816, 5, 5881, 5, 2811, 30, ancelloanAccessoryProductionScroll, 1 });
        InsertRecipe(4943, ancelloanAccessoryProductionScroll, 1, new short[] { 4938, 1, 2805, 10, 2816, 3, 5881, 3, 2811, 20, ancelloanAccessoryProductionScroll, 1 });
        InsertRecipe(4944, ancelloanAccessoryProductionScroll, 1, new short[] { 4936, 1, 2805, 12, 2816, 4, 5881, 4, 2811, 25, ancelloanAccessoryProductionScroll, 1 });
        InsertRecipe(4946, ancelloanAccessoryProductionScroll, 1, new short[] { 4940, 1, 2805, 15, 2816, 5, 5880, 5, 2811, 30, ancelloanAccessoryProductionScroll, 1 });
        InsertRecipe(4947, ancelloanAccessoryProductionScroll, 1, new short[] { 4938, 1, 2805, 10, 2816, 3, 5880, 3, 2811, 20, ancelloanAccessoryProductionScroll, 1 });
        InsertRecipe(4948, ancelloanAccessoryProductionScroll, 1, new short[] { 4936, 1, 2805, 12, 2816, 4, 5880, 4, 2811, 25, ancelloanAccessoryProductionScroll, 1 });

        // Ancelloan's Weapon Production Scroll
        InsertRecipe(4958, ancelloanWeaponProductionScroll, 1, new short[] { 4901, 1, 2805, 80, 2816, 60, 5880, 70, 2812, 35, ancelloanWeaponProductionScroll, 1 });
        InsertRecipe(4959, ancelloanWeaponProductionScroll, 1, new short[] { 4907, 1, 2805, 80, 2816, 60, 5880, 70, 2812, 35, ancelloanWeaponProductionScroll, 1 });
        InsertRecipe(4960, ancelloanWeaponProductionScroll, 1, new short[] { 4904, 1, 2805, 80, 2816, 60, 5880, 70, 2812, 35, ancelloanWeaponProductionScroll, 1 });
        InsertRecipe(4964, ancelloanWeaponProductionScroll, 1, new short[] { 4901, 1, 2805, 80, 2816, 60, 5881, 70, 2812, 35, ancelloanWeaponProductionScroll, 1 });
        InsertRecipe(4965, ancelloanWeaponProductionScroll, 1, new short[] { 4907, 1, 2805, 80, 2816, 60, 5881, 70, 2812, 35, ancelloanWeaponProductionScroll, 1 });
        InsertRecipe(4966, ancelloanWeaponProductionScroll, 1, new short[] { 4904, 1, 2805, 80, 2816, 60, 5881, 70, 2812, 35, ancelloanWeaponProductionScroll, 1 });
        InsertRecipe(4735, ancelloanWeaponProductionScroll, 1, new short[] { 4904, 1, 2805, 85, 2816, 60, 5880, 75, 5881, 75, 2812, 40, ancelloanWeaponProductionScroll, 1 });

        // Ancelloan's Secondary Weapon Production Scroll
        InsertRecipe(4955, ancelloanSecondaryWeaponProductionScroll, 1, new short[] { 4910, 1, 2805, 90, 2816, 35, 5880, 55, 2811, 90, ancelloanSecondaryWeaponProductionScroll, 1 });
        InsertRecipe(4956, ancelloanSecondaryWeaponProductionScroll, 1, new short[] { 4916, 1, 2805, 90, 2816, 35, 5880, 55, 2811, 90, ancelloanSecondaryWeaponProductionScroll, 1 });
        InsertRecipe(4957, ancelloanSecondaryWeaponProductionScroll, 1, new short[] { 4913, 1, 2805, 90, 2816, 35, 5880, 55, 2811, 90, ancelloanSecondaryWeaponProductionScroll, 1 });
        InsertRecipe(4968, ancelloanSecondaryWeaponProductionScroll, 1, new short[] { 4766, 1, 2805, 90, 2816, 35, 5880, 60, 2811, 90, ancelloanSecondaryWeaponProductionScroll, 1 });
        InsertRecipe(4961, ancelloanSecondaryWeaponProductionScroll, 1, new short[] { 4910, 1, 2805, 90, 2816, 35, 5881, 55, 2811, 90, ancelloanSecondaryWeaponProductionScroll, 1 });
        InsertRecipe(4962, ancelloanSecondaryWeaponProductionScroll, 1, new short[] { 4916, 1, 2805, 90, 2816, 35, 5881, 55, 2811, 90, ancelloanSecondaryWeaponProductionScroll, 1 });
        InsertRecipe(4963, ancelloanSecondaryWeaponProductionScroll, 1, new short[] { 4913, 1, 2805, 90, 2816, 35, 5881, 55, 2811, 90, ancelloanSecondaryWeaponProductionScroll, 1 });
        InsertRecipe(4769, ancelloanSecondaryWeaponProductionScroll, 1, new short[] { 4766, 1, 2805, 90, 2816, 30, 5881, 60, 2811, 90, ancelloanSecondaryWeaponProductionScroll, 1 });

        // Ancelloan's Armour Production Scroll
        InsertRecipe(4949, ancelloanArmourProductionScroll, 1, new short[] { 4919, 1, 2805, 80, 2816, 40, 5880, 10, 2818, 20, 2819, 10, 2811, 70, ancelloanArmourProductionScroll, 1 });
        InsertRecipe(4950, ancelloanArmourProductionScroll, 1, new short[] { 4925, 1, 2805, 60, 2816, 15, 5880, 10, 2814, 70, 2818, 10, 2819, 20, ancelloanArmourProductionScroll, 1 });
        InsertRecipe(4951, ancelloanArmourProductionScroll, 1, new short[] { 4922, 1, 2805, 70, 2816, 30, 5880, 70, 2814, 35, 2818, 15, 2819, 15, 2811, 35, ancelloanArmourProductionScroll, 1 });
        InsertRecipe(4952, ancelloanArmourProductionScroll, 1, new short[] { 4919, 1, 2805, 80, 2816, 40, 5881, 10, 2818, 20, 2819, 10, 2811, 90, ancelloanArmourProductionScroll, 1 });
        InsertRecipe(4953, ancelloanArmourProductionScroll, 1, new short[] { 4925, 1, 2805, 60, 2816, 15, 5881, 10, 2814, 70, 2818, 10, 2819, 20, ancelloanArmourProductionScroll, 1 });
        InsertRecipe(4954, ancelloanArmourProductionScroll, 1, new short[] { 4922, 1, 2805, 70, 2816, 30, 5881, 70, 2814, 35, 2818, 15, 2819, 15, 2811, 35, ancelloanArmourProductionScroll, 1 });
        InsertRecipe(4753, ancelloanArmourProductionScroll, 1, new short[] { 4751, 1, 2805, 77, 2816, 25, 5880, 77, 2814, 77, 2818, 30, 2819, 10, 2811, 40, ancelloanArmourProductionScroll, 1 });

        // Charred Mask Parchment
        InsertRecipe(4927, charredMaskParchment, 1, new short[] { 2505, 3, 2506, 2, 2353, 30, 2355, 20, charredMaskParchment, 1 });
        InsertRecipe(4928, charredMaskParchment, 1, new short[] { 2505, 10, 2506, 8, 2507, 1, 2353, 90, 2356, 60, charredMaskParchment, 3 });

        // Grenigas Accessories Parchment
        InsertRecipe(4936, grenigasAccessoriesParchment, 1, new short[] { 4935, 1, 2505, 4, 2506, 4, 2359, 20, 2360, 20, grenigasAccessoriesParchment, 1, 2509, 5 });
        InsertRecipe(4938, grenigasAccessoriesParchment, 1, new short[] { 4937, 1, 2505, 6, 2506, 2, 2359, 20, 2360, 20, grenigasAccessoriesParchment, 1, 2510, 5 });
        InsertRecipe(4940, grenigasAccessoriesParchment, 1, new short[] { 4939, 1, 2505, 2, 2506, 6, 2359, 20, 2360, 20, grenigasAccessoriesParchment, 1, 2508, 5 });

        // Orc Loa Accessories Production Scroll
        InsertRecipe(4514, orcLoaAccessoriesProductionScroll, 1, new short[] { 4513, 1, 2411, 100, 2412, 10, 2408, 65, 2406, 65, orcLoaAccessoriesProductionScroll, 1 });
        InsertRecipe(4518, orcLoaAccessoriesProductionScroll, 1, new short[] { 4517, 1, 2410, 60, 2413, 10, 2406, 65, 2366, 60, orcLoaAccessoriesProductionScroll, 1 });
        InsertRecipe(4522, orcLoaAccessoriesProductionScroll, 1, new short[] { 4521, 1, 2408, 60, 2413, 10, 2406, 65, 2366, 60, orcLoaAccessoriesProductionScroll, 1 });

        // Orc Loa Weapons Production Scroll
        InsertRecipe(4449, orcLoaWeaponsProductionScroll, 1, new short[] { 4448, 1, 2416, 300, 2406, 200, 2430, 40, 2432, 1, 2474, 10, orcLoaWeaponsProductionScroll, 2 });
        InsertRecipe(4452, orcLoaWeaponsProductionScroll, 1, new short[] { 4451, 1, 2416, 300, 2415, 25, 2430, 45, 2432, 1, 2474, 10, orcLoaWeaponsProductionScroll, 2 });
        InsertRecipe(4455, orcLoaWeaponsProductionScroll, 1, new short[] { 4454, 1, 2416, 300, 2406, 40, 2408, 250, 2412, 10, 2474, 10, orcLoaWeaponsProductionScroll, 2 });
        InsertRecipe(4458, orcLoaWeaponsProductionScroll, 1, new short[] { 4457, 1, 2416, 300, 2406, 40, 2366, 140, 2413, 10, 2474, 10, orcLoaWeaponsProductionScroll, 2 });

        // Orc Loa Secondary Weapons Production Scroll
        InsertRecipe(4465, orcLoaSecondaryWeaponsProductionScroll, 1, new short[] { 4460, 1, 2408, 135, 2430, 40, 2416, 150, 2413, 5, orcLoaSecondaryWeaponsProductionScroll, 1 });
        InsertRecipe(4468, orcLoaSecondaryWeaponsProductionScroll, 1, new short[] { 4467, 1, 2366, 250, 2406, 100, 2416, 150, 2432, 1, orcLoaSecondaryWeaponsProductionScroll, 1 });
        InsertRecipe(4471, orcLoaSecondaryWeaponsProductionScroll, 1, new short[] { 4470, 1, 2408, 250, 2406, 40, 2416, 150, 2412, 5, orcLoaSecondaryWeaponsProductionScroll, 1 });
        InsertRecipe(4474, orcLoaSecondaryWeaponsProductionScroll, 1, new short[] { 4473, 1, 2411, 250, 2406, 40, 2410, 150, 2413, 10, orcLoaSecondaryWeaponsProductionScroll, 1 });

        // Orc Loa Armour Production Scroll
        InsertRecipe(4477, orcLoaArmourProductionScroll, 1, new short[] { 4476, 1, 2430, 40, 2398, 30, 2410, 180, 2408, 135, 2416, 300, 2366, 250, 2474, 10, orcLoaArmourProductionScroll, 1 });
        InsertRecipe(4480, orcLoaArmourProductionScroll, 1, new short[] { 4479, 1, 2430, 40, 2406, 100, 2413, 20, 2408, 200, 2416, 300, 2459, 150, 2474, 10, orcLoaArmourProductionScroll, 1 });
        InsertRecipe(4483, orcLoaArmourProductionScroll, 1, new short[] { 4482, 1, 2366, 250, 2466, 50, 2416, 300, 2406, 200, 2464, 30, 2460, 200, 2474, 10, orcLoaArmourProductionScroll, 1 });
        InsertRecipe(4506, orcLoaArmourProductionScroll, 1, new short[] { 4505, 1, 2366, 140, 2416, 450, 2406, 40, 2407, 100, 2411, 300, 2459, 150, 2474, 10, orcLoaArmourProductionScroll, 1 });

        // Old Viking Costume (7 Days) - Sketch
        InsertRecipe(4308, oldVikingCostume7DaysSketch, 1, new short[] { 2048, 10, 2044, 10, 2208, 10, 2200, 10, oldVikingCostume7DaysSketch, 1 });

        // Fafnir's Bugle Blueprints
        InsertRecipe(2611, fafnirBugleBlueprints, 1, new short[] { 2606, 50, 2608, 50, 2607, 50, 2605, 50, 2610, 1, fafnirBugleBlueprints, 1 });
    }

    private static void InsertRecipe(short itemVNum, short triggerVNum, short amount = 1, short[] recipeItems = null)
    {
        var imprecipe = ImportedLists.RecipesItemList.FirstOrDefault(s => s.Identity.Equals(triggerVNum));
        if (imprecipe == null)
        {
            ImportedLists.RecipesItemList.Add(new()
            {
                Identity = triggerVNum
            });
            imprecipe = ImportedLists.RecipesItemList.FirstOrDefault(s => s.Identity.Equals(triggerVNum));
        }

        RecipeObject recobj = new()
        {
            ProducerItemVnum = imprecipe.Identity,
            ItemVnum = itemVNum,
            Quantity = amount
        };

        for (int i = 0; i < recipeItems.Length; i += 2)
        {
            recobj.Items.Add(new()
            {
                ItemVnum = recipeItems[i],
                Quantity = recipeItems[i + 1]
            });
        }

        recobj.Items.OrderBy(s => s.ItemVnum);
        imprecipe.Recipes.Add(recobj);
    }
}