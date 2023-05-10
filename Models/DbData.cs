using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLang.Models
{
    internal class DbData
    {
        public DataSet ThemesSet { get; set; }
        public DataTable Cards { get; set; }
        public DataTable Themes { get; set; }
        public DataTable CompletedThemes { get; set; }

        public DbData()
        {
            ThemesSet = new DataSet("CardsSet");
            Cards = new DataTable("Cards");
            Themes = new DataTable("Themes");
            
            ThemesSet.Tables.Add(Themes);
            ThemesSet.Tables.Add(Cards);

            
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; 
            idColumn.AllowDBNull = false; 
            idColumn.AutoIncrement = true; 
            idColumn.AutoIncrementSeed = 1;
            idColumn.AutoIncrementStep = 1;

            DataColumn questionCol = new DataColumn("Question", Type.GetType("System.String"));
            DataColumn answerCol = new DataColumn("Answer", Type.GetType("System.String"));
            DataColumn themeCol = new DataColumn("Theme", Type.GetType("System.String"));
            answerCol.DefaultValue = ""; 
            questionCol.DefaultValue = ""; 
            themeCol.DefaultValue = ""; 

            Cards.Columns.Add(idColumn);
            Cards.Columns.Add(questionCol);
            Cards.Columns.Add(answerCol);
            Cards.Columns.Add(themeCol);
           
            Cards.PrimaryKey = new DataColumn[] { Themes.Columns["Id"] };

            DataColumn idCol = new DataColumn("Id", Type.GetType("System.Int32"));
            idCol.Unique = true; 
            idCol.AllowDBNull = false; 
            idCol.AutoIncrement = true; 
            idCol.AutoIncrementSeed = 1;
            idCol.AutoIncrementStep = 1;

            DataColumn themeColThemes = new DataColumn("Theme", Type.GetType("System.String"));
            themeColThemes.DefaultValue = "";
            Themes.Columns.Add(idCol);
            Themes.Columns.Add(themeColThemes);


            Themes.Rows.Add(new object[] { null, "Everyday life" });
            Themes.Rows.Add(new object[] { null, "Shopping" });
            Themes.Rows.Add(new object[] { null, "Travel" });
            Themes.Rows.Add(new object[] { null, "Health" });
            Themes.Rows.Add(new object[] { null, "Sports" });
            Themes.Rows.Add(new object[] { null, "Government" });
            Themes.Rows.Add(new object[] { null, "Small Talks" });
            Themes.Rows.Add(new object[] { null, "Food" });
            Themes.Rows.Add(new object[] { null, "Hobbies" });

            Cards.Rows.Add(new object[] { null, "Dog", "Собака", "Everyday life" });
            Cards.Rows.Add(new object[] { null, "Refrigirator, fridge", "Холодильник", "Everyday life" });
            Cards.Rows.Add(new object[] { null, "Keyboard", "Клавиатура", "Everyday life" });
            Cards.Rows.Add(new object[] { null, "Washing machine", "Стиральная машинка", "Everyday life" });
            Cards.Rows.Add(new object[] { null, "Sink", "Раковина", "Everyday life" });
            Cards.Rows.Add(new object[] { null, "Shower", "Душ", "Everyday life" });
            Cards.Rows.Add(new object[] { null, "Laptop", "Ноутбук", "Everyday life" });
            Cards.Rows.Add(new object[] { null, "Notebook", "Тетрадь, записная книжка", "Everyday life" });

            Cards.Rows.Add(new object[] { null, "Bag", "Сумка", "Shopping" });
            Cards.Rows.Add(new object[] { null, "Souvenirs", "Сувениры", "Shopping" });
            Cards.Rows.Add(new object[] { null, "Shoes, boots", "Ботинки", "Shopping" });
            Cards.Rows.Add(new object[] { null, "T-shirt", "Футболка", "Shopping" });
            Cards.Rows.Add(new object[] { null, "Market", "Рынок", "Shopping" });
            Cards.Rows.Add(new object[] { null, "Flea market", "Блошиный рынок", "Shopping" });
            Cards.Rows.Add(new object[] { null, "Store", "Магазин", "Shopping" });
            Cards.Rows.Add(new object[] { null, "Mall", "Торговый центр", "Shopping" });

            Cards.Rows.Add(new object[] { null, "Plane, aircraft", "Самолет", "Travel" });
            Cards.Rows.Add(new object[] { null, "Coach", "Экскурсионный автобус", "Travel" });
            Cards.Rows.Add(new object[] { null, "Sightseeing", "Посещение достопримечателностей", "Travel" });
            Cards.Rows.Add(new object[] { null, "Souvenirs", "Сувениры", "Travel" });
            Cards.Rows.Add(new object[] { null, "Sunbathe", "Загорать", "Travel" });
            Cards.Rows.Add(new object[] { null, "Sunglasses", "Солнечные очки", "Travel" });
            Cards.Rows.Add(new object[] { null, "Sight", "Достопримечательность", "Travel" });
            Cards.Rows.Add(new object[] { null, "Trip", "Путешествие", "Travel" });
            Cards.Rows.Add(new object[] { null, "Sea", "Море", "Travel" });
            Cards.Rows.Add(new object[] { null, "Vacation", "Отпуск", "Travel" });
            Cards.Rows.Add(new object[] { null, "Hiking", "Поход", "Travel" });

            Cards.Rows.Add(new object[] { null, "Head ache", "Головная боль", "Health" });
            Cards.Rows.Add(new object[] { null, "Stomach ache", "Боль в животе", "Health" });
            Cards.Rows.Add(new object[] { null, "Pills", "Таблетки", "Health" });
            Cards.Rows.Add(new object[] { null, "Illness", "Болезнь", "Health" });
            Cards.Rows.Add(new object[] { null, "To feel sick/to be ill", "Быть больным", "Health" });

            Cards.Rows.Add(new object[] { null, "Soccer, football", "Футбол", "Sports" });
            Cards.Rows.Add(new object[] { null, "Wrestling", "Борьба", "Sports" });
            Cards.Rows.Add(new object[] { null, "Mixed martial arts", "Смешанные единоборства", "Sports" });
            Cards.Rows.Add(new object[] { null, "Ping-pong", "Настолный теннис", "Sports" });

            Cards.Rows.Add(new object[] { null, "Passport", "Паспорт", "Government" });
            Cards.Rows.Add(new object[] { null, "Documents", "Документы", "Government" });
            Cards.Rows.Add(new object[] { null, "Bills", "Счета", "Government" });
            Cards.Rows.Add(new object[] { null, "Taxes", "Налоги", "Government" });
            Cards.Rows.Add(new object[] { null, "Laws", "Законы", "Government" });

            Cards.Rows.Add(new object[] { null, "What's the weather today?", "Какая сегодня погода?", "Small Talks" });
            Cards.Rows.Add(new object[] { null, "How is it going?", "Как дела?", "Small Talks" });
            Cards.Rows.Add(new object[] { null, "How long have you been living in (Some city/country)?", "Как долго Вы проживаете в данном месте?", "Small Talks" });
            Cards.Rows.Add(new object[] { null, "What do you think of this exhibition?", "Как Вам данное представление?", "Small Talks" });
            Cards.Rows.Add(new object[] { null, "How can I get to the library?", "Как мне пройти в библиотеку?", "Small Talks" });

            Cards.Rows.Add(new object[] { null, "Porch", "Свинина", "Food" });
            Cards.Rows.Add(new object[] { null, "Chicken", "Курица", "Food" });
            Cards.Rows.Add(new object[] { null, "Ham", "Ветчина", "Food" });
            Cards.Rows.Add(new object[] { null, "Beef", "Говядина", "Food" });
            Cards.Rows.Add(new object[] { null, "Beetroot", "Свёкла", "Food" });
            Cards.Rows.Add(new object[] { null, "Cucumber", "Огурец", "Food" });
            Cards.Rows.Add(new object[] { null, "Bread", "Хлеб", "Food" });

            Cards.Rows.Add(new object[] { null, "Sewing", "Вязание", "Hobbies" });
            Cards.Rows.Add(new object[] { null, "Ping-pong", "Настольный теннис", "Hobbies" });
            Cards.Rows.Add(new object[] { null, "Swimming", "Плавание", "Hobbies" });




            CompletedThemes = new DataTable("CompletedThemes");
            
            DataColumn themeColumn = new DataColumn("Theme", Type.GetType("System.String"));

            idCol.Unique = true;
            

            DataColumn completionCol = new DataColumn("Completion", Type.GetType("System.Int64"));

        }
    }
}
