using LuaToolGUI.enums;
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

        // Create a class to represent an event
        public class MapEvent
        {
            public string MapName { get; set; }
            public EventName Event { get; set; }
            public MapTaskType MapTaskType { get; set; }
            public StringBuilder LuaCode { get; set; } // Add the LuaCode property
        }

        // Create a dictionary to store the events for each map
        Dictionary<string, List<MapEvent>> events = new Dictionary<string, List<MapEvent>>();

        private string currentMapName;
        private MapTaskType currentMapTaskType;
        private StringBuilder currentMapLuaCode;

        public EventWindow(Dictionary<string, Tuple<string, string>> portalConnections, TextBox luaCodeTextBox, ObservableCollection<string> mapNames)
        {
            InitializeComponent();

            this.portalConnections = portalConnections;
            this.luaCodeTextBox = luaCodeTextBox;
            this.mapNames = mapNames;

            // Populate the EventNameComboBox
            EventNameComboBox.ItemsSource = Enum.GetValues(typeof(EventName));
            MapTaskTypeComboBox.ItemsSource = Enum.GetValues(typeof(MapTaskType));
            MapNameComboBox.ItemsSource = mapNames;
            EventMapNameComboBox.ItemsSource = mapNames;
            // Inside the constructor or initialization method
            FinishTypeComboBox.ItemsSource = Enum.GetValues(typeof(TimeSpaceFinishType));
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EventMapNameComboBox.Text) || string.IsNullOrEmpty(EventNameComboBox.Text))
                return;

            EventName eventName = (EventName)EventNameComboBox.SelectedItem;
            MapTaskType mapTaskType = (MapTaskType)MapTaskTypeComboBox.SelectedItem;
            string mapName = EventMapNameComboBox.SelectedValue.ToString();
            string fromPortal = PortalNameComboBox.Text;

            // Check if we are adding events to the same map and task type
            if (mapName == currentMapName && mapTaskType == currentMapTaskType)
            {
                // Add the event to the current map's Lua code
                if (eventName == EventName.OpenPortal)
                {
                    // Handle Event.OpenPortal scenario
                    currentMapLuaCode.AppendLine($"    Event.{eventName}({fromPortal}),");
                }
                else if (eventName == EventName.AddTime || eventName == EventName.RemoveTime)
                {
                    // Handle Event.AddTime or Event.RemoveTime scenario
                    string timeValue = TimeTextBox.Text;
                    currentMapLuaCode.AppendLine($"    Event.{eventName}({timeValue}),");
                }
                else if (eventName == EventName.TryStartTaskForMap)
                {
                    // Handle Event.TryStartTaskForMap scenario
                    currentMapLuaCode.AppendLine($"    Event.{eventName}({mapName}),");
                }
                else if (eventName == EventName.DespawnAllMobsInRoom)
                {
                    // Handle Event.DespawnAllMobsInRoom scenario
                    currentMapLuaCode.AppendLine($"    Event.{eventName}({mapName}),");
                }
                else if (eventName == EventName.FinishTimeSpace)
                {
                    // Handle Event.FinishTimeSpace scenario
                    TimeSpaceFinishType finishType = (TimeSpaceFinishType)FinishTypeComboBox.SelectedItem;
                    currentMapLuaCode.AppendLine($"    Event.{eventName}(TimeSpaceFinishType.{finishType}),");
                }
            }
