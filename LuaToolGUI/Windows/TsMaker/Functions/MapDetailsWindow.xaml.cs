using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ToolGUI.TsMaker.Functions
{
    /// <summary>
    /// Interaction logic for MapDetailsWindow.xaml
    /// </summary>
    public partial class MapDetailsWindow : Window
    {
        private ObservableCollection<string> mapNames;
        private TextBox luaCodeTextBox;
        private ListBox objectivesList;
        private Dictionary<int, Dictionary<int, bool>> cellStates;

        public MapDetailsWindow(ObservableCollection<string> mapNames, TextBox luaCodeTextBox, ListBox objectivesList)
        {
            InitializeComponent();
            cellStates = new Dictionary<int, Dictionary<int, bool>>();
            CreateGridButtons();

            this.mapNames = mapNames;
            this.luaCodeTextBox = luaCodeTextBox;
            this.objectivesList = objectivesList;
        }

        private void CreateGridButtons()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button button = new Button
                    {
                        Content = cellStates.ContainsKey(i) && cellStates[i].ContainsKey(j) && cellStates[i][j] ? "XX" : "",
                        Margin = new Thickness(-2),
                        Padding = new Thickness(0),
                        BorderThickness = new Thickness(0),
                        Width = 32,
                        Height = 32,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    button.Click += MapCell_Click;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    DynamicGrid.Children.Add(button);
                }
            }
        }

        private void MapCell_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int xCoord = Grid.GetColumn(button);
            int yCoord = Grid.GetRow(button);

            if (!cellStates.ContainsKey(yCoord))
            {
                cellStates[yCoord] = new Dictionary<int, bool>();
            }

            if (cellStates[yCoord].ContainsKey(xCoord))
            {
                cellStates[yCoord].Remove(xCoord);
                button.Content = "";
            }
            else
            {
                cellStates[yCoord][xCoord] = true;
                button.Content = "XX";
            }

            XCoordTextBox.Text = xCoord.ToString();
            YCoordTextBox.Text = yCoord.ToString();
        }

        private void RefreshGrid()
        {
            foreach (Button button in DynamicGrid.Children)
            {
                int xCoord = Grid.GetColumn(button);
                int yCoord = Grid.GetRow(button);

                if (cellStates.ContainsKey(yCoord) && cellStates[yCoord].ContainsKey(xCoord))
                {
                    button.Content = "XX";
                }
                else
                {
                    button.Content = "";
                }
            }
        }

        private void AddMapButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder luaCode = new StringBuilder();
            var selectedObjectives = objectivesList.SelectedItems.Cast<ListBoxItem>().Select(item => item.Content.ToString());

            luaCode.AppendLine("");

            // Get the map coordinates and map ID from the input fields
            string mapId = MapIdTextBox.Text;
            string mapX = XCoordTextBox.Text;
            string mapY = YCoordTextBox.Text;
            string task = TaskTypeComboBox.Text;

            // Update the cell state for the added map
            int xCoord = int.Parse(mapX);
            int yCoord = int.Parse(mapY);
            if (!cellStates.ContainsKey(yCoord))
            {
                cellStates[yCoord] = new Dictionary<int, bool>();
            }
            cellStates[yCoord][xCoord] = true;

            // Refresh the grid to update the button states
            RefreshGrid();

            string mapName = $"map_{mapX}_{mapY}";

            // Create the Lua code for adding the map
            luaCode.AppendLine($"local {mapName} = Map.Create().WithMapId({mapId}).SetMapCoordinates({mapX}, {mapY}).WithTask(TimeSpaceTask.Create(TimeSpaceTaskType.{task}))");

            luaCodeTextBox.Text += luaCode.ToString();

            mapNames.Add(mapName); // Add the new map to the mapNames list
        }

        public void ClearCellStates()
        {
            cellStates.Clear();
        }
    }
}