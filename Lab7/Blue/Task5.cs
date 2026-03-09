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
                if (!_isPlaceSet && place >= 1 && place <= 18)
                {
                    _place = place;
                    _isPlaceSet = true;
                }
            }
            
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - место: {Place}");
            }
        }
        
        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _sportsmanCount;

            public string Name => _name;
            
            public Sportsman[] Sportsmen
            {
                get
                {
                    Sportsman[] result = new Sportsman[6]; 
                    
                    if (_sportsmen != null)
                    {
                        for (int i = 0; i < _sportsmanCount && i < 6; i++)
                        {
                            result[i] = _sportsmen[i];
                        }
                    }
                    
                    return result;
                }
            }

            
            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    
                    for (int i = 0; i < _sportsmanCount; i++)
                    {
                        int place = _sportsmen[i].Place;
                        if (place == 1) sum += 5;
                        else if (place == 2) sum += 4;
                        else if (place == 3) sum += 3;
                        else if (place == 4) sum += 2;
                        else if (place == 5) sum += 1;
                    }
                    
                    return sum;
                }
            }
            
            

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _sportsmanCount = 0;
            }
            
            public void Add(Sportsman sportsman)
            {
                if (_sportsmanCount < 6)
                {
                    _sportsmen[_sportsmanCount] = sportsman;
                    _sportsmanCount++;
                }
            }
            
            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null) return;
                
                for (int i = 0; i < sportsmen.Length && _sportsmanCount < 6; i++)
                {
                    _sportsmen[_sportsmanCount] = sportsmen[i];
                    _sportsmanCount++;
                }
            }
            
            public int TopPlace
            {
                get
                {
                    if (_sportsmanCount == 0) return 0;
                    
                    int best = 19; 
                    
                    for (int i = 0; i < _sportsmanCount; i++)
                    {
                        int place = _sportsmen[i].Place;
                        if (place != 0 && place < best) 
                        {
                            best = place;
                        }
                    }
                    
                    return best == 19 ? 0 : best;
                }
            }
            
            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length <= 1) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        bool shouldSwap = false;
                        
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            shouldSwap = true;
                        }
                        
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                shouldSwap = true;
                            }
                        }
                        
                        if (shouldSwap)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name}");
                Console.WriteLine($"Общий счет: {TotalScore} баллов");
                Console.WriteLine($"Лучшее место: {TopPlace}");
                Console.WriteLine("Состав команды:");
                
                for (int i = 0; i < _sportsmanCount; i++)
                {
                    Console.Write("  ");
                    _sportsmen[i].Print();
                }
                
                Console.WriteLine();
            }
        }
    }
}
