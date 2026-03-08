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
            public int[] Scores => _scores;

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        total += _scores[i];
                    }
                    
                    return total;
                }
            }
            
            // Конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (result < 0) return;
                
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print()
            {
                Console.WriteLine($"{_name}: {TotalScore} score");
            }
        }

        public struct Group
        {
            // Поля
            private string _name;
            private Team[] _teams;
            private int _count;
            
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
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }

            public void Add(Team team)
            {
                if (_count >= 12) return;
                
                _teams[_count++] = team;
            }
            
            public void Add(Team[] teams)
            {
                foreach (Team t in teams)
                {
                    if (_count >= 12) break;
                    _teams[_count++] = t;
                }
            }

            public void Sort()
            {
                for (int i = 0; i < _count; i++)
                {
                    for (int j = 1; j < _count; j++)
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
                group1.Sort();
                group2.Sort();

                Group final = new Group("Финалисты");
                
                int newSize = size / 2;
                for (int i = 0; i < newSize; i++)
                {
                    final.Add(group1._teams[i]);
                    final.Add(group2._teams[i]);
                }

                final.Sort();
                return final;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {_name}, Кол-во команд: {_count}");
                Console.WriteLine("Команды: ");

                for (int i = 0; i < _count; i++)
                {
                    _teams[i].Print();
                }
            }
        }
    }

}
