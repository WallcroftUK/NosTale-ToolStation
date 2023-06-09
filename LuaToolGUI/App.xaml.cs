//Wallcroft


using ToolGUI.Windows;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ToolGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private LoadScreen splashScreen;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Show the loading screen
            splashScreen = new LoadScreen();
            splashScreen.Show();

            // Start the loading process on a separate thread
            Thread loadingThread = new Thread(LoadingProcess);
            loadingThread.Start();
        }

        private void LoadingProcess()
        {
            const int totalProgressSteps = 100; // Total number of progress steps
            int currentProgress = 0; // Current progress value

            while (currentProgress < totalProgressSteps)
            {
                // Simulate some work being done
                Thread.Sleep(50);

                // Increment the progress
                currentProgress++;

                // Update the loading progress on the UI thread
                Dispatcher.Invoke(() =>
                {
                    // Calculate the progress value between 0 and 1
                    double loadingProgress = (double)currentProgress / totalProgressSteps;

                    // Update the width of the progress bar to reach the maximum width
                    splashScreen.progressBar.Width = loadingProgress * splashScreen.progressBarContainer.ActualWidth;
                });
            }

            // Close the loading screen and show the main window on the UI thread
            Dispatcher.Invoke(() =>
            {
                // Create and show the main window
                InitialMenuWindow initialMenuWindow = new InitialMenuWindow();
                initialMenuWindow.Show();

                // Close SplashScreen
                splashScreen.Close();

            });
        }



    }
}
