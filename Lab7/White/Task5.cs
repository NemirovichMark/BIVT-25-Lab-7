namespace Lab7.White
{
    public class Task5
    {
        public struct Match
        {
            private int goals;
            private int misses;

            public Match(int goals, int misses)
            {
                this.goals = goals;
                this.misses = misses;
            }

            public int Goals => goals; //получаем св-во только для чтения приватных полей
            public int Misses => misses; //получаем св-во только для чтения приватных полей
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

            public void Print()
            {
                Console.WriteLine($"Goals: {Goals}, Misses: {Misses}, " +
                                  $"Difference: {Difference}, Score: {Score}");
            }
        }

        public struct Team
        {
            private string name;
            private Match[] matches;

            public Team(string name)
            {
                this.name = name;
                this.matches = Array.Empty<Match>();  // или new Match[0]
            }

            public string Name => name;
            public Match[] Matches => matches;

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    foreach (var m in matches)
                    {
                        sum += m.Score;
                    }
                    return sum;
                }
            }

            public int TotalDifference
            {
                get
                {
                    int sum = 0;
                    foreach (var m in matches)
                    {
                        sum += m.Difference;
                    }
                    return sum;
                }
            }

            public void PlayMatch(int goals, int misses)
            {
                // создаём новый массив на 1 элемент больше
                var newMatches = new Match[matches.Length + 1];

                // копируем старые матчи
                for (int i = 0; i < matches.Length; i++)
                {
                    newMatches[i] = matches[i];
                }

                // добавляем новый
                newMatches[matches.Length] = new Match(goals, misses);

                // заменяем ссылку
                matches = newMatches;
            }

            public static void SortTeams(Team[] teams)
            {
                // Сортировка по убыванию очков, при равенстве — по убыванию разницы
                Array.Sort(teams, (a, b) =>
                {
                    int scoreCompare = b.TotalScore.CompareTo(a.TotalScore);
                    if (scoreCompare != 0) return scoreCompare;

                    return b.TotalDifference.CompareTo(a.TotalDifference);
                });
            }

            public void Print()
            {
                Console.WriteLine($"Team: {Name}");
                Console.WriteLine($"Total score: {TotalScore}");
                Console.WriteLine($"Total goal difference: {TotalDifference}");
                Console.WriteLine("Matches:");

                if (matches.Length == 0)
                {
                    Console.WriteLine("  No matches played.");
                }
                else
                {
                    foreach (var match in matches)
                    {
                        Console.Write("  ");
                        match.Print();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
