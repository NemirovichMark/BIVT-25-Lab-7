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
            private int _countPlace;
            
            // Свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;
            
            // Конструктор
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
                _countPlace = 0;
            }

            public void SetPlace(int place)
            {
                if (_countPlace > 0) return;
                
                _place = place;
                _countPlace++;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {_place}");
            }
        }

        public struct Team
        {
            // Поля
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;
            
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
                    int totalTeam = 0;
                    
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i].Place == 1) totalTeam += 5;
                        
                        if (_sportsmen[i].Place == 2) totalTeam += 4;
                        
                        if (_sportsmen[i].Place == 3) totalTeam += 3;
                        
                        if (_sportsmen[i].Place == 4) totalTeam += 2;
                        
                        if (_sportsmen[i].Place == 5) totalTeam += 1;
                        
                        if (_sportsmen[i].Place > 5) totalTeam += 0;
                        
                    }

                    return totalTeam;
                }
            }

            public int TopPlace
            {
                get
                {
                    int mn = int.MaxValue;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (mn > _sportsmen[i].Place)
                        {
                            mn = _sportsmen[i].Place;
                        }
                    }

                    return mn;
                }
            }
            
            // Конструктор
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _count = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_count >= 6) return;

                _sportsmen[_count++] = sportsman;
            }
            
            public void Add(Sportsman[] sportsman)
            {
                foreach (Sportsman s in sportsman)
                {
                    if (_count >= 6) return;
                    _sportsmen[_count++] = s;
                }
            }

            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 1; j < teams.Length; j++)
                    {
                        if (teams[j].TotalScore > teams[j - 1].TotalScore || (teams[j].TotalScore == teams[j - 1].TotalScore && teams[j].TopPlace < teams[j - 1].TopPlace))
                        {
                            (teams[j], teams[j - 1]) = (teams[j-1], teams[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name}: Total score = {TotalScore}, Top place = {TopPlace}");
            }
        }
    }

}
