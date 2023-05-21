using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace LuaToolGUI
{
    public partial class EventWindow : Window
    {
        private Dictionary<string, Tuple<string, string>> portalConnections;
        private TextBox luaCodeTextBox;
        private ObservableCollection<string> mapNames;

        public EventWindow(Dictionary<string, Tuple<string, string>> portalConnections, TextBox luaCodeTextBox, ObservableCollection<string> mapNames)
        {
            InitializeComponent();

            this.portalConnections = portalConnections;
            this.luaCodeTextBox = luaCodeTextBox;
            this.mapNames = mapNames;

            // Populate the EventNameComboBox
            EventNameComboBox.ItemsSource = Enum.GetValues(typeof(EventName));
            MapTaskTypeComboBox.ItemsSource = Enum.GetValues(typeof(MapTasks));
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder luaCode = new StringBuilder();
            luaCode.AppendLine("");

            // Get the map coordinates and map ID from the input fields
            string mapName = MapNameComboBox.SelectedItem?.ToString();
            EventName eventName = (EventName)EventNameComboBox.SelectedItem;
            MapTasks mapTaskType = (MapTasks)MapTaskTypeComboBox.SelectedItem;

            if (string.IsNullOrEmpty(mapName))
            {
                // Handle error: No map name selected
                return;
            }

            // Append additional Lua code
            luaCode.AppendLine($"--- Map {mapName}");

            luaCode.AppendLine($"{mapName}.{mapTaskType}({{");

            if (eventName == EventName.OpenPortal)
            {
                // Handle Event.OpenPortal scenario
                foreach (var portalConnection in portalConnections)
                {
                    string fromPortal = portalConnection.Key;
                    luaCode.AppendLine($"Event.OpenPortal({fromPortal})");
                }
            }
            else if (eventName == EventName.TryStartTaskForMap)
            {
                // Handle Event.TryStartTaskForMap scenario
                luaCode.AppendLine($"Event.TryStartTaskForMap({mapName}),");
            }
            else if (eventName == EventName.DespawnAllMobsInRoom & mapTaskType == MapTasks.OnAllTargetMobsDead)
            {
                // Handle Event.DespawnAllMobsInRoom scenario
                luaCode.AppendLine($"Event.DespawnAllMobsInRoom({mapName}),");
            }
            else
            {
                // Handle other event scenarios
                luaCode.AppendLine($"Event.{eventName}({mapName}),");
            }
            luaCode.AppendLine($"}})");

            luaCode.AppendLine("---");

            // Update the Lua code in the luaCodeTextBox
            luaCodeTextBox.Text += luaCode.ToString();

            // Close the EventWindow
            this.Close();
        }

        private void EventNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EventNameComboBox.SelectedItem == null)
                return;

            EventName selectedEvent = (EventName)EventNameComboBox.SelectedItem;

            if (selectedEvent == EventName.OpenPortal)
            {
                MapNameComboBox.Visibility = Visibility.Collapsed;
                PortalNameComboBox.Visibility = Visibility.Visible;

                // Populate the portal names
                PortalNameComboBox.ItemsSource = portalConnections.Keys.ToList();
            }
            else if (selectedEvent == EventName.TryStartTaskForMap)
            {
                MapNameComboBox.Visibility = Visibility.Visible;
                PortalNameComboBox.Visibility = Visibility.Collapsed;

                // Populate the map names
                MapNameComboBox.ItemsSource = mapNames;
            }
            else
            {
                MapNameComboBox.Visibility = Visibility.Visible;
                PortalNameComboBox.Visibility = Visibility.Visible;

                // Populate both portal names and map names
                PortalNameComboBox.ItemsSource = portalConnections.Keys.ToList();
                MapNameComboBox.ItemsSource = mapNames;
            }
        }
    }
}