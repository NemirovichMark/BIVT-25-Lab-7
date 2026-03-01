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
                    for (int i = 0; i < _scores.Length; i++)
                        sum += _scores[i];
                    
                    return sum;
                }
            }
            public Team(string name)
            {
                _name = name;
                _scores = [];
            }

            public void PlayMatch(int result)
            {
                int[] copy = new int[_scores.Length + 1];
                Array.Copy(_scores, copy, _scores.Length);
                copy[_scores.Length] = result;
                _scores = copy;
            }
            
            public void Print() {}

        }

        public struct Group
        {
            private string _name;
            
            private Team[] _teams;
            
            public string Name => _name;

            private int _count;

            public Team[] Teams
            {
                get
                {
                    Team[] copy = new Team[_teams.Length];
                    Array.Copy(_teams, copy, _teams.Length);
                    return copy;
                }
            }

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }

            public void Add(Team team)
            {
                if (_count + 1 > 12)
                    return;

                _teams[_count] = team;
                _count++;
            }

            public void Add(Team[] teams)
            {
                foreach (var team in teams)
                {
                    if (_count < 12)
                    {
                        _teams[_count] = team;
                        _count++;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            public void Sort()
            {
                _teams
                    .OrderByDescending(t => t.TotalScore)
                    .ToArray()
                    .CopyTo(_teams, 0);
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group destGroup = new Group("Финалисты");
                
                group1.Sort();
                group2.Sort();
                
                int sizePerGroup = size / 2;

                for (int i = 0; i < sizePerGroup; i++)
                {
                    destGroup.Add(group1.Teams[i]);
                    destGroup.Add(group2.Teams[i]);
                }
                
                destGroup.Sort();
                
                return destGroup;
            }

            public void Print() { }

        }
    }
    
}