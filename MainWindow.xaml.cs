using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using SharpDX.XInput;

namespace GamingOverlay
{
    public partial class MainWindow : Window
    {
        private Controller controller;
        private DispatcherTimer inputTimer;
        private int currentIndex = 0; // Current selected navigation index
        private uint lastPacketNumber = 0; // Tracks the last packet number
        private GamepadButtonFlags lastButtonState = GamepadButtonFlags.None; // Tracks the last button state
        private bool guideButtonPressed = false; // Tracks the Guide button press state

        public MainWindow()
        {
            InitializeComponent();

            // Set the window to fullscreen and topmost
            this.WindowState = WindowState.Maximized;
            this.Topmost = true;

            // Apply the background image based on mode
            Loaded += (s, e) => ApplyBackgroundBasedOnMode();

            // Initialize controller and input timer
            controller = new Controller(UserIndex.One);
            inputTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100) // Poll every 100ms
            };
            inputTimer.Tick += CheckControllerInput;
            inputTimer.Start();

            // Handle clean shutdown
            this.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            inputTimer?.Stop();
        }

        private void CheckControllerInput(object? sender, EventArgs e)
        {
            if (!controller.IsConnected) return;

            var state = controller.GetState();

            // Check for packet update
            if ((uint)state.PacketNumber != lastPacketNumber) // Detect packet number change
            {
                lastPacketNumber = (uint)state.PacketNumber; // Update the last packet number

                // Debug: Output packet number to console
                Console.WriteLine($"PacketNumber: {state.PacketNumber}");

                // Handle Left Bumper (LB) navigation
                if ((state.Gamepad.Buttons & GamepadButtonFlags.LeftShoulder) != 0)
                {
                    Console.WriteLine("Left Bumper detected.");
                    NavigateLeft();
                    return; // Exit to prevent further Guide button logic
                }

                // Handle Right Bumper (RB) navigation
                if ((state.Gamepad.Buttons & GamepadButtonFlags.RightShoulder) != 0)
                {
                    Console.WriteLine("Right Bumper detected.");
                    NavigateRight();
                    return; // Exit to prevent further Guide button logic
                }

                // Check for Guide button press based on packet update and no other button flags
                if (state.Gamepad.Buttons == GamepadButtonFlags.None && !guideButtonPressed)
                {
                    Console.WriteLine("Guide button detected.");
                    guideButtonPressed = true; // Mark Guide button as pressed
                    HandleGuideButtonPress();
                }
                else if (state.Gamepad.Buttons != GamepadButtonFlags.None)
                {
                    guideButtonPressed = false; // Reset Guide button state if other buttons are pressed
                }
            }

            // Update the last button state
            lastButtonState = state.Gamepad.Buttons;
        }

        private void HandleGuideButtonPress()
        {
            if (this.WindowState == WindowState.Minimized)
            {
                // Restore the window
                Console.WriteLine("Restoring window...");
                this.WindowState = WindowState.Normal;
                this.Topmost = true; // Keep the app on top
            }
            else
            {
                // Minimize the window
                Console.WriteLine("Minimizing window...");
                this.WindowState = WindowState.Minimized;
            }
        }

        private void GuideButton_Click(object sender, RoutedEventArgs e)
        {
            // Trigger the same functionality as the guide button
            Console.WriteLine("GuideButton_Click triggered.");
            HandleGuideButtonPress();
        }

        private void NavigateLeft()
        {
            if (NavigationButtonsPanel == null || NavigationButtonsPanel.Children.Count == 0) return;

            currentIndex = (currentIndex - 1 + NavigationButtonsPanel.Children.Count) % NavigationButtonsPanel.Children.Count;
            UpdateNavigation();
        }

        private void NavigateRight()
        {
            if (NavigationButtonsPanel == null || NavigationButtonsPanel.Children.Count == 0) return;

            currentIndex = (currentIndex + 1) % NavigationButtonsPanel.Children.Count;
            UpdateNavigation();
        }

        private void UpdateNavigation()
        {
            for (int i = 0; i < NavigationButtonsPanel.Children.Count; i++)
            {
                if (NavigationButtonsPanel.Children[i] is Button button)
                {
                    button.Background = i == currentIndex ? Brushes.LightGray : Brushes.Transparent;
                    button.Focus();

                    if (i == currentIndex)
                    {
                        NavigateToPage(button.Content.ToString());
                    }
                }
            }
        }

        private void NavigateToPage(string menuItem)
        {
            try
            {
                switch (menuItem)
                {
                    case "Game Options":
                        FrameContent.Navigate(new Pages.GameOptionsPage());
                        break;
                    case "Performance Profile":
                        FrameContent.Navigate(new Pages.PerformancePage());
                        break;
                    case "Game Recording":
                        FrameContent.Navigate(new Pages.RecordingsPage());
                        break;
                    case "Achievements":
                        FrameContent.Navigate(new Pages.AchievementsPage());
                        break;
                    case "Discord":
                        FrameContent.Navigate(new Pages.DiscordPage());
                        break;
                }
                FrameContent.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to page: {ex.Message}");
            }
        }

        private void ApplyBackgroundBasedOnMode()
        {
            bool isDarkMode = IsDarkModeEnabled();

            string imageSource = isDarkMode
                ? "Images/navigation_background_dark.png"
                : "Images/navigation_background_light.png";

            var backgroundBrush = new ImageBrush
            {
                ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(imageSource, UriKind.Relative)),
                Stretch = Stretch.UniformToFill,
                AlignmentX = AlignmentX.Center,
                AlignmentY = AlignmentY.Center
            };

            BackgroundImageRectangle.Fill = backgroundBrush;
        }

        private bool IsDarkModeEnabled()
        {
            const string registryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string valueName = "AppsUseLightTheme";

            try
            {
                object value = Microsoft.Win32.Registry.GetValue(registryKey, valueName, null);
                if (value is int mode)
                {
                    return mode == 0; // 0 = Dark Mode, 1 = Light Mode
                }
            }
            catch
            {
                return true; // Default to dark mode if registry lookup fails
            }

            return true;
        }
    }
}
