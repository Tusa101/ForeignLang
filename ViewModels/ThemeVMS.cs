using ForeignLang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLang.ViewModels
{
    internal class ThemeVMS : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private string _themeFirst;
        private string _themeSecond;
        private string _themeThird;
        private string _themeFourth;
        private string _themeFifth;
        private string _themeSixth;
        private string _themeSeven;
        private string _themeEighth;
        private string _themeNineth;


        public string ThemeFirst
        {
            get { return _themeFirst; }
            set
            {
                _themeFirst = value;
                OnPropertyChanged();
            }
        }
        public string ThemeSecond
        {
            get { return _themeSecond; }
            set
            {
                _themeSecond = value;
                OnPropertyChanged();
            }
        }
        public string ThemeThird
        {
            get => _themeThird;
            set 
            {
                _themeThird = value;
                OnPropertyChanged();
            }
        }
        public string ThemeFourth
        {
            get => _themeFourth;
            set 
            { 
                _themeFourth = value;
                OnPropertyChanged();
            }
        }
        public string ThemeFifth 
        {
            get => _themeFifth; 
            set
            {
                _themeFifth = value;
                OnPropertyChanged();
            }
        }
        public string ThemeSixth
        {
            get => _themeSixth; 
            set
            {
                _themeSixth = value;
                OnPropertyChanged();
            }
        }
        public string ThemeSeven
        {
            get => _themeSeven; 
            set
            {
                _themeSeven = value;
                OnPropertyChanged();
            }
        }
        public string ThemeEighth
        {
            get => _themeEighth; 
            set
            {
                _themeEighth = value;
                OnPropertyChanged();
            }
        }
        public string ThemeNineth
        {
            get => _themeNineth; 
            set
            {
                _themeNineth = value;
                OnPropertyChanged();
            }
        }

        
        public ThemeVMS()
        {
            DbData db = new DbData();
            var cards = db.Cards.Rows;
            var query = from card in db.ThemesSet.Tables["Themes"].AsEnumerable()
                        select new { Theme = card["Theme"]};
            var array = query.ToArray();

            ThemeFirst = array[0].Theme.ToString();
            ThemeSecond = array[1].Theme.ToString();
            ThemeThird = array[2].Theme.ToString();
            ThemeFourth = array[3].Theme.ToString();
            ThemeFifth = array[4].Theme.ToString();
            ThemeSixth = array[5].Theme.ToString();
            ThemeSeven = array[6].Theme.ToString();
            ThemeEighth = array[7].Theme.ToString();
            ThemeNineth = array[8].Theme.ToString();
        }
    }
}
