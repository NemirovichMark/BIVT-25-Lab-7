namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            // Поля
            private string _name;
            private int[] _scores; 

            public Team(string name)
            {
                if (name != null)
                    _name = name;
                else
                    _name = "";
                _scores = new int[12]; // создаем массив на 12 матчей
            }

            public string Name => _name;

            public int[] Scores
            {
                get
                {
                    if (_scores == null)
                        return new int[0];

                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, copy, _scores.Length); // как фурычит - Array.Copy(откуда, куда, сколько);
                    return copy;
                }
            }
            // чек на сумму очков
            public int TotalScore
            {
                get
                {
                    if (_scores == null)
                        return 0;

                    int total = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        total += _scores[i];
                    }
                    return total;
                }
            }

            // + резы матча
            public void PlayMatch(int result)
            {
                // Создаем новый массив длина + 1, кописпастим и вставляем + 1
                int[] newScores = new int[_scores.Length + 1];

                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[_scores.Length] = result;
                _scores = newScores; // меняем данные на новые
            }

            public void Print()
            {
                Console.Write(Name);
                if (_scores != null)
                {
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        Console.Write(_scores[i]);
                    }
                }
                Console.WriteLine(TotalScore);
            }
        }

        public struct Group
        {
            // Поля
            private string _name;          
            private Team[] _teams; // Массив команд (фиксированный размер 12)
            private int _count;  // Сколько команд добавлено (0-12)
            private const int MAX_TEAMS = 12; // Максимум команд в группе

            public Group(string name)
            {
                if (name != null)
                    _name = name;
                else
                    _name = "";
                _teams = new Team[MAX_TEAMS];  // Массив на 12 команд
                _count = 0; // Пока команд нет
            }

            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    if (_teams == null)
                    {
                        _teams = new Team[MAX_TEAMS];
                        _count = 0;
                    }

                    Team[] copy = new Team[MAX_TEAMS];
                    for (int i = 0; i < MAX_TEAMS; i++)
                    {
                        copy[i] = _teams[i];
                    }
                    return copy;
                }
            }

            public void Add(Team team)
            {
                if (_teams == null)  // существует?
                {
                    _teams = new Team[MAX_TEAMS];
                    _count = 0;
                }

                if (_count >= MAX_TEAMS) // есть ли место?
                    return;

                // нет ли уже такой команды ?
                for (int i = 0; i < _count; i++)
                {
                    if (_teams[i].Name == team.Name)
                        return;
                }

                _teams[_count] = team; // Добавляем команду на свободное место
                _count++;
            }

            public void Add(Team[] teams)
            {
                if (teams == null || teams.Length == 0)
                    return;

                if (_teams == null)
                {
                    _teams = new Team[MAX_TEAMS];
                    _count = 0;
                }

                // Сколько свободных мест осталось
                int availableSlots = MAX_TEAMS - _count;
                if (availableSlots <= 0)
                    return;

                // + команды по одной, пока есть куда пихать
                for (int i = 0; i < teams.Length && availableSlots > 0; i++)
                {
                    // нарушение авторских прав?
                    bool isDuplicate = false;
                    for (int j = 0; j < _count; j++)
                    {
                        if (_teams[j].Name == teams[i].Name)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    // ееееее, го
                    if (!isDuplicate)
                    {
                        _teams[_count] = teams[i];
                        _count++;
                        availableSlots--;
                    }
                }
            }
            public void Sort()
            {
                if (_teams == null || _count <= 1)
                    return;

                Team[] RealOne = new Team[_count]; // чек на кол-во уникальных teams
                for (int i = 0; i < _count; i++)
                {
                    RealOne[i] = _teams[i];
                }

                for (int i = 0; i < RealOne.Length - 1; i++)
                {
                    for (int j = 0; j < RealOne.Length - 1 - i; j++)
                    {
                        if (RealOne[j].TotalScore < RealOne[j + 1].TotalScore)
                        {
                            (RealOne[j], RealOne[j + 1]) = (RealOne[j+1], RealOne[j]);
                        }
                    }
                }

                // засовываем отсортированные команды обратно в массив
                for (int i = 0; i < _count; i++)
                {
                    _teams[i] = RealOne[i];
                }
            }


            public static Group Merge(Group group1, Group group2, int size)
            {
                //+ финалисты
                Group result = new Group("Финалисты");

                // команды 1
                Team[] teams1 = new Team[group1._count];
                for (int i = 0; i < group1._count; i++)
                    teams1[i] = group1._teams[i];

                // команды 2
                Team[] teams2 = new Team[group2._count];
                for (int i = 0; i < group2._count; i++)
                    teams2[i] = group2._teams[i];

                for (int i = 0; i < teams1.Length - 1; i++)
                {
                    for (int j = 0; j < teams1.Length - 1 - i; j++)
                    {
                        if (teams1[j].TotalScore < teams1[j + 1].TotalScore)
                        {
                            (teams1[j], teams1[j + 1]) = (teams1[j], teams1[j + 1]);
                        }
                    }
                }

                for (int i = 0; i < teams2.Length - 1; i++)
                {
                    for (int j = 0; j < teams2.Length - 1 - i; j++)
                    {
                        if (teams2[j].TotalScore < teams2[j + 1].TotalScore)
                        {
                            (teams2[j], teams2[j + 1]) = (teams2[j + 1], teams2[j]);
                        }
                    }
                }

                // Берем по 6 лучших из каждой группы 
                int takeFromGroup1 = Math.Min(6, teams1.Length);
                int takeFromGroup2 = Math.Min(6, teams2.Length);

                // Создаем массив для финалистов
                Team[] finalists = new Team[takeFromGroup1 + takeFromGroup2];
                int finalistIndex = 0;

                // Добавляем лучшие команды
                for (int i = 0; i < takeFromGroup1; i++)
                    finalists[finalistIndex++] = teams1[i];
                for (int i = 0; i < takeFromGroup2; i++)
                    finalists[finalistIndex++] = teams2[i];

                // Сортируем всех
                for (int i = 0; i < finalistIndex - 1; i++)
                {
                    for (int j = 0; j < finalistIndex - 1 - i; j++)
                    {
                        if (finalists[j].TotalScore < finalists[j + 1].TotalScore)
                        {
                            (finalists[j], finalists[j + 1]) = (finalists[j+1], finalists[j]);
                        }
                    }
                }

                // Берем только нужное кол-во финалистов
                int teamsToTake = Math.Min(size, finalistIndex);
                for (int i = 0; i < teamsToTake; i++)
                    result.Add(finalists[i]);

                return result;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {Name} (команд: {_count} из {MAX_TEAMS})");
                if (_count > 0)
                {
                    for (int i = 0; i < _count; i++)
                    {
                        Console.Write(i + 1);
                        _teams[i].Print();
                    }
                }
            }
        }
    }
}