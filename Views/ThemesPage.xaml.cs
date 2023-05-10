using ForeignLang.ViewModels;
using ForeignLang.Views;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace ForeignLang
{
    /// <summary>
    /// Interaction logic for ThemesPage.xaml
    /// </summary>
    public partial class ThemesPage : Page
    {
        
        public ThemesPage()
        {
            InitializeComponent();
            DataContext = new ThemeVMS();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (sender as Button).Content.ToString();
            NavigationService.Navigate(new ThemeLearning(buttonContent));
        }
    }
}
