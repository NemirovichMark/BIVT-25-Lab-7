namespace Lab7.White
{
    public class Task5
    {
        public struct Match
        {
            private int _goals;
            private int _misses;
            public int Goals => _goals;
            public int Misses => _misses;
            public int Difference
            {
                get
                {
                    return _goals - _misses;
                }
            }
            public int Score
            {
                get
                {
                    if(Difference > 0)
                    {
                        return 3;
                    }else if( Difference == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;
            }
            public void Print()
            {
                Console.WriteLine($"Goals: {_goals}");
                Console.WriteLine($"Misses: {_misses}");
                Console.WriteLine($"Difference: {Difference}");
                Console.WriteLine($"Score: {Score}");
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
                    int count = 0;

                    for(int i = 0; i < _matches.Length; i++)
                    {
                        count += _matches[i].Difference;
                    }
                    return count;
                }
            }
            public int TotalScore
            {
                get
                {
                    int count = 0;
                    for (int i = 0; i < _matches.Length; i++)
                    {
                        count+= _matches[i].Score;
                    }
                    return count;
                }
            }
            public Team(string name)
            {
                _name = name;
                _matches = new Match[0]; 
            }
            public void PlayMatch( int goals, int misses)
            {
                int currentLength = _matches.Length;
                Array.Resize(ref _matches, currentLength + 1);
                _matches[currentLength] = new Match(goals,misses);
            }
            public static void SortTeams(Team[] teams)
            {
                for( int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 -i; j++)
                    {
                        if(teams[j].TotalScore < teams [j + 1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if(teams[j].TotalDifference < teams[j + 1].TotalDifference)
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
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Total Score: {TotalScore}");
                Console.WriteLine($"Total Diference: {TotalDifference}");
                Console.WriteLine($"Matches: ");
                if (_matches == null || _matches.Length == 0)
                {
                    Console.WriteLine("This Team doesn't have Matches");
                }
                else
                {
                    for(int i = 0; i < _matches.Length; i++)
                    {
                        Console.WriteLine($"{i+1}° Match Goals: {_matches[i].Goals} ");
                        Console.WriteLine($"{i+1}° Match Misses: {_matches[i].Misses} ");
                        Console.WriteLine($"{i+1}° Match Score: {_matches[i].Score} ");
                    }    
                }


            }
        }
    }
}