namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;
            private int _matchCount;

            public string Name => _name;

            public int[] Scores
            {
                get
                {
                    if (_scores == null) return new int[0];
                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, copy, _scores.Length);
                    return copy;
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

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
                _matchCount = 0;
            }

            public void PlayMatch(int result)
            {
                if (_scores == null) return;

                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print()
            {
                Console.WriteLine($"{_name}: {TotalScore} очков");
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _teamCount;

            public string Name => _name;

            public Team[] Teams
            {
                get
                {
                    Team[] result = new Team[12];

                    if (_teams != null)
                    {
                        for (int i = 0; i < _teamCount && i < 12; i++)
                        {
                            result[i] = _teams[i];
                        }
                    }

                    return result;
                }
            }

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _teamCount = 0;
            }

            public void Add(Team team)
            {
                if (_teams == null) return;

                if (_teamCount < 12)
                {
                    _teams[_teamCount] = team;
                    _teamCount++;
                }
            }

            public void Add(Team[] teams)
            {
                if (_teams == null || teams == null) return;

                for (int i = 0; i < teams.Length; i++)
                {
                    if (_teamCount < 12)
                    {
                        _teams[_teamCount] = teams[i];
                        _teamCount++;
                    }
                    else break;
                }
            }

            public void Sort()
            {
                if (_teams == null || _teamCount <= 1) return;

                // Пузырек
                for (int i = 0; i < _teamCount - 1; i++)
                {
                    for (int j = i + 1; j < _teamCount; j++)
                    {
                        if (_teams[i].TotalScore < _teams[j].TotalScore)
                        {
                            Team temp = _teams[i];
                            _teams[i] = _teams[j];
                            _teams[j] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");

                group1.Sort();
                group2.Sort();

                Team[] teams1 = group1.Teams;
                Team[] teams2 = group2.Teams;

                int count1 = 0;
                int count2 = 0;

                for (int i = 0; i < teams1.Length; i++)
                {
                    if (teams1[i].Name != null) count1++;
                    else break;
                }

                for (int i = 0; i < teams2.Length; i++)
                {
                    if (teams2[i].Name != null) count2++;
                    else break;
                }

                int teamsFromEach = size / 2;

                Team[] candidates = new Team[teamsFromEach * 2];
                int candidateCount = 0;

                for (int i = 0; i < teamsFromEach && i < count1; i++)
                {
                    if (teams1[i].Name != null)
                    {
                        candidates[candidateCount] = teams1[i];
                        candidateCount++;
                    }
                }

                for (int i = 0; i < teamsFromEach && i < count2; i++)
                {
                    if (teams2[i].Name != null)
                    {
                        candidates[candidateCount] = teams2[i];
                        candidateCount++;
                    }
                }

                for (int i = 0; i < candidateCount - 1; i++)
                {
                    for (int j = i + 1; j < candidateCount; j++)
                    {
                        if (candidates[i].TotalScore < candidates[j].TotalScore)
                        {
                            Team temp = candidates[i];
                            candidates[i] = candidates[j];
                            candidates[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < candidateCount; i++)
                {
                    result.Add(candidates[i]);
                }

                return result;
            }

            public void Print()
            {
                Console.WriteLine($"Группа {_name}:");
                for (int i = 0; i < _teamCount; i++)
                {
                    if (_teams[i].Name != null)
                    {
                        _teams[i].Print();
                    }
                }
            }
        }
    }
}
