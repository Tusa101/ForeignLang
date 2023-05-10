using ForeignLang.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace ForeignLang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _normalState = true;
        private bool _switcher = true;
        public MainWindow()
        {
            InitializeComponent();
            SoundPlayer soundPlayer = new SoundPlayer("../../Sound/Unused-Shop-Loop.wav");
            soundPlayer.Load();
            soundPlayer.PlayLooping();
            Main.Content = new StartupPage();
            
        }
        private void ShutdownApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeWindow(object sender, MouseButtonEventArgs e)
        {
            if (_normalState)
            {
                this.WindowState = WindowState.Maximized;
                _normalState = false;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                _normalState = true;
            }
        }

        private void MinimizeWindow(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void OnOffSound_LeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_switcher)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"/Views/Asset 10@3x-8.png", UriKind.Relative);
                image.EndInit();
                Sound.Source = image;

                SoundPlayer soundPlayer = new SoundPlayer();
                soundPlayer.Stop();
                _switcher = !_switcher;
            }
            else
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"/Views/Asset 9@3x-8.png", UriKind.Relative);
                image.EndInit();
                Sound.Source = image;
                SoundPlayer soundPlayer = new SoundPlayer("../../Sound/Unused-Shop-Loop.wav");
                soundPlayer.Load();
                soundPlayer.PlayLooping();
                _switcher = !_switcher;
            }

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Height="450" Width="800"
            this.FontSize = FontSize * e.NewSize.Height / 450;
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(Main.NavigationService.CanGoBack) 
            {
                Main.NavigationService.GoBack();
            }
        }
    }
}
