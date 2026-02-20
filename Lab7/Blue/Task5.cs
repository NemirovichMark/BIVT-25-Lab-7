using System;

namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            // Поля
            private string _name; 
            private string _surname;
            private int _place;    
            private bool _isPlaceSet; 


            public Sportsman(string name, string surname)
            {
                if (name != null)
                    _name = name;
                else
                    _name = "";
                if (surname != null)
                    _surname = surname;
                else
                    _surname = "";
                _place = 0;  
                _isPlaceSet = false; 
            }

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;
            public void SetPlace(int place)
            {
                if (!_isPlaceSet) 
                {
                    _place = place;
                    _isPlaceSet = true;   // Запоминаем, что место уже установлено
                }
            }

           
            public void Print()
            {
                return;
            }
        }

   
        public struct Team
        {
            // Поля
            private string _name;
            private Sportsman[] _sportsmen; 
            private const int MAX_SPORTSMEN = 6; 

            public Team(string name)
            {
                if (name != null)
                    _name = name;
                else
                    _name = "";
                _sportsmen = new Sportsman[0];       // Пока спортсменов нет
            }

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null)
                        return new Sportsman[0];

                    // Создаем копию массива
                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    for (int i = 0; i < _sportsmen.Length; i++)
                        copy[i] = _sportsmen[i];
                    return copy;
                }
            }

            // 1 место = 5 баллов, 2 = 4, 3 = 3, 4 = 2, 5 = 1, остальные = 0
            public int TotalScore
            {
                get
                {
                    if (_sportsmen == null)
                        return 0;

                    int total = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        int place = _sportsmen[i].Place; //берем i-ного оттуда плейс
                        if (place == 1)
                            total += 5;
                        else if (place == 2)
                            total += 4;
                        else if (place == 3)
                            total += 3;
                        else if (place == 4)
                            total += 2;
                        else if (place == 5)
                            total += 1;
                        // остальные места = 0 баллов, что уе в начале написнао
                    }
                    return total;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0)
                        return 0;

                    int topPlace = 19; //ну типо меньшее место круче так что да а всего 18
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        int place = _sportsmen[i].Place;
                        if (place > 0 && place < topPlace) 
                        {
                            topPlace = place;
                        }
                    }
                    if (topPlace == 19)
                        return 0;
                    else
                        return topPlace;
                }
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen.Length >= MAX_SPORTSMEN)
                    return;

                // + новый массив на 1 больше, копипастим+1, меняем
                Sportsman[] newSportsmen = new Sportsman[_sportsmen.Length + 1];
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    newSportsmen[i] = _sportsmen[i];
                }
                newSportsmen[_sportsmen.Length] = sportsman;

                _sportsmen = newSportsmen;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null)
                    return;
                int sportsmenToAdd = MAX_SPORTSMEN - _sportsmen.Length; // Сколько свободных мест 

                if (sportsmenToAdd <= 0)
                    return;
                Sportsman[] newSportsmen = new Sportsman[_sportsmen.Length + sportsmenToAdd];

                // Копируем старых
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    newSportsmen[i] = _sportsmen[i];
                }
                // Добавляем новых
                for (int i = 0; i < sportsmenToAdd; i++)
                {
                    newSportsmen[_sportsmen.Length + i] = sportsmen[i];
                }
                _sportsmen = newSportsmen; //заменеяем
            }
            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length <= 1)
                    return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        bool needSwap = false;

                        // Сравниваем по TotalScore (чем больше, тем лучше)
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            needSwap = true;
                        }
                        // Если TotalScore равны - сравниваем по TopPlace (чем меньше, тем лучше)
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                needSwap = true;
                            }
                        }

                        if (needSwap)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                return;
            }
        }
    }
}