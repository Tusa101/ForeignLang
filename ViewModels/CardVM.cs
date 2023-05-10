using ForeignLang.Models;
using ForeignLang.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ForeignLang.ViewModels
{
    public struct Card
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public Card(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
    internal class CardVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private string _question;
        private string _answer;
        private string _theme;
        private int _index = 0;
        private Card[] _cards;

        public string Question
        {
            get { return _question; }
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }
        public string Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                OnPropertyChanged();
            }
        }

        public CardVM(string theme)
        {
            _theme = theme;
            DbData db = new DbData();
            var cards = db.Cards.Rows;
            var query = from card in db.ThemesSet.Tables["Cards"].AsEnumerable()
                        where card["Theme"] == theme
                        select new { Question = card["Question"], Answer = card["Answer"] };
            var array = query.ToArray();
            _cards = new Card[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                _cards[i] = new Card(array[i].Question.ToString(), array[i].Answer.ToString());
            }
            
            Answer = _cards[0].Answer.ToString();
            Question = _cards[0].Question.ToString();
        }
        public void SetNextCard()
        {
            _index++;
            if (_index < _cards.Length) 
            {
                Answer = _cards[_index].Answer.ToString();
                Question = _cards[_index].Question.ToString();
            }
            else
            {
                Question = "Theme Completed!";
                Answer = "Theme Completed!";
            }
        }
    }
}