//            map_map_3_1.OnMapJoin({
//                Event.TryStartTaskForMap(map_3_1),
//}),
//    Event.AddTime(60),
//})
//---
            else
            {
                // Create a new map event
                MapEvent newEvent = new MapEvent
                {
                    MapName = mapName,
                    Event = eventName,
                    MapTaskType = mapTaskType,
                    LuaCode = new StringBuilder()
                };
                newEvent.LuaCode.AppendLine($"{mapName}.{mapTaskType}({{");
                if (eventName == EventName.OpenPortal )
                {
                    // Handle Event.OpenPortal scenario
                    newEvent.LuaCode.AppendLine($"    Event.OpenPortal({fromPortal}),");
                }
                else if (eventName == EventName.AddTime || eventName == EventName.RemoveTime)
                {
                    // Handle Event.AddTime or Event.RemoveTime scenario
                    string timeValue = TimeTextBox.Text;
                    newEvent.LuaCode.AppendLine($"    Event.{eventName}({timeValue}),");
                }
                else if (eventName == EventName.TryStartTaskForMap)
                {
                    // Handle Event.TryStartTaskForMap scenario
                    newEvent.LuaCode.AppendLine($"    Event.TryStartTaskForMap({mapName}),");
                }
                else if (eventName == EventName.DespawnAllMobsInRoom)
                {
                    // Handle Event.DespawnAllMobsInRoom scenario
                    newEvent.LuaCode.AppendLine($"    Event.DespawnAllMobsInRoom({mapName}),");
                }
                else if (eventName == EventName.FinishTimeSpace)
                {
                    // Handle Event.FinishTimeSpace scenario
                    TimeSpaceFinishType finishType = (TimeSpaceFinishType)FinishTypeComboBox.SelectedItem;
                    newEvent.LuaCode.AppendLine($"    Event.FinishTimeSpace(TimeSpaceFinishType.{finishType}),");
                }
                //newEvent.LuaCode.AppendLine("}),");

                // Add the new map event to the dictionary
                if (events.ContainsKey(mapName))
                {
                    events[mapName].Add(newEvent);
                }
                else
                {
                    events[mapName] = new List<MapEvent> { newEvent };
                }

                // Update the current map information
                currentMapName = mapName;
                currentMapTaskType = mapTaskType;
                currentMapLuaCode = newEvent.LuaCode;
            }

            // Update the Lua code in the luaCodeTextBox
            UpdateLuaCode();

            // Clear the input fields
            EventMapNameComboBox.SelectedIndex = -1;
            EventNameComboBox.SelectedIndex = -1;
            MapTaskTypeComboBox.SelectedIndex = -1;
            TimeTextBox.Text = "";
            MapNameComboBox.SelectedIndex = -1;
            FinishTypeComboBox.SelectedIndex = -1;
        }



        private void CloseMapButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentMapName))
                return;

            // Add the closing bracket to the current map's Lua code
            currentMapLuaCode.AppendLine("})");

            // Reset the current map information
            currentMapName = "";
            currentMapTaskType = MapTaskType.None;
            currentMapLuaCode = null;

            // Update the Lua code in the luaCodeTextBox
            UpdateLuaCode();
        }

        private void UpdateLuaCode()
        {
            // Generate the complete Lua code for events
            StringBuilder eventLuaCode = new StringBuilder();
            foreach (List<MapEvent> mapEvents in events.Values)
            {
                foreach (MapEvent mapEvent in mapEvents)
                {
                    eventLuaCode.AppendLine($"--- {mapEvent.MapName}");
                    eventLuaCode.Append(mapEvent.LuaCode);
                    eventLuaCode.AppendLine("---");
                }
            }

            // Update the eventLuaCodeTextBox with the generated event Lua code
            eventLuaCodeTextBox.Text = eventLuaCode.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Pass the generated event code to the main Lua code textbox
            luaCodeTextBox.Text += eventLuaCodeTextBox.Text;

            // Close the Event Window
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
                TimeTextBox.Visibility = Visibility.Collapsed;

                // Populate the portal names
                PortalNameComboBox.ItemsSource = portalConnections.Keys.ToList();
            }
            else if (selectedEvent == EventName.TryStartTaskForMap)
            {
                MapNameComboBox.Visibility = Visibility.Visible;
                PortalNameComboBox.Visibility = Visibility.Collapsed;
                TimeTextBox.Visibility = Visibility.Collapsed;

                // Populate the map names
                MapNameComboBox.ItemsSource = mapNames;
            }
            else if (selectedEvent == EventName.AddTime || selectedEvent == EventName.RemoveTime)
            {
                MapNameComboBox.Visibility = Visibility.Visible;
                PortalNameComboBox.Visibility = Visibility.Collapsed;
                TimeTextBox.Visibility = Visibility.Visible;

                // Clear the TimeTextBox
                TimeTextBox.Text = "";
            }
            else
            {
                MapNameComboBox.Visibility = Visibility.Visible;
                PortalNameComboBox.Visibility = Visibility.Visible;
                TimeTextBox.Visibility = Visibility.Collapsed;

                // Populate both portal names and map names
                PortalNameComboBox.ItemsSource = portalConnections.Keys.ToList();
                MapNameComboBox.ItemsSource = mapNames;
            }
        }
        public void CleanEvents()
        {
            events.Clear();
        }
    }
}
