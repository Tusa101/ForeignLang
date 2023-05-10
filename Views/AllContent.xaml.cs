using ForeignLang.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForeignLang.Views
{
    /// <summary>
    /// Interaction logic for AllContent.xaml
    /// </summary>
    public partial class AllContent : Page
    {
        public AllContent()
        {
            InitializeComponent();
            DataContext = new AllDataVM();
        }
    }
}
