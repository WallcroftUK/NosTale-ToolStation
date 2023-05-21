/// <summary>
/// Interaction logic for AddMonstersWindow.xaml
/// </summary>
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace LuaToolGUI
{
    public partial class AddMonstersWindow : Window
    {
        public string GeneratedScript { get; private set; }

        public AddMonstersWindow(ObservableCollection<string> mapNames)
        {
            InitializeComponent();
            mapComboBox.ItemsSource = mapNames;
        }

        public string GetScript()
        {
            return scriptTextBox.Text;
        }

        private void AddMonsterButton_Click(object sender, RoutedEventArgs e)
        {
            string mapName = mapComboBox.SelectedItem.ToString();
            string monsterName = mobVnumTextBox.Text;
            int x = int.Parse(positionXTextBox.Text);
            int y = int.Parse(positionYTextBox.Text);
            int facing = int.Parse(facingTextBox.Text);
            int level = int.Parse(mobLevelTextBox.Text);

            string specialType = ((ComboBoxItem)specialTypeComboBox.SelectedItem).Content.ToString();
            string newMonster;

            if (specialType == "Target")
            {
                newMonster = "Monster.CreateWithVnum(" + monsterName + ").At(" + x + ", " + y + ").Facing(" + facing + ").AsTarget(),";
            }
            else if (specialType == "KillCount")
            {
                int killCount = int.Parse(killCountTextBox.Text);
                newMonster = "Monster.CreateWithVnum(" + monsterName + ").At(" + x + ", " + y + ").Facing(" + facing + ").SpawnAfterMobsKilled(" + killCount + "),";
            }
            else
            {
                newMonster = "Monster.CreateWithVnum(" + monsterName + ").At(" + x + ", " + y + ").Facing(" + facing + ").WithCustomLevel(" + level + "),";
            }

            // Check if the map already has monsters in the script
            int mapIndex = scriptTextBox.Text.IndexOf(mapName);
            if (mapIndex != -1)
            {
                // Find the end of the existing AddMonsters function call
                int endBracketIndex = scriptTextBox.Text.IndexOf("})", mapIndex);
                if (endBracketIndex != -1)
                {
                    // Insert the new monster before the closing bracket
                    scriptTextBox.Text = scriptTextBox.Text.Insert(endBracketIndex, newMonster + "\n\t");
                }
            }
            else
            {
                // Add a new AddMonsters function call for this map
                string newAddMonsters = mapName + ".AddMonsters({\n\t" + newMonster + "\n})\n";
                scriptTextBox.AppendText(newAddMonsters);
            }
            GeneratedScript = scriptTextBox.Text;
        }

        private void SaveCloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}