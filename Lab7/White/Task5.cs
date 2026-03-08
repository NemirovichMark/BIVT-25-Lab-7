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
                    if (_goals > _misses)
                        return 3;
                    if (_goals == _misses)
                        return 1;
                    return 0;
                }
            }

            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;
            }

            public void Print()
            {
                Console.WriteLine($"  {_goals}:{_misses}  diff: {Difference}  pts: {Score}");
            }
        }

        public struct Team
        {
            private string _name;
            private Match[] _matches;
            private int _matchCount;

            public string Name => _name;

            public Match[] Matches
            {
                get
                {
                    Match[] result = new Match[_matchCount];
                    for (int i = 0; i < _matchCount; i++)
                        result[i] = _matches[i];
                    return result;
                }
            }

            public int TotalDifference
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _matchCount; i++)
                        sum += _matches[i].Difference;
                    return sum;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _matchCount; i++)
                        sum += _matches[i].Score;
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _matches = new Match[100];
                _matchCount = 0;
            }

            public void PlayMatch(int goals, int misses)
            {
                _matches[_matchCount] = new Match(goals, misses);
                _matchCount++;
            }

            public static void SortTeams(Team[] teams)
            {
                Array.Sort(teams, (a, b) =>
                {
                    if (a.TotalScore != b.TotalScore)
                        return b.TotalScore.CompareTo(a.TotalScore);
                    return b.TotalDifference.CompareTo(a.TotalDifference);
                });
            }

            public void Print()
            {
                Console.WriteLine($"Team: {_name}");
                Console.WriteLine($"Total score: {TotalScore}");
                Console.WriteLine($"Total difference: {TotalDifference}");
                Console.WriteLine("Matches:");
                for (int i = 0; i < _matchCount; i++)
                    _matches[i].Print();
                Console.WriteLine("------------------------");
            }
        }
    }
}
