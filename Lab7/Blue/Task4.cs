using System;

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
                    if (_scores == null) return null;
                    return _scores;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        sum += _scores[i];
                    }
                    return sum;
                }
            }

            public Team(string team_name)
            {
                _name = team_name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (result < 0) return;

                if (_scores == null) _scores = new int[0];

                int[] new_res = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    new_res[i] = _scores[i];
                }
                new_res[_scores.Length] = result;
                _scores = new_res;
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name} | Итоговый балл: {TotalScore}");
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
                    if (_teams == null) return new Team[12];
                    return _teams;
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
                if (_teams == null) _teams = new Team[12];
                if (_count >= 12) return;

                _teams[_count] = team;
                _count++;
            }

            public void Add(Team[] multiple_teams)
            {
                if (_teams == null) _teams = new Team[12];
                if (multiple_teams == null) return;

                if (_count + multiple_teams.Length > 12) return;

                for (int i = 0; i < multiple_teams.Length; i++)
                {
                    _teams[_count] = multiple_teams[i];
                    _count++;
                }
            }

            public void Sort()
            {
                if (_teams == null) return;

                for (int i = 0; i < _count - 1; i++)
                {
                    for (int j = 0; j < _count - i - 1; j++)
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

                Team[] t1 = group1.Teams;
                Team[] t2 = group2.Teams;

                int i = 0;
                int j = 0;

                int limit1 = size / 2;
                int limit2 = size / 2;

                while (i < limit1 && j < limit2)
                {
                    if (t1[i].TotalScore >= t2[j].TotalScore)
                    {
                        result.Add(t1[i]);
                        i++;
                    }
                    else
                    {
                        result.Add(t2[j]);
                        j++;
                    }
                }

                while (i < limit1)
                {
                    result.Add(t1[i]);
                    i++;
                }

                while (j < limit2)
                {
                    result.Add(t2[j]);
                    j++;
                }

                return result;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {Name}");
            }
        }
    }
}