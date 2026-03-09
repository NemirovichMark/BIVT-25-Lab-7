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

            public int Difference => _goals - _misses;

            public int Score
            {
                get
                {
                    if (Difference > 0) return 3;
                    if (Difference < 0) return 0;
                    return 1;
                }
            }

            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;
            }
            public void Print() { }
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
                    if (_matches == null) return default(int);
                    int ans = 0;
                    for (int i = 0; i < _matches.Length; i++)
                    {
                        ans += _matches[i].Difference;
                    }

                    return ans;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_matches == null) return default(int);
                    int ans = 0;
                    for (int i = 0; i < _matches.Length; i++)
                    {
                        ans += _matches[i].Score;
                    }

                    return ans;
                }
            }

            public Team(string name)
            {
                _name = name;
                _matches = new Match[0];
            }

            public void PlayMatch(int goals, int misses)
            {
                Array.Resize(ref _matches, _matches.Length + 1);
                _matches[_matches.Length - 1] = new Match(goals, misses);
            }

            public static void SortTeams(Team[] teams)
            {
                if (teams == null) return;
                int i = 0;
                while (i < teams.Length)
                {
                    if (i == 0 || teams[i].TotalScore < teams[i - 1].TotalScore)
                    {
                        i++;
                    }
                    else if (teams[i].TotalScore == teams[i - 1].TotalScore)
                    {
                        if (teams[i].TotalDifference <= teams[i - 1].TotalDifference)
                        {
                            i++;
                        }
                        else
                        {
                            Team tmp = teams[i];
                            teams[i] = teams[i - 1];
                            teams[i - 1] = tmp;
                            i--;
                        }
                    }
                    else
                    {
                        Team tmp = teams[i];
                        teams[i] = teams[i - 1];
                        teams[i - 1] = tmp;
                        i--;
                    }
                }
            }
            public void Print() { }
        }
    }
}