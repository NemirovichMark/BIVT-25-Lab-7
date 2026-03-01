namespace Lab7.Blue
{
    public class Task5
    { 
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place = 0;
            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }
            
            public void SetPlace(int place)
            {
                if (_place == 0) _place = place;
            }

            public void Print()
            {
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            public string Name => _name;

            public Sportsman[] Sportsmen
            {
                get
                {
                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen,0, copy,0, _sportsmen.Length);
                    return copy;
                }
            }


            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    foreach (Sportsman sportsman in _sportsmen)
                    {
                        int place = sportsman.Place;
                        if (place == 1) sum += 5;
                        else if (place == 2) sum += 4;
                        else if (place == 3) sum += 3;
                        else if (place == 4) sum += 2;
                        else if (place == 5) sum += 1;
                    }
                    return sum;
                }
            }

            public int TopPlace
            {
                get
                {
                    int min = 10000;
                    foreach (Sportsman sportsman in _sportsmen)
                    {
                        if (sportsman.Place > 0) min = int.Min(min, sportsman.Place);
                    }
                    return min;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = [];
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen.Length < 6)
                {
                    Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                    _sportsmen[^1] = sportsman;
                }
            }
            public void Add(Sportsman[] sportsmen)
            {
                foreach (var sportsman in sportsmen) Add(sportsman);
            }
            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore) (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        
                        if (teams[j].TotalScore == teams[j + 1].TotalScore && teams[j + 1].IsWin()) (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                    }
                }
            }
            private bool IsWin()
            {
                return TopPlace == 1;
            }
            
            public void Print()
            {
            }
        }
    }
}
