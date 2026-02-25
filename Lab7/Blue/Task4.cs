using System.Collections.Immutable;

namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _Name;
            private int[] _Scores;
            public int TotalScore => _Scores.Sum();
            public string Name => _Name;

            public int[] Scores
            {
                get
                {
                    int[] copy = new int[_Scores.Length];
                    Array.Copy(_Scores, copy, _Scores.Length);
                    return copy;
                }
            }

            public Team(string name)
            {
                _Name = name;
                _Scores = [];
            }
            public void PlayMatch(int result)
            {
                int[] newScores = new int[_Scores.Length + 1];
                Array.Copy(_Scores, newScores, _Scores.Length);
                newScores[_Scores.Length] = result;
                _Scores = newScores;
            }

            public void Print()
            {
                return;
            }
        }

        public struct Group
        {
            private string _Name;
            private Team[] _Teams;
            private int _Count;
            
            public string Name => _Name;

            public Team[] Teams
            {
                get
                {
                    Team[] copy = new Team[_Teams.Length];
                    Array.Copy(_Teams, copy, _Teams.Length);
                    return copy;
                }
            }
            
            public Group(string name)
            {
                _Name = name;
                _Teams = new Team[12];
                _Count = 0;
            }

            
            public void Add(Team team)
            {
                if (_Count >= 12) return;
                else
                {
                    _Teams[_Count] = team;
                    _Count++;
                }
            }

           
            public void Add(Team[] teams)
            {
                    foreach (var team in teams)
                    {
                        if (_Count < 12)
                        {
                            _Teams[_Count] = team;
                            _Count++;
                        }
                        else return;
                        
                    }
            }
            public void Sort()
            {
                var sorted = _Teams.Take(_Count)
                                   .OrderByDescending(t => t.TotalScore)
                                   .ToArray();
                Array.Copy(sorted, _Teams, _Count);
            }
            
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                
                group1.Sort();
                group2.Sort();
                
                int countTeam = size / 2;

                for (int i = 0; i < countTeam; i++)
                {
                    result.Add(group1._Teams[i]);
                    result.Add(group2._Teams[i]);
                }
                result.Sort();
                return result;
            }
            
            public void Print()
            {
            }
        }
    }
}