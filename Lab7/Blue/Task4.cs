namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            public string Name => _name;

            public int[] Scores => (int[])_scores.Clone();

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
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                int[] newArr = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                    newArr[i] = _scores[i];
                newArr[newArr.Length - 1] = result;
                _scores = newArr;
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
                        copy[i] = _teams[i];
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
                if (_count >= 12)
                    return;

                _teams[_count] = team;
                _count++;
            }

            public void Add(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    if (_count < 12)
                    {
                        _teams[_count] = teams[i];
                        _count++;
                    }
                    else
                        return;
                }
            }

            public void Sort()
            {
                for (int i = 0; i < _count - 1; i++)
                {
                    for (int j = 0; j < _count - 1 - i; j++)
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

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");

                group1.Sort();
                group2.Sort();

                int countTeam = size / 2;

                for (int i = 0; i < countTeam; i++)
                {
                    result.Add(group1._teams[i]);
                    result.Add(group2._teams[i]);
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