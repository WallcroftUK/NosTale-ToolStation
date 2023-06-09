// Zro

using System.Linq;
using ToolStationGUI.Windows.ConfigsTool.Entities.ImportFiles;
using ToolStationGUI.Windows.ConfigsTool.Entities.Objects;

namespace ToolStationGUI.Windows.ConfigsTool.Import;

public class ImportNpcRecipes
{
    public static void Import()
    {
        var count = 0;
        var mapNpcId = 0;
        short itemVNum = 0;
        RecipeImportFile Recipe = null;

        foreach (var currentPacket in ImportedLists.Packets.Where(o => o[0].Equals("n_run") || o[0].Equals("pdtse") || o[0].Equals("m_list")))
        {
            if (currentPacket.Length > 4 && currentPacket[0] == "n_run")
            {
                int.TryParse(currentPacket[4], out mapNpcId);
                continue;
            }

            if (currentPacket.Length > 1 && currentPacket[0] == "m_list" && (currentPacket[1] == "2" || currentPacket[1] == "4"))
            {
                for (var i = 2; i < currentPacket.Length - 1; i++)
                {
                    Recipe = ImportedLists.RecipesNpcList.FirstOrDefault(s => s.Identity.Equals(mapNpcId));
                    if (Recipe == null)
                    {
                        ImportedLists.RecipesNpcList.Add(new()
                        {
                            Identity = mapNpcId
                        });
                        Recipe = ImportedLists.RecipesNpcList.FirstOrDefault(s => s.Identity.Equals(mapNpcId));
                    }

                    Recipe.Recipes.Add(new()
                    {
                        ItemVnum = short.Parse(currentPacket[i]),
                        ProducerMapNpcId = mapNpcId
                    });
                }
                continue;
            }

            if (currentPacket.Length > 2 && currentPacket[0] == "pdtse")
            {
                itemVNum = short.Parse(currentPacket[2]);
                continue;
            }

            if (currentPacket.Length <= 1 || currentPacket[0] != "m_list" || currentPacket[1] != "3" && currentPacket[1] != "5")
            {
                continue;
            }

            RecipeObject recobj = Recipe.Recipes.FirstOrDefault(s => s.ItemVnum.Equals(itemVNum));

            if (recobj == null)
            {
                continue;
            }

            recobj.Quantity = byte.Parse(currentPacket[2]);
            for (var i = 3; i < currentPacket.Length - 1; i += 2)
            {
                recobj.Items.Add(new()
                {
                    ItemVnum = short.Parse(currentPacket[i]),
                    Quantity = short.Parse(currentPacket[i + 1])
                });
            }

            recobj.Items.OrderBy(s => s.ItemVnum);

            itemVNum = -1;
        }
    }
}