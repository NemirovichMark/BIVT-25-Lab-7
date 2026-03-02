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
                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, copy, _scores.Length);
                    
                    return copy;
                }
            }
            
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
            
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }
            
            public void PlayMatch(int result)
            {
                int[] newMatch = new int[_scores.Length+1];
                Array.Copy(_scores, newMatch, _scores.Length);
                newMatch[newMatch.Length-1] = result;
                _scores = newMatch;
            }
            
            public void Print()
            {
                Console.WriteLine("Name: " + _name + ", TotalScore: " + TotalScore);
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
                    Team[] copy = new Team[_teams.Length];
                    Array.Copy(_teams, copy, _teams.Length);
                    return copy;
                }
            }
            
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }

            public void Add(Team name)
            {

                if (_count >= 12)
                {
                    return;
                }
                _teams[_count] = name;
                _count++;
            }
            public void Add(Team[] names)
            {
                if (_count >= 12)
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
                Array.Sort(_teams, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
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
