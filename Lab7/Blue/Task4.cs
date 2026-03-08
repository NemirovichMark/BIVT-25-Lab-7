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
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        copy[i] = _scores[i];
                    }
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        sum += _scores[i];
                    }
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
                int[] newScores = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[newScores.Length - 1] = result;
                _scores = newScores;
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
                    for (int i = 0; i < _teams.Length; i++)
                    {
                        copy[i] = _teams[i];
                    }
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
                if (_count < 12)
                {
                    _teams[_count] = team;
                    _count++;
                }
            }

            public void Add(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    Add(teams[i]);
                }
            }

            public void Sort()
            {
                for (int i = 0; i < _teams.Length - 1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            Team temp = _teams[j];
                            _teams[j] = _teams[j + 1];
                            _teams[j + 1] = temp;
                        }
                    }
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
                
                Team[] all = new Team[size * 2];
                
                for (int i = 0; i < size; i++)
                {
                    if (i < group1._count) all[i] = group1._teams[i];
                    if (i < group2._count) all[size + i] = group2._teams[i];
                }
                
                for (int i = 0; i < all.Length - 1; i++)
                {
                    for (int j = 0; j < all.Length - 1 - i; j++)
                    {
                        if (all[j].TotalScore < all[j + 1].TotalScore)
                        {
                            Team temp = all[j];
                            all[j] = all[j + 1];
                            all[j + 1] = temp;
                        }
                    }
                }
                
                for (int i = 0; i < size && i < all.Length; i++)
                {
                    result.Add(all[i]);
                }
                
                return result;
            }
        }
    }
}
