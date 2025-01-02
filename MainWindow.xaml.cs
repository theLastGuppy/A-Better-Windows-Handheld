using System.Windows;
using System.Windows.Media;

namespace GamingOverlay
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the window to fullscreen and topmost
            this.WindowState = WindowState.Maximized;
            this.Topmost = true;

            // Set the background dynamically based on light/dark mode
            Loaded += (s, e) => ApplyBackgroundBasedOnMode();
        }

        private void ApplyBackgroundBasedOnMode()
        {
            // Determine light or dark mode
            bool isDarkMode = IsDarkModeEnabled();

            // Select the appropriate image
            string imageSource = isDarkMode
                ? "Images/navigation_background_dark.png"
                : "Images/navigation_background_light.png";

            // Apply the image as the background
            ImageBrush backgroundBrush = new ImageBrush
            {
                ImageSource = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(imageSource, System.UriKind.Relative)),
                Stretch = Stretch.UniformToFill,
                AlignmentX = AlignmentX.Center,
                AlignmentY = AlignmentY.Center, // Start with AlignmentY.Top
            };

            BackgroundImageRectangle.Fill = backgroundBrush;
        }

        private bool IsDarkModeEnabled()
        {
            const string registryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string valueName = "AppsUseLightTheme";

            try
            {
                object? value = Microsoft.Win32.Registry.GetValue(registryKey, valueName, null);
                if (value is int mode)
                {
                    return mode == 0; // 0 = Dark Mode, 1 = Light Mode
                }
            }
            catch
            {
                // Default to dark mode if registry lookup fails
                return true;
            }

            return true; // Default to dark mode
        }

        // Close button click event handler
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Handle Windows key press to close the application
        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Check if the Windows key is pressed
            if (e.Key == System.Windows.Input.Key.LWin || e.Key == System.Windows.Input.Key.RWin)
            {
                this.Close();
            }
        }
    }
}
