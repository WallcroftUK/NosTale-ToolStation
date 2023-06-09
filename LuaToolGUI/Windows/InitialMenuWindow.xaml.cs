using ToolGUI.Windows.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToolGUI.Windows.TsMaker;
using ToolStationGUI.Windows.ScriptConverter.Functions;

namespace ToolGUI.Windows
{
    /// <summary>
    /// Interaction logic for InitialMenuWindow.xaml
    /// </summary>
    public partial class InitialMenuWindow : Window
    {
        public InitialMenuWindow()
        {
            InitializeComponent();
        }

        private void LuaToolButton_Click(object sender, RoutedEventArgs e)
        {
            // Create and show the LuaTool window
            LuaToolWindow luaToolWindow = new LuaToolWindow();
            luaToolWindow.Show();

            // Close the initial menu window
            Close();
        }

        private void ConverterButton_Click(object sender, RoutedEventArgs e)
        {
            // Create and show the XmlToLua window
            XmlToLuaWindow xmlToLuaWindow = new XmlToLuaWindow();
            xmlToLuaWindow.Show();

            // Close the initial menu window
            Close();
        }

        private void ConfigsButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the action for Other Option 2 button
            // ...
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e)
        {
            // Show credits window or perform other action
            CreditsWindow creditsWindow = new CreditsWindow();
            creditsWindow.ShowDialog();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window and exit the application
            Close();
        }
    }
}
