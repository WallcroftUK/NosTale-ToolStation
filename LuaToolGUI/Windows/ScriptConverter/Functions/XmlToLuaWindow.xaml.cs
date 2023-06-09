using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToolStationGUI.Windows.ScriptConverter.Enums;
using ToolStationGUI.Windows.ScriptConverter.Import;
using Ookii.Dialogs.Wpf;
using MessageBox = System.Windows.MessageBox;
using ToolGUI.Windows;

namespace ToolStationGUI.Windows.ScriptConverter.Functions
{
    public partial class XmlToLuaWindow : Window
    {
        // Default paths for saving raids and timespaces
        private string raidsPath = "Raids";
        private string timespacesPath = "TimeSpaces";

        public XmlToLuaWindow()
        {
            InitializeComponent();
        }

        // Button click event for converting XML to Lua
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string xmlContent = XmlCodeTextBox.Text;

            if (RaidRadioButton.IsChecked == true)
            {
                ImportXmlScript.ImportRaids(xmlContent);
                foreach (var model in ImportedLists.ScriptsList)
                {
                    RaidType rType = (RaidType)model.Globals.Id.Value;
                    File.WriteAllText(Path.Combine(raidsPath, (RaidType)model.Globals.Id.Value + ".lua"), model.ToRaidLuaString());
                    MessageBox.Show($"Created raid: {rType.ToString()}");
                }
                MessageBox.Show("Raids imported successfully!");
            }
            else if (TimeSpaceRadioButton.IsChecked == true)
            {
                ImportXmlScript.ImportTimespaces(xmlContent);
                int i = 0;
                foreach (var model in ImportedLists.ScriptsList)
                {
                    string finalTitle = model.Globals.Title.Value != string.Empty ? model.Globals.Title.Value.Replace(" ", "_").Replace("-", "_") : i.ToString();
                    File.WriteAllText(Path.Combine(timespacesPath, finalTitle + ".lua"), model.ToTsLuaString());
                    MessageBox.Show($"Created ts: {finalTitle}");
                    i++;
                }
                MessageBox.Show("Timespaces imported successfully!");
            }
            else
            {
                MessageBox.Show("Please select Raid or TimeSpace.");
            }
        }

        // Button click event for selecting the folder to save raids
        private void SelectRaidsFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Select the folder to save the raids";
            dialog.UseDescriptionForTitle = true;

            if (dialog.ShowDialog() == true)
            {
                raidsPath = dialog.SelectedPath;
            }
            else
            {
                MessageBox.Show("Folder for raids was not selected.", "Folder Not Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Button click event for selecting the folder to save timespaces
        private void SelectTimespacesFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Select the folder to save the timespaces";
            dialog.UseDescriptionForTitle = true;

            if (dialog.ShowDialog() == true)
            {
                timespacesPath = dialog.SelectedPath;
            }
            else
            {
                MessageBox.Show("Folder for timespaces was not selected.", "Folder Not Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Button click event for going back to the main menu
        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            InitialMenuWindow initialMenuWindow = new InitialMenuWindow();
            initialMenuWindow.Show();
            Close();
        }
    }
}
