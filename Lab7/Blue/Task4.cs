using static Lab7.Blue.Task4;
using System;
namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            //polya
            private string _name;
            private int[] _scores;

            //свойства
            public string Name => _name;
            public int[] Scores => _scores;
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
            //конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                int[] array = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    array[i] = _scores[i];
                }
                array[array.Length - 1] = result;
                _scores = array;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}, {TotalScore}");
            }
        }

        public struct Group
        {
            //polya
            private string _name;
            private Team[] _teams;
            private int _count;

            //свойства
            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    Team[] array = new Team[_teams.Length];
                    for (int i = 0; i < _teams.Length; i++)
                    {
                        array[i] = _teams[i];
                    }
                    return array;
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
                if (_count >= 12) return;

                _teams[_count++] = team;
            }
            public void Add(Team[] teams)
            {
                foreach (Team t in teams)
                {
                    if (_count >= 12)
                    {
                        break;
                    }
                    Add(t);
                }
            }
            public void Sort()
            {
                for (int i = 0; i < _count; i++)
                {
                    for (int j = 1; j < _count; j++)
                    {
                        if (_teams[j].TotalScore > _teams[j - 1].TotalScore)
                        {
                            (_teams[j - 1], _teams[j]) = (_teams[j], _teams[j - 1]);
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                int t1 = size / 2;
                int t2 = size - t1;

                Team[] teams1 = group1.Teams;
                Team[] teams2 = group2.Teams;

                Group final = new Group("Финалисты");

                for (int i = 0; i < t1; i++)
                {
                    final.Add(teams1[i]);
                }
                for (int i = 0; i < t2; i++)
                {
                    final.Add(teams2[i]);
                }
                final.Sort();
                return final;
            }
            public void Print()
            {
                Console.WriteLine($"Группа: {Name}");
                Console.WriteLine("Список команд:");
                foreach (Team t in _teams)
                {
                    Console.WriteLine($"  {t.Name} (очков: {t.TotalScore})");
                }
            }
        }
    }
}
