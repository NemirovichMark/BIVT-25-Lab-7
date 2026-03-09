namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _teamName;
            private int[] _matchResults;

            public string Name => _teamName;
            
            public int[] Scores
            {
                get
                {
                    int[] copy = new int[_matchResults.Length];
                    for (int i = 0; i < copy.Length; i++)
                        copy[i] = _matchResults[i];
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _matchResults.Length; i++)
                        sum += _matchResults[i];
                    return sum;
                }
            }

            public Team(string name)
            {
                _teamName = name;
                _matchResults = new int[0];
            }

            public void PlayMatch(int result)
            {
                int[] newResults = new int[_matchResults.Length + 1];
                for (int i = 0; i < _matchResults.Length; i++)
                    newResults[i] = _matchResults[i];
                
                newResults[_matchResults.Length] = result;
                _matchResults = newResults;
            }

            public void Print()
            {
                return;
            }
        }

        public struct Group
        {
            private string _groupName;
            private Team[] _groupTeams;
            private int _teamCount;

            public string Name => _groupName;
            
            public Team[] Teams
            {
                get
                {
                    Team[] copy = new Team[_teamCount];
                    for (int i = 0; i < _teamCount; i++)
                        copy[i] = _groupTeams[i];
                    return copy;
                }
            }

            public Group(string name)
            {
                _groupName = name;
                _groupTeams = new Team[12];
                _teamCount = 0;
            }

            public void Add(Team team)
            {
                if (_teamCount >= 12) return;
                _groupTeams[_teamCount] = team;
                _teamCount++;
            }

            public void Add(Team[] teams)
            {
                if (_teamCount >= 12) return;
                
                for (int i = 0; i < teams.Length; i++)
                    Add(teams[i]);
            }

            public void Sort()
            {
                for (int i = 0; i < _teamCount; i++)
                {
                    for (int j = 1; j < _teamCount - i; j++)
                    {
                        if (_groupTeams[j - 1].TotalScore < _groupTeams[j].TotalScore)
                        {
                            Team temp = _groupTeams[j - 1];
                            _groupTeams[j - 1] = _groupTeams[j];
                            _groupTeams[j] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group first, Group second, int size)
            {
                Group result = new Group("Финалисты");
                int teamsFromEach = size / 2;
                
                first.Sort();
                second.Sort();
                
                for (int i = 0; i < teamsFromEach; i++)
                {
                    result.Add(first._groupTeams[i]);
                    result.Add(second._groupTeams[i]);
                }
                
                result.Sort();
                return result;
            }

            public void Print()
            {
                return;
            }
        }
    }
}
