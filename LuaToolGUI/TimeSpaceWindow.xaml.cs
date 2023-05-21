using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace LuaToolGUI
{
    /// <summary>
    /// Interaction logic for TimeSpaceWindow.xaml
    /// </summary>
    public partial class TimeSpaceWindow : Window
    {
        private TextBox luaCodeTextBox;
        private ObservableCollection<string> mapNames;

        public TimeSpaceWindow(TextBox luaCodeTextBox, ObservableCollection<string> mapNames)
        {
            InitializeComponent();
            this.mapNames = mapNames;

            // Use the values as needed in the window
            this.luaCodeTextBox = luaCodeTextBox;

            spawnMapComboBox.ItemsSource = mapNames;
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

            luaCodeTextBox.Text += luaCode.ToString();
        }
    }
}