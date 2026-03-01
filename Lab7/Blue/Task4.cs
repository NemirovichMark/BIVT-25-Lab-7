namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;
            public string Name => _name;

            public int[] Scores
            {
                get
                {
                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, copy, _scores.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    foreach (int score in _scores) sum += score;
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print()
            {
                return;
            }
        }
        
        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _count;
            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    Team[] copy = new Team[_teams.Length];
                    Array.Copy(_teams, 0, copy, 0, _teams.Length);
                    return copy;
                }
            }

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }

            public void Add(Team team_add)
            {
                if (_count< 12)
                {
                    _teams[_count] = team_add;
                    _count++;
                }
            }

            public void Add(Team[] teams_add)
            {
                foreach (Team team_add in teams_add)
                {
                    Add(team_add);
                } 
            }
            public void Sort()
            {
                for (int i = 0; i < _teams.Length-1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++) if (_teams[j].TotalScore < _teams[j + 1].TotalScore) (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                }
            }

            public void Print()
            {
                return;
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                group1.Sort();
                group2.Sort();
                for (int i = 0; i < size; i += 2) result.Add([group1.Teams[i/2], group2.Teams[i/2]]);
                result.Sort();
                return result;
            }
        }
    }
}
