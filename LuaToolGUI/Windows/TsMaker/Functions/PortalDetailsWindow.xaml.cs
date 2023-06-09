using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ToolGUI.Windows.TsMaker.Enums;

namespace ToolGUI.TsMaker.Functions
{
    /// <summary>
    /// Interaction logic for PortalDetailsWindow.xaml
    /// </summary>
    public partial class PortalDetailsWindow : Window
    {
        private TextBox luaCodeTextBox;
        private Dictionary<string, Tuple<string, string>> portalConnections;
        public PortalType[] PortalTypes => Enum.GetValues(typeof(PortalType)) as PortalType[];
        public MinimapOrientation[] MinimapOrientations => Enum.GetValues(typeof(MinimapOrientation)) as MinimapOrientation[];

        public PortalDetailsWindow(TextBox luaCodeTextBox, Dictionary<string, Tuple<string, string>> connections)
        {
            InitializeComponent();

            // Assign the values to the private fields
            portalConnections = connections;

            // Use the values as needed in the window
            this.luaCodeTextBox = luaCodeTextBox;

            // Access portalConnections and perform any necessary operations
        }

        public IEnumerable<string> FromMapComboBoxItemsSource
        {
            set { FromMapComboBox.ItemsSource = value; }
        }

        // Property to set the item source of ToMapComboBox
        public IEnumerable<string> ToMapComboBoxItemsSource
        {
            set { ToMapComboBox.ItemsSource = value; }
        }

        private void AddPortalButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder luaCode = new StringBuilder();

            // Get the portal properties from the input fields
            string portalType = PortalTypeComboBox.Text;
            string fromMap = FromMapComboBox.SelectedValue.ToString();
            string fromX = FromXTextBox.Text;
            string fromY = FromYTextBox.Text;
            string toMap = ToMapComboBox.SelectedValue.ToString();
            string toX = ToXTextBox.Text;
            string toY = ToYTextBox.Text;
            string minimapOrientation = MinimapOrientationComboBox.Text;

            // Extract the map coordinates from the fromMap and toMap values
            string[] fromMapParts = fromMap.Split('_');
            string[] toMapParts = toMap.Split('_');
            string fromMapCoordinates = $"{fromMapParts[1]}_{fromMapParts[2]}";
            string toMapCoordinates = $"{toMapParts[1]}_{toMapParts[2]}";

            // Create the portal name based on the map coordinates
            string portalName = $"portal_{fromMapCoordinates}_to_{toMapCoordinates}";

            // Create the Lua code for adding the portal
            string portal = $"local {portalName} = Portal.Create(PortalType.{portalType}).From({fromMap}, {fromX}, {fromY}).To({toMap}, {toX}, {toY}).MinimapOrientation(PortalMinimapOrientation.{minimapOrientation})";

            // Append the Lua code to the text box
            luaCode.AppendLine(portal);

            // Store the portal connection in the dictionary
            portalConnections[portalName] = new Tuple<string, string>(fromMap, toMap);

            luaCodeTextBox.Text += luaCode.ToString();

            // Clear the input fields
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
            luaCodeTextBox.Text += luaCode.ToString();
        }
    }
}