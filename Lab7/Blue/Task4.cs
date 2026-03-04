namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            // Поля
            private string _name;
            private int[] _scores;
            // Свойства
            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, 0, copy, 0, _scores.Length);
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
            // Конструткор
            public Team (string name)
            {
                _name = name;
                _scores = new int[0];
            }
            // Метод
            public void PlayMatch(int result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[^1] = result;
            }
            public void Print()
            {
                return;
            }
        }
        public struct Group
        {
            // Поля
            private string _name;
            private Team[] _teams;
            private int _k;
            // Свойства
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
            // Конструктор
            public Group (string name)
            {
                _name = name;
                _teams = new Team[12];
                _k = 0;
            }
            public void Add(Team team)
            {
                if (_k < 12)
                {
                    _teams[_k] = team;
                    _k++;
                }
            }
            public void Add(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    if (_k < 12)
                        Add(teams[i]);
                    else
                        break;
                }
            }
            public void Sort()
            {
                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 1; j < _teams.Length; j++)
                    {
                        if (_teams[j - 1].TotalScore < _teams[j].TotalScore)
                        {
                            (_teams[j - 1], _teams[j]) = (_teams[j], _teams[j - 1]);
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");
                group1.Sort(); group2.Sort();
                for (int i = 0; i < size/2; i++) // выбирается 6 лучших команд , а у нас 12
                {
                    finalists.Add(group1._teams[i]);// берем отсюда 6 лучших
                    finalists.Add(group2._teams[i]);
                }
                finalists.Sort();
                return finalists;
            }
            public void Print()
            {
                return;
            }
        }
    }
}
