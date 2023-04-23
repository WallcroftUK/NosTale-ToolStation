using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LuaToolGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Fields to store the generated map names
        private ObservableCollection<string> mapNames = new ObservableCollection<string>();

        private Dictionary<string, Tuple<string, string>> portalConnections = new Dictionary<string, Tuple<string, string>>();

        // Method to populate the FromMapComboBox and ToMapComboBox with the generated map names
        private void PopulateMapComboBoxes()
        {
            FromMapComboBox.ItemsSource = mapNames;
            ToMapComboBox.ItemsSource = mapNames;
            spawnMapComboBox.ItemsSource = mapNames;
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            PopulateMapComboBoxes();
        }

        private void ObjectivesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StringBuilder luaCode = new StringBuilder();
            luaCode.AppendLine("local Map = require('Map')");
            luaCode.AppendLine("local Monster = require('Monster')");
            luaCode.AppendLine("local Event = require('Event')");
            luaCode.AppendLine("local MapObject = require('MapObject')");
            luaCode.AppendLine("local MapNpc = require('MapNpc')");
            luaCode.AppendLine("local Portal = require('Portal')");
            luaCode.AppendLine("local Location = require('Location')");
            luaCode.AppendLine("local TimeSpace = require('TimeSpace')");
            luaCode.AppendLine("local PortalType = require('PortalType')");
            luaCode.AppendLine("local PortalMinimapOrientation = require('PortalMinimapOrientation')");
            luaCode.AppendLine("local TimeSpaceObjective = require('TimeSpaceObjective')");
            luaCode.AppendLine("local TimeSpaceTaskType = require('TimeSpaceTaskType')");
            luaCode.AppendLine("local TimeSpaceTask = require('TimeSpaceTask')");
            luaCode.AppendLine("local TimeSpaceFinishType = require('TimeSpaceFinishType')");
            luaCode.AppendLine("");
            luaCode.AppendLine("local objectives = TimeSpaceObjective.Create()");

            foreach (ListBoxItem item in ObjectivesList.SelectedItems)
            {
                switch (item.Content.ToString())
                {
                    case "KillAllMonsters":
                        luaCode.AppendLine(".WithKillAllMonsters()");
                        break;

                    case "GoToExit":
                        luaCode.AppendLine(".WithGoToExit()");
                        break;

                    case "KillMonsterVnum":
                        luaCode.AppendLine(".WithKillMob(vnum, amount)");
                        break;

                    case "KillMonsterAmount":
                        luaCode.AppendLine(".WithKillMonsterAmount(amount)");
                        break;

                    case "CollectItemVnum":
                        luaCode.AppendLine(".WithCollectItem(vnum, amount)");
                        break;

                    case "CollectItemAmount":
                        luaCode.AppendLine(".WithCollectItemAmount(amount)");
                        break;

                    case "Conversation":
                        luaCode.AppendLine(".WithConversations(amount)");
                        break;

                    case "InteractObjectsVnum":
                        luaCode.AppendLine(".WithInteractObjects(vnum, amount)");
                        break;

                    case "InteractObjectsAmount":
                        luaCode.AppendLine(".WithInteractObjectsAmount(amount)");
                        break;

                    case "ProtectNPC":
                        luaCode.AppendLine(".WithProtectNPC()");
                        break;
                }
            }

            LuaCodeTextBox.Text = luaCode.ToString();
        }

        private void AddMapButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder luaCode = new StringBuilder();
            var selectedObjectives = ObjectivesList.SelectedItems.Cast<ListBoxItem>().Select(item => item.Content.ToString());

            luaCode.AppendLine("");

            // Get the map coordinates and map ID from the input fields
            string mapId = MapIdTextBox.Text;
            string mapX = XCoordTextBox.Text;
            string mapY = YCoordTextBox.Text;
            string mapName = MapNameTextBox.Text;
            string task = TaskTypeComboBox.Text;

            // Create the Lua code for adding the map
            luaCode.AppendLine($"local {mapName} = Map.Create().WithMapId({mapId}).SetMapCoordinates({mapX}, {mapY}).WithTask(TimeSpaceTask.Create(TimeSpaceTaskType.{task}))");

            LuaCodeTextBox.Text += luaCode.ToString();

            mapNames.Add(mapName); // Add the new map to the mapNames list

            // Update the ItemsSource of the FromMapComboBox and ToMapComboBox
            CollectionViewSource.GetDefaultView(FromMapComboBox.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(ToMapComboBox.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(spawnMapComboBox.ItemsSource).Refresh();
        }

        private void AddPortalButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder luaCode = new StringBuilder();

            // Get the portal properties from the input fields
            string portalName = PortalNameTextBox.Text;
            string portalType = PortalTypeComboBox.Text;
            string fromMap = FromMapComboBox.SelectedValue.ToString();
            string fromX = FromXTextBox.Text;
            string fromY = FromYTextBox.Text;
            string toMap = ToMapComboBox.SelectedValue.ToString();
            string toX = ToXTextBox.Text;
            string toY = ToYTextBox.Text;
            string minimapOrientation = MinimapOrientationComboBox.Text;

            // Create the Lua code for adding the portal
            string portal = $"local {portalName} = Portal.Create((PortalType){portalType}).From({fromMap}, {fromX}, {fromY}).To({toMap}, {toX}, {toY}).MinimapOrientation((PortalMinimapOrientation){minimapOrientation})";

            // Append the Lua code to the text box
            luaCode.AppendLine(portal);

            // Store the portal connection in the dictionary
            portalConnections[portalName] = new Tuple<string, string>(fromMap, toMap);

            LuaCodeTextBox.Text += luaCode.ToString();

            // Clear the input fields
            PortalNameTextBox.Clear();
            PortalTypeComboBox.SelectedIndex = 0;
            FromMapComboBox.SelectedIndex = 0;
            FromXTextBox.Clear();
            FromYTextBox.Clear();
            ToMapComboBox.SelectedIndex = 0;
            ToXTextBox.Clear();
            ToYTextBox.Clear();
            MinimapOrientationComboBox.SelectedIndex = 0;
        }

        private void PopulateButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder luaCode = new StringBuilder();

            foreach (var portalConnection in portalConnections)
            {
                string portalName = portalConnection.Key;
                string fromMap = portalConnection.Value.Item1;

                // Generate the Lua code for adding the portal
                string luaPortalCode = $"{fromMap}.AddPortal({portalName})";
                luaCode.AppendLine(luaPortalCode);
            }

            // Display the generated Lua code
            LuaCodeTextBox.Text += luaCode.ToString();
        }

        private void AddMonstersButton_Click(object sender, RoutedEventArgs e)
        {
            AddMonstersWindow addMonstersWindow = new AddMonstersWindow(mapNames);
            if (addMonstersWindow.ShowDialog() == true)
            {
                string script = LuaCodeTextBox.Text;
                script += addMonstersWindow.GeneratedScript;
                LuaCodeTextBox.Text = script;
            }
        }

        private void AddEndOfScriptButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder luaCode = new StringBuilder();
            luaCode.Append("local ts = TimeSpace.Create(" + tsIDBox.Text + ")  -- TimeSpace ID\n");
            luaCode.Append("\t.SetMaps({");
            foreach (string mapName in mapNames)
            {
                luaCode.Append(mapName + ", ");
            }
            luaCode.Remove(luaCode.Length - 2, 2);
            luaCode.Append("})\n");
            luaCode.Append("\t.SetSpawn(Location.InMap(" + spawnMapComboBox.SelectedValue.ToString() + ").At(" + spawnXTextBox.Text + ", " + spawnYTextBox.Text + "))\n");
            luaCode.Append("\t.SetLives(" + livesTextBox.Text + ")\n");
            luaCode.Append("\t.SetObjectives(objectives)\n");
            luaCode.Append("\t.SetDurationInSeconds(" + durationTextBox.Text + ")\n");
            luaCode.Append("\t.SetBonusPointItemDropChance(" + bonusChanceTextBox.Text + ")\n");
            luaCode.Append("return ts\n");

            LuaCodeTextBox.Text += luaCode.ToString();
        }
    }
}