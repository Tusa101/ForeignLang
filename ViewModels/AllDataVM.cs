using ForeignLang.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLang.ViewModels
{
    public struct FullCard
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Theme { get; set; }

        public FullCard(string question, string answer, string theme)
        {
            Question = question;
            Answer = answer;
            Theme = theme;
        }
    }
    internal class AllDataVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private ObservableCollection<FullCard> _data;

        public ObservableCollection<FullCard> Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }

        public AllDataVM()
        {
            DbData db = new DbData();
            var cards = db.Cards.Rows;
            var query = from card in db.ThemesSet.Tables["Cards"].AsEnumerable()
                        select new { Question = card["Question"], Answer = card["Answer"], Theme = card["Theme"] };
            var array = query.ToArray();
            Data = new ObservableCollection<FullCard>();
            for (int i = 0; i < array.Length; i++)
            {
                Data.Add(new FullCard(array[i].Question.ToString(), array[i].Answer.ToString(), array[i].Theme.ToString()));
            }
        }
    }
}
