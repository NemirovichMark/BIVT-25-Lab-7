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
                get { return _goals - _misses; }
            }
            public int Score
            {
                get
                {
                    if (_goals > _misses)
                    {
                        return 3;
                    }

                    else if (_goals == _misses)
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
                return;
            }
        }
        public struct Team
        {
            private string _name;
            private Match[] _matches;
            public string Name => _name;
            public Match[] Matches
            {
                get
                {
                    return _matches;
                }
            }
            public int TotalDifference
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < _matches.Length; i++)
                    {
                        total = total + _matches[i].Difference;
                    }
                    return total;
                }
            }
            public int TotalScore
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < _matches.Length; i++)
                    {
                        total = total + _matches[i].Score;
                    }
                    return total;
                }
            }
            public Team(string name)
            {
                _name = name;
                _matches = new Match[0];
            }
            public void PlayMatch(int goals, int misses)
            {
                Match[] newMatches = new Match[_matches.Length + 1];
                
                for (int i = 0; i < _matches.Length; i++)
                {
                    newMatches[i] = _matches[i];
                }
                
                newMatches[_matches.Length] = new Match(goals, misses);
                _matches = newMatches;
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
