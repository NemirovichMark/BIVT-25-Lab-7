namespace Lab7.Blue
{
    public class Task5
    {

        public struct Sportsman
        {
            private string _name;

            private string _surname;

            private int _place;

            private bool _isPlaceSet;
            
            
            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;
            
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
                _isPlaceSet = false;
            }

            public void SetPlace(int place)
            {
                if (_isPlaceSet)
                    return;
                
                _place = place;
                _isPlaceSet = true;
            }

            public void Print() { }

        }

        public struct Team
        {
            private string _name;
            
            private Sportsman[] _sportsmen;

            private int _count;
            
            
            public string Name => _name;
            

            public Sportsman[] Sportsmen
            {
                get
                {
                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, copy, _sportsmen.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int score = 0;
                    foreach (Sportsman sportsmen in Sportsmen)
                        score += Math.Max(0, 6 - sportsmen.Place);
                    
                    return score;
                }
            }

            public int TopPlace
            {
                get
                {
                    int min = int.MaxValue;
                    foreach (Sportsman sportsmen in Sportsmen)
                        min = Math.Min(min, sportsmen.Place);
                    
                    return min;
                }
            }


            public Team(string name)
            {
                _name = name;
                _sportsmen = [];
                _count = 0;
            }

            public void Add(Sportsman sportsmen)
            {
                if (_count>= 6)
                    return;
                
                Sportsman[] copy = new Sportsman[_sportsmen.Length + 1];
                Array.Copy(_sportsmen, copy, _sportsmen.Length);
                copy[_sportsmen.Length] = sportsmen;
                _sportsmen = copy;
                _count++;
            }
            
            public void Add(Sportsman[] sportsmen)
            {
                foreach (var team in sportsmen)
                {
                    if (_count < 6)
                    {
                        Sportsman[] copy = new Sportsman[_sportsmen.Length + 1];
                        Array.Copy(_sportsmen, copy, _sportsmen.Length);
                        copy[_sportsmen.Length] = team;
                        _sportsmen = copy;
                        _count++;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            public static void Sort(Team[] teams)
            {
                Array.Sort(teams, (a, b) =>
                {
                    int scoreCompare = b.TotalScore.CompareTo(a.TotalScore);
                    if (scoreCompare != 0)
                        return scoreCompare;
                    
                    return a.TopPlace.CompareTo(b.TopPlace);
                });
            }
            public void Print() { }

        }
        
    }
    
}