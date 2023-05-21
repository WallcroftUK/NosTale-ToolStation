using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
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

        private void OpenMapDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            MapDetailsWindow mapDetailsWindow = new MapDetailsWindow(mapNames, LuaCodeTextBox, ObjectivesList);
            mapDetailsWindow.Show();
        }

        private void OpenPortalDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of PortalDetailsWindow
            PortalDetailsWindow portalDetailsWindow = new PortalDetailsWindow(LuaCodeTextBox, portalConnections);

            // Set the item source for FromMapComboBox and ToMapComboBox
            portalDetailsWindow.FromMapComboBoxItemsSource = mapNames;
            portalDetailsWindow.ToMapComboBoxItemsSource = mapNames;

            // Show the PortalDetailsWindow
            portalDetailsWindow.Show();
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

        private void OpenEventWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the EventWindow and pass the LuaCodeTextBox reference
            var eventWindow = new EventWindow(portalConnections, LuaCodeTextBox, mapNames);

            // Show the EventWindow
            eventWindow.Show();
        }

        private void OpenTimeSpaceWindow_Click(object sender, RoutedEventArgs e)
        {
            TimeSpaceWindow timeSpaceWindow = new TimeSpaceWindow(LuaCodeTextBox, mapNames);
            timeSpaceWindow.Show();
        }
    }
}