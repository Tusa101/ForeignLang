using ForeignLang.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ForeignLang.Views
{
    /// <summary>
    /// Interaction logic for ThemeLearning.xaml
    /// </summary>
    public partial class ThemeLearning : Page
    {
        public ThemeLearning(string theme)
        {
            InitializeComponent();
            DataContext = new CardVM(theme);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Card.RenderTransformOrigin = new Point(0.5, 0.5);
            CardAns.RenderTransformOrigin = new Point(0.5, 0.5);
            Storyboard sbFlip = new Storyboard();
            Storyboard.SetTargetProperty(sbFlip, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            Card.RenderTransform = new ScaleTransform(1, 1);
            var anim = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(700));
            Storyboard.SetTargetName(anim, Card.Name);
            sbFlip.Children.Add(anim);
            sbFlip.Begin(this);

            await Task.Delay(700);

            sbFlip = new Storyboard();
            Storyboard.SetTargetProperty(sbFlip, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            CardAns.RenderTransform = new ScaleTransform(0, 1);
            var anim2 = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(700));
            Storyboard.SetTargetName(anim2, CardAns.Name);
            sbFlip.Children.Add(anim2);
            sbFlip.Begin(this);

            

        }

        private async void CardAns_Click(object sender, RoutedEventArgs e)
        {
            
            Card.RenderTransformOrigin = new Point(0.5, 0.5);
            CardAns.RenderTransformOrigin = new Point(0.5, 0.5);
            Storyboard sbFlip = new Storyboard();
            Storyboard.SetTargetProperty(sbFlip, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            CardAns.RenderTransform = new ScaleTransform(1, 1);
            var anim = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(700));
            Storyboard.SetTargetName(anim, CardAns.Name);
            sbFlip.Children.Add(anim);
            sbFlip.Begin(this);

            await Task.Delay(700);

            sbFlip = new Storyboard();
            Storyboard.SetTargetProperty(sbFlip, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            Card.RenderTransform = new ScaleTransform(0, 1);
            var anim2 = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(700));
            Storyboard.SetTargetName(anim2, Card.Name);
            sbFlip.Children.Add(anim2);
            sbFlip.Begin(this);

            await Task.Delay(50);
            (DataContext as CardVM).SetNextCard();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Card.RenderTransform.Value.M11 == 1)
            {
                //TextToSpeech
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;
                synthesizer.Rate = -2;
                synthesizer.SpeakAsync(Card.Content.ToString());
            }
            else 
            {
                //TextToSpeech
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;
                synthesizer.Rate = -2;
                synthesizer.SpeakAsync(CardAns.Content.ToString());
            }
            
        }
    }
}
