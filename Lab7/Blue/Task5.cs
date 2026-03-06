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
            private bool _flag;
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
                _flag = false;
            }
            public void SetPlace(int place)
            {
                if (_flag == true) return;
                if (place >=1 &&  place <= 18)
                {
                    _place = place;
                    _flag = true;
                }
            }
            public void Print()
            {
                Console.WriteLine("Name: " + _name + ", Surname: " + _surname + ", Place: " + _place);
            }
        }
        public struct Team
        {
            // Поля
            private string _name;
            private Sportsman[] _sportsmen;
            private int _k;
            // Свойства
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
                    int sum = 0;
                    for (int i = 0; i< _sportsmen.Length;i++)
                    {
                        int place = _sportsmen[i].Place; // из другой структуры мы можем обращаться только к публичным свойствам
                        if (place == 1)
                            sum += 5;
                        else if (place == 2)
                            sum += 4;
                        else if (place == 3)
                            sum += 3;
                        else if (place == 4)
                            sum += 2;
                        else if (place == 5)
                            sum += 1;
                    }
                    return sum;
                }
            }
            public int TopPlace
            {
                get
                {
                    int top = 19;
                    for (int i = 0; i< _sportsmen.Length;i++)
                    {
                        int place = _sportsmen[i].Place;
                        if (place < top)
                            top = place;
                    }
                    return top;
                }
            }
            // Конструктор
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _k = 0;
            }
            public void Add(Sportsman sportsmen)
            {
                if (_k >= 6) return;
                _sportsmen[_k] = sportsmen;
                _k++;
            }
            public void Add(Sportsman[] sportsmens)
            {
                for (int i = 0;i < sportsmens.Length; i++)
                {
                    if (_k < 6)
                        Add(sportsmens[i]);
                    else
                        break;
                }
            }
            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 1; j < teams.Length; j++)
                    {
                        if (teams[j].TotalScore > teams[j - 1].TotalScore) // сорт по убыванию
                        {
                            (teams[j], teams[j + 1]) = (teams[j - 1], teams[j]);
                        }
                        else if (teams[j].TotalScore == teams[j - 1].TotalScore) // сорт по топу
                        {
                            if (teams[j].TopPlace < teams[j - 1].TopPlace)
                            {
                                (teams[j], teams[j - 1]) = (teams[j - 1], teams[j]);
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
