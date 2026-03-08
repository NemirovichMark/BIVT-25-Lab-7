using System.Diagnostics;
using System.Globalization;

namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            //fields
            private string _name;
            private int[] _scores;

            //parameters
            public string Name => _name;
            public int[] Scores => (int[])_scores.Clone();

            public int TotalScore
            {
                get
                {
                    int summ = 0;
                    foreach (int i in _scores)
                    {
                        summ += i;
                    }
                    return summ;
                }
            }

            //methods
            public void PlayMatch(int result)
            {
                if (true)
                {
                    Array.Resize(ref _scores, _scores.Length + 1);
                    _scores[_scores.Length - 1] = result;
                }
            }

            public void Print()
            {
                System.Console.WriteLine(_name);
                foreach (int res in _scores)
                {
                    System.Console.WriteLine(res);
                }
            }

            //constructor
            public Team (string name)
            {
                _name = name;
                _scores = new int[0];
            }
        }

        public struct Group
        {
            //fields
            private string _name;
            private Team[] _teams;
            private int _currcount;

            //parametrs
            public string Name => _name;
            public Team[] Teams => (Team[])_teams.Clone();


            //methods
            private void Resize(int size)
            {
                Array.Resize(ref _teams, size);
            }

            public void Add(Team team)
            {
                if (_currcount < 12)
                {
                    _teams[_currcount] = team;
                    _currcount++;
                }
            }

            public void Add(Team[] teams)
            {
                foreach (Team team in teams)
                {
                    Add(team);
                }
            }
            
            public void Sort()
            {
                Array.Sort(_teams, (a, b) => 
                {
                    int scorecomparsion = b.TotalScore.CompareTo(a.TotalScore);
                    if (scorecomparsion != 0) return scorecomparsion;
                    return b.Name.CompareTo(a.Name);
                });
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                var a = group1.Teams;
                var b = group2.Teams;

                int takeA = Math.Min(6, a.Length);
                int takeB = Math.Min(6, b.Length);

                Team[] selected = new Team[12];

                int i = 0, j = 0, k = 0;

                while (k < 12)
                {
                    bool aEnded = i >= takeA;
                    bool bEnded = j >= takeB;

                    if (aEnded)
                    {
                        selected[k++] = b[j++];
                        continue;
                    }
                    if (bEnded)
                    {
                        selected[k++] = a[i++];
                        continue;
                    }

                    int cmp = a[i].TotalScore.CompareTo(b[j].TotalScore);

                    if (cmp > 0) selected[k++] = a[i++];
                    else if (cmp < 0) selected[k++] = b[j++];
                    else selected[k++] = a[i++];
                }

                Group finals = new Group("Финалисты");
                finals.Add(selected);
                return finals;
            }

            public void Print()
            {
                System.Console.WriteLine($"Group name: {_name}");
            }

            //constructor
            public Group (string name)
            {
                _name = name;
                _teams = new Team[12];
                _currcount = 0;
            }
        }
    }
}