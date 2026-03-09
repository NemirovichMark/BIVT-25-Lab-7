namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name; // название команды
            private int[] _scores; // очки за матч

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

            // суммарный счет
            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    foreach (int score in _scores)
                    {
                        sum += score;
                    }
                    return sum;
                }
            }
            // конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[12]; // массив на 12 матчей
            }

            public void PlayMatch(int result)
            {
                int[] newMatch = new int[_scores.Length + 1]; // создаем массив на 1 больше
                Array.Copy(_scores, newMatch, _scores.Length); // копируем старый
                newMatch[newMatch.Length - 1] = result; // добавляем рез
                _scores = newMatch;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {TotalScore}");
            }
        }
        public struct Group
        {
            private string _name;
            private Team[] _teams; // команды
            private int _count; // сколько команд уже добавленно

            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    Team[] copy = new Team[_teams.Length];
                    Array.Copy(_teams, copy, _teams.Length);
                    return copy;
                }
            }

            // конструктор
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0; // изначально 0 команд добавлено
            }

            public void Add(Team name) // добавить одну команду
            {

                if (_count >= 12) // проверка на больше 12
                {
                    return;
                }
                _teams[_count] = name;
                _count++;
            }
            public void Add(Team[] names) // добавить несколько команд
            {
                if (_count >= 12) // нельзя добавить больше 12 команд
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

                for (int i = 0; i < _teams.Length - 1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                int groupsize = size / 2; // группа из 6 человек
                group1.Sort();
                group2.Sort(); // отсортировали две группы
                for (int i = 0; i < groupsize; i++) // добавили обе группы
                {
                    result.Add(group1._teams[i]);
                    result.Add(group2._teams[i]);
                }
                result.Sort(); // отсортировали новый общий массив групп
                return result;
            }

            public void Print()
            {
                Console.WriteLine("Group: " + _name);
                for (int i = 0; i < _teams.Length; i++)
                {
                    Console.Write("  ");
                    _teams[i].Print();
                }
            }
        }
    }
}
