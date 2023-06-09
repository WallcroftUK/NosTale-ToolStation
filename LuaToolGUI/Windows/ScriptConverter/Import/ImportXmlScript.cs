using System.IO;
using System.Xml.Serialization;
using ToolStationGUI.Windows.ScriptConverter.Models.ScriptedInstance;

namespace ToolStationGUI.Windows.ScriptConverter.Import
{
    public class ImportXmlScript
    {
        public static void ImportRaids(string xmlContent)
        {
            CreateList(xmlContent);
        }

        public static void ImportTimespaces(string xmlContent)
        {
            CreateList(xmlContent);
        }

        static void CreateList(string xmlContent)
        {
            // Replace "True" with "true" and "False" with "false"
            xmlContent = xmlContent.Replace("True", "true").Replace("False", "false");

            XmlSerializer serializer = new XmlSerializer(typeof(ScriptedInstanceModel));
            using StringReader textReader = new StringReader(xmlContent);
            ImportedLists.ScriptsList.Add((ScriptedInstanceModel)serializer.Deserialize(textReader));
        }
    }
}
