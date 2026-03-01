using static Lab7.Blue.Task5;

namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            // поля
            private string _name;
            private string _surname;
            private int _place;
            private bool _setPlace = false;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            // конструктор
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }
            public void SetPlace(int place)
            {
                if (place < 0)
                {
                    return;
                }
                if (_setPlace)   // если место уже установили вернуть без изменений
                {
                    return;
                }
                _place = place;
                _setPlace = true;
            }

            public void Print()
            {
                return;
            }
        }
        public struct Team
        {
            // поля
            private string _name;
            private Sportsman[] _sportsmen;
            private int count;

            //свойства
            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        copy[i] = _sportsmen[i];
                    }
                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    int _scores = 0;
                    if (_sportsmen.Length == 0)
                    {
                        return 0;
                    }
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i].Place == 1)
                        {
                            _scores += 5;
                        }
                        else if (_sportsmen[i].Place == 2)
                        {
                            _scores += 4;
                        }
                        else if (_sportsmen[i].Place == 3)
                        {
                            _scores += 3;
                        }
                        else if (_sportsmen[i].Place == 4)
                        {
                            _scores += 2;
                        }
                        else if (_sportsmen[i].Place == 5)
                        {
                            _scores += 1;
                        }
                    }
                    return _scores;
                }
            }
            public int TopPlace
            {
                get
                {
                    int _top = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        for (int j = 1; j <  _sportsmen.Length - i; j++)
                        {
                            if (_sportsmen[j-1].Place > _sportsmen[j].Place) // по возрастанию занятого места
                            {
                                (_sportsmen[j - 1], _sportsmen[j]) = (_sportsmen[j], _sportsmen[j - 1]);
                            }
                        }
                    }
                    _top = _sportsmen[0].Place;
                    return _top;
                }
            }

            //конструктор
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                count = 0;
            }
            public void Add(Sportsman name)
            {

                if (count >= 6)
                {
                    return;
                }
                _sportsmen[count] = name;
                count++;
            }
            public void Add(Sportsman[] names)
            {
                if (count >= 6)
                {
                    return;
                }
                for (int i = 0; i < names.Length; i++)
                {
                    Add(names[i]);
                }
            }
            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length <= 1)
                    return;
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 1; j < teams.Length - i; j++)
                    {
                        if (teams[j - 1].TotalScore < teams[j].TotalScore) // по убыванию очков команды
                        {
                            (teams[j - 1], teams[j]) = (teams[j],  teams[j - 1]);
                        }
                        else if (teams[j - 1].TotalScore == teams[j].TotalScore)
                        {
                            if (teams[j-1].TopPlace > teams[j].TopPlace) // по возрастанию лучшего места
                            {
                                (teams[j - 1], teams[j]) = (teams[j], teams[j - 1]);
                            }
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
