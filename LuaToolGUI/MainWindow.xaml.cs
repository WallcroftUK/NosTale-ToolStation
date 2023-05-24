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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Fields to store the generated map names
        private ObservableCollection<string> mapNames = new ObservableCollection<string>();

        private Dictionary<string, Tuple<string, string>> portalConnections = new Dictionary<string, Tuple<string, string>>();
        public List<TimeSpaceObjectiveType> SelectedObjectives { get; set; }

        private MapDetailsWindow mapDetailsWindow;
        private PortalDetailsWindow portalDetailsWindow;
        private AddMonstersWindow addMonstersWindow;
        private TimeSpaceWindow timeSpaceWindow;
        private EventWindow eventWindow;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            SelectedObjectives = Enum.GetValues(typeof(TimeSpaceObjectiveType))
                                     .OfType<TimeSpaceObjectiveType>()
                                     .ToList();
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

            foreach (var objective in ObjectivesList.SelectedItems)
            {
                if (objective is TimeSpaceObjectiveType objectiveType)
                {
                    switch (objectiveType)
                    {
                        case TimeSpaceObjectiveType.KillAllMonsters:
                            luaCode.AppendLine(".WithKillAllMonsters()");
                            break;
                        case TimeSpaceObjectiveType.GoToExit:
                            luaCode.AppendLine(".WithGoToExit()");
                            break;
                        case TimeSpaceObjectiveType.KillMonsterVnum:
                            luaCode.AppendLine(".WithKillMob(vnum, amount)");
                            break;
                        case TimeSpaceObjectiveType.KillMonsterAmount:
                            luaCode.AppendLine(".WithKillMonsterAmount(amount)");
                            break;
                        case TimeSpaceObjectiveType.CollectItemVnum:
                            luaCode.AppendLine(".WithCollectItem(vnum, amount)");
                            break;
                        case TimeSpaceObjectiveType.CollectItemAmount:
                            luaCode.AppendLine(".WithCollectItemAmount(amount)");
                            break;
                        case TimeSpaceObjectiveType.Conversation:
                            luaCode.AppendLine(".WithConversations(amount)");
                            break;
                        case TimeSpaceObjectiveType.InteractObjectsVnum:
                            luaCode.AppendLine(".WithInteractObjects(vnum, amount)");
                            break;
                        case TimeSpaceObjectiveType.InteractObjectsAmount:
                            luaCode.AppendLine(".WithInteractObjectsAmount(amount)");
                            break;
                        case TimeSpaceObjectiveType.ProtectNPC:
                            luaCode.AppendLine(".WithProtectNPC()");
                            break;
                        default:
                            break;
                    }
                }
            }

            LuaCodeTextBox.Text = luaCode.ToString();
        }


        private void OpenMapDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            mapDetailsWindow = new MapDetailsWindow(mapNames, LuaCodeTextBox, ObjectivesList);
            mapDetailsWindow.Show();
        }

        private void OpenPortalDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of PortalDetailsWindow
            portalDetailsWindow = new PortalDetailsWindow(LuaCodeTextBox, portalConnections);

            // Set the item source for FromMapComboBox and ToMapComboBox
            portalDetailsWindow.FromMapComboBoxItemsSource = mapNames;
            portalDetailsWindow.ToMapComboBoxItemsSource = mapNames;

            // Show the PortalDetailsWindow
            portalDetailsWindow.Show();
        }

        private void AddMonstersButton_Click(object sender, RoutedEventArgs e)
        {
            addMonstersWindow = new AddMonstersWindow(mapNames);
            if (addMonstersWindow.ShowDialog() == true)
            {
                string script = LuaCodeTextBox.Text;
                script += addMonstersWindow.GeneratedScript;
                LuaCodeTextBox.Text = script;
            }
        }

        private void OpenEventWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the EventWindow and pass the LuaCodeTextBox reference
            var eventWindow = new EventWindow(portalConnections, LuaCodeTextBox, mapNames);

            // Show the EventWindow
            eventWindow.Show();
        }

        private void OpenTimeSpaceWindow_Click(object sender, RoutedEventArgs e)
        {
            timeSpaceWindow = new TimeSpaceWindow(LuaCodeTextBox, mapNames);
            timeSpaceWindow.Show();
        }
        private void EasterEggButton_Click(object sender, RoutedEventArgs e)
        {
            EasterEggWindow easterEggWindow = new EasterEggWindow();
            easterEggWindow.ShowDialog();
            MessageBox.Show("Cepik Was Here", "Easter Egg");
        }
        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the mapNames collection
            mapNames.Clear();

            // Clear the portalConnections dictionary
            portalConnections.Clear();

            // Clear the cellStates dictionary
            // Assuming you have an instance of the MapDetailsWindow called mapDetailsWindow
            mapDetailsWindow.ClearCellStates();

            //Clear the events dictionary
            eventWindow.CleanEvents();

            // Clear the main Lua code textbox
            LuaCodeTextBox.Clear();
        }
    }
}