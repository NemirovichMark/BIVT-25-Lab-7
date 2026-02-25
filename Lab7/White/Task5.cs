namespace Lab7.White
{
    public class Task5
    {
        public struct Match
        {
            private int goals;
            private int misses;

            public int Goals => goals;
            public int Misses => misses;
            public int Difference => goals - misses;
            public int Score
            {
                get
                {
                    if (goals > misses) return 3;
                    if (goals == misses) return 1;
                    return 0;
                }
            }

            public Match(int goals, int misses)
            {
                this.goals = goals;
                this.misses = misses;
            }

            public void Print()
            {
                Console.WriteLine($"Goals: {goals}, Misses: {misses}, Difference: {Difference}, Score: {Score}");
            }
        }

        public struct Team
        {
            private string name;
            private Match[] matches;
            private int matchCount;

            public string Name => name;
            public Match[] Matches
            {
                get
                {
                    return matches;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (matches == null || matchCount == 0) return 0;

                    int total = 0;
                    for (int i = 0; i < matchCount; i++)
                    {
                        total += matches[i].Score;
                    }
                    return total;
                }
            }

            public int TotalDifference
            {
                get
                {
                    if (matches == null || matchCount == 0) return 0;

                    int total = 0;
                    for (int i = 0; i < matchCount; i++)
                    {
                        total += matches[i].Difference;
                    }
                    return total;
                }
            }

            public Team(string name)
            {
                this.name = name;
                matches = new Match[10];
                matchCount = 0;
            }

            public void PlayMatch(int goals, int misses)
            {
                if (matches == null)
                {
                    matches = new Match[10];
                    matchCount = 0;
                }

                if (matchCount >= matches.Length)
                {
                    Array.Resize(ref matches, matches.Length * 2);
                }

                matches[matchCount] = new Match(goals, misses);
                matchCount++;
            }

            public static void SortTeams(Team[] teams)
            {
                if (teams == null) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        bool needSwap = false;

                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            needSwap = true;
                        }
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (teams[j].TotalDifference < teams[j + 1].TotalDifference)
                            {
                                needSwap = true;
                            }
                        }

                        if (needSwap)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Name: {name}, TotalScore: {TotalScore}, TotalDifference: {TotalDifference}");
            }
        }
    }
}