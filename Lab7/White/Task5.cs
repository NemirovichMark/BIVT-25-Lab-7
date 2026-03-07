namespace Lab7.White
{
    public class Task5
    {
        public struct Match
        {
            private int _goals;
            private int _misses;

            public int Goals { get { return _goals; } }
            public int Misses { get { return _misses; } }

            public int Difference => _goals-_misses;
            public int Score
            {
                get
                {
                    if (_goals > _misses)
                        return 3; // победа
                    else if (_goals == _misses)
                        return 1; // ничья
                    else
                        return 0; // проигрыш
                }
            }
            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;

            }
            public void Print()
            {
                Console.WriteLine($"Забито: {_goals}, Пропущено{_misses}");
                Console.WriteLine($"Разница:{Difference}, Очки:{Score}");
            }

        }
        public struct Team
        {
            private string _name;
            private Match[] _matches;

            public string Name => _name;
            public Match[] Matches => _matches;
            public int TotalDifference
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _matches.Length;i++)
                        sum += _matches[i].Difference;
                    return sum;
                }
            }
            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for(int i = 0; i < _matches.Length; i++)
                    {
                        sum += _matches[i].Score;

                    }
                    return sum;
                }
            }
            public Team(string name)
            {
                _matches= new Match[0];
                _name = name;
                
            }
            public void PlayMatch(int goals, int misses)
            {
                int currentLength = _matches.Length;
                Array.Resize(ref _matches, currentLength + 1);
                _matches[currentLength] = new Match(goals, misses);
            }
            public static void SortTeams(Team[] teams)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (teams[j].TotalDifference < teams[j + 1].TotalDifference)
                            {
                                Team temp = teams[j];
                                teams[j] = teams[j + 1];
                                teams[j + 1] = temp;

                            }
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"название: {_name}");
                Console.WriteLine($"Total Score: {TotalScore}");
                Console.WriteLine($"Total Diference: {TotalDifference}");
            }



        }


    }
}
