using System;

namespace Lab7.White
{
    public class Task5
    {
        // Структура Match (матч)
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
                Console.WriteLine($"{goals}:{misses}");
            }
        }

        // Структура Team (команда)
        public struct Team
        {
            private string name;
            private Match[] matches;
            private int count;

            public string Name => name;
            
            // НУЖНО ДОБАВИТЬ СВОЙСТВО Matches
            public Match[] Matches => matches;

            public Team(string name)
            {
                this.name = name;
                matches = new Match[100];
                count = 0;
            }

            // НУЖНО ДОБАВИТЬ МЕТОД PlayMatch
            public void PlayMatch(int goals, int misses)
            {
                matches[count] = new Match(goals, misses);
                count++;
            }

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < count; i++)
                    {
                        total += matches[i].Score;
                    }
                    return total;
                }
            }

            // НУЖНО ДОБАВИТЬ СВОЙСТВО TotalDifference
            public int TotalDifference
            {
                get
                {
                    int diff = 0;
                    for (int i = 0; i < count; i++)
                    {
                        diff += matches[i].Difference;
                    }
                    return diff;
                }
            }

            public int GoalDifference => TotalDifference; // для удобства

            // ИСПРАВИТЬ ИМЯ МЕТОДА - должно быть SortTeams
            public static void SortTeams(Team[] array)
            {
                Array.Sort(array, (a, b) => 
                {
                    if (a.TotalScore != b.TotalScore)
                        return b.TotalScore.CompareTo(a.TotalScore);
                    return b.TotalDifference.CompareTo(a.TotalDifference);
                });
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {name} | Очки: {TotalScore} | Разница: {TotalDifference}");
            }
        }
    }
}
