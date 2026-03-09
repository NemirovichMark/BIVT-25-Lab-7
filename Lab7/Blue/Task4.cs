using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;
            public string Name
            {
                get
                {
                    return _name;
                }
            }
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


            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                int[] new_score = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    new_score[i] = _scores[i];
                }
                new_score[_scores.Length] = result;
                _scores = new_score;
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
            private int team_count;
            public string Name
            {
                get { return _name; }
            }
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
                team_count = 0;
            }

            public void Add(Team name)
            {
                if (team_count >= 12) return;
                _teams[team_count] = name;
                team_count++;
            }

            public void Add(Team[] names)
            {
                if (team_count >= 12) return;
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
                        if (_teams[j - 1].TotalScore < _teams[j].TotalScore)
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
