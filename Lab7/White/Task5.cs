namespace Lab7.White
{
    public class Task5
    {
        public struct Match
        {
            //Поля
            private int _goll;
            private int _negoll;

            //Свойства
            public int Goals => _goll;
            public int Misses => _negoll;
            public int Difference
            {
                get
                {
                    return _goll-_negoll;
                }
            }
            public int Score
            {
                get
                {
                    if (_goll > _negoll) return 3;       //Победа
                    else if (_goll == _negoll) return 1; //Ничья
                    else return 0;                       //Поражение
                }
            }

            //Конструктор 
            public Match(int goals, int misses)
            {
                _goll = goals;
                _negoll = misses;
            }
            //Методы
            public void Print()
            {
                return;
            }
        }
        public struct Team 
        {
            //Поля
            private string _name;
            private Match[] _match;
            
            //Свойства
            public string Name => _name;
            public Match[] Matches => _match;

            public int TotalDifference
            {
                get
                {
                    int s = 0;
                    for (int i = 0; i < _match.Length; i++) s += _match[i].Difference;
                    return s;
                }
            }
            public int TotalScore
            {
                get
                {
                    int s = 0;
                    for (int i = 0; i < _match.Length; i++) s+= _match[i].Score;
                    return s;
                }
            }
            //Конструктор
            public Team(string name)
            {
                _name = name;
                _match = new Match[0];
            }
            //Методы
                
            //Новый матч в историю команды 
            public void PlayMatch(int goals, int misses)
            {
                Array.Resize(ref _match, _match.Length + 1);
                _match[_match.Length - 1] = new Match(goals, misses);
            }
            public static void SortTeams(Team[] teams)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                        //Если очки равны
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (teams[j].TotalDifference < teams[j + 1].TotalDifference)
                            {
                                (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
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
