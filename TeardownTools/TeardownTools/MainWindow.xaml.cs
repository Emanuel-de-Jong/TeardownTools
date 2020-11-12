using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeardownTools.ViewModels;

namespace TeardownTools
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<ModViewModel> ModViewModels;

        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ModViewModels = new ObservableCollection<ModViewModel>();

            ModViewModels.Add(
                new ModViewModel("Remove Splash",
                "Remove the splash at the start of the game.",
                "Remove the logo and warning message during the launch of the game.", true,
                @"D:\Coding\Repos\TeardownTools\TeardownTools\TeardownTools\images\placeholder.png"));
            ModViewModels.Add(
                new ModViewModel("Show Speedometer",
                "Display your velocity on the screen.",
                "Display your x, y and z velocity at the top left of the screen during gameplay.", false,
                @"D:\Coding\Repos\TeardownTools\TeardownTools\TeardownTools\images\placeholder.png",
                "Not allowed in runs because of SRC regulations."));

            for(int i=0; i<15; i++)
                ModViewModels.Add(new ModViewModel());

            ModItemsControl.ItemsSource = ModViewModels;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount == 2)
                {
                    AdjustWindowSize();
                }
                else
                {
                    Application.Current.MainWindow.DragMove();
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                MaximizeImage.Source = new BitmapImage(new Uri(@"/images/maximize.png", UriKind.Relative));
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                MaximizeImage.Source = new BitmapImage(new Uri(@"/images/resize.png", UriKind.Relative));
            }
        }
    }
}
