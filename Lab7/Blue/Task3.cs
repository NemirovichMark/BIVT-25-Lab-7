namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            readonly string name, surname;
            int[] penalty_times;
            int matches_played;

            public readonly string Name => name;
            public readonly string Surname => surname;
            public readonly int[]? PenaltyTimes => penalty_times == null ? null : (int[])penalty_times.Clone();

            public readonly int TotalTime
            {
                get
                {
                    if (penalty_times == null)
                    {
                        return 0;
                    }

                    int sum = 0;
                    for (int i = 0; i < matches_played; i += 1)
                    {
                        sum += penalty_times[i];
                    }

                    return sum;
                }
            }

            public readonly bool IsExpelled
            {
                get
                {
                    if (penalty_times == null) return false;
                    for (int i = 0; i < matches_played; i += 1)
                    {
                        if (penalty_times[i] == 10)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.penalty_times = []; // пустой массив, будет расширяться
                this.matches_played = 0;
            }

            public void PlayMatch(int time)
            {
                if (time < 0) return;

                // Расширяем массив на 1 элемент
                int newSize = matches_played + 1;
                int[] newArray = new int[newSize];
                if (matches_played > 0)
                {
                    Array.Copy(penalty_times, newArray, matches_played);
                }

                newArray[matches_played] = time;
                penalty_times = newArray;
                matches_played += 1;
            }

            public static void Sort(Participant[] array)
            {
                if (array != null)
                {
                    Array.Sort(array, (l, r) =>
                    {
                        // Сначала по возрастанию
                        int timeCompare = l.TotalTime.CompareTo(r.TotalTime);
                        if (timeCompare != 0)
                        {
                            return timeCompare;
                        }

                        // При равных исключенные идут перед неисключенными
                        if (l.IsExpelled && !r.IsExpelled)
                        {
                            return -1;
                        }

                        if (!l.IsExpelled && r.IsExpelled)
                        {
                            return 1;
                        }

                        // В остальных случаях сохраняем порядок
                        return 0;
                    });
                }
            }

            public readonly void Print() =>
                Console.WriteLine($"Participant{{name: \"{name}\", surname: \"{surname}\", totalTime: {TotalTime}, isExpelled: {IsExpelled}}}");
        }
    }
}