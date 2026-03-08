using System.ComponentModel;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;
            public string Name => _name;
            public int[] Scores => _scores;

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
            public Team(string Name)
            {
                _name = Name;
                _scores = new int[1];
            }
            public void PlayMatch(int result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name}, Очки: {TotalScore}");
            }


        }
        public struct Group
        {
            private string _name;
            private Team[] _teams;
            public string Name => _name;
            public Team[] Teams => _teams;
            private int _count;

            public Group(string Name)
            {
                _name = Name;
                _teams = new Team[12];
                _count = 0;
            }
            public void Add(Team Name)
            {
                if (_count < 12)
                {
                    _teams[_count] = Name;
                    _count++;
                }
            }
            public void Add(Team[] Names)
            {
                foreach (Team name in Names)
                {
                    Add(name);

                }
            }
            public void Sort()
            {
                for (int i = 0; i < _teams.Length - 1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                group1.Sort();
                group2.Sort();
                for (int i = 0; i < size; i += 2)
                {
                    result.Add([group1.Teams[i / 2], group2.Teams[i / 2]]);
                }
                result.Sort();
                return result;
            }
            public void Print()
            {
                Console.WriteLine($"Группа: {Name}");
                foreach (Team team in _teams)
                {
                    team.Print();
                }
            }

        }
    }
}
