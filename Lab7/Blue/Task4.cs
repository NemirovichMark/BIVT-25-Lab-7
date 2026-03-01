namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            // поля
            private string _name;
            private int[] _scores;

            // свойства
            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    int[] copy = new int[_scores.Length];
                    for (int i = 0; i < copy.Length; i++)
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

            // конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                int[] newMatch = new int[_scores.Length+1];
                for (int i =0; i < _scores.Length; i++)
                {
                    newMatch[i] = _scores[i];
                }
                newMatch[newMatch.Length-1] = result;
                _scores = newMatch;
            }
            public void Print()
            {
                return;
            }
        }
        public struct Group
        {
            //поля
            private string _name;
            private Team[] _teams;
            private int count;

            // свойства
            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    Team[] copy = new Team[_teams.Length];
                    for (int i = 0; i< _teams.Length;i++)
                    {
                        copy[i] = _teams[i];
                    }
                    return copy;
                }
            }

            //конструктор
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                count = 0;
            }

            public void Add(Team name)
            {

                if (count >= 12)
                {
                    return;
                }
                _teams[count] = name;
                count++;
            }
            public void Add(Team[] names)
            {
                if (count >= 12)
                {
                    return;
                }
                for (int i = 0; i < names.Length; i++)
                {
                    Add(names[i]);
                }
            }
            public void Sort()
            {
                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 1; j < _teams.Length - i; j++)
                    {
                        if (_teams[j - 1].TotalScore < _teams[j].TotalScore) // убывания очков команды
                        {
                            (_teams[j - 1], _teams[j]) = (_teams[j], _teams[j - 1]);
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                int groupsize = size / 2;
                group1.Sort();
                group2.Sort();
                for (int i = 0; i < groupsize; i++)
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
