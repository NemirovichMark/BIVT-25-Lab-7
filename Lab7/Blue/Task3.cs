namespace Lab7.Blue
{
    public class Task3
    {
        struct DynamicArrayList
        {
            int[] penalties_buffer = [];
            int penalties_len = 0;

            public DynamicArrayList() { }

            public readonly bool ListHas(int search_target) => penalties_buffer.Any((item) => item == search_target);

            public readonly int[] ListView => (int[])penalties_buffer.Clone();

            public readonly int ListSum() => penalties_buffer.Sum();

            public void ListAdd(int i)
            {
                var new_len = penalties_len + 1;
                var new_buffer = new int[new_len];
                if (penalties_len > 0)
                {
                    Array.Copy(penalties_buffer, new_buffer, penalties_len);
                }

                new_buffer[penalties_len] = i;
                penalties_buffer = new_buffer;
                penalties_len += 1;
            }
        }

        public struct Participant
        {
            readonly string name, surname;
            DynamicArrayList penalties = new();

            public readonly string Name => name;
            public readonly string Surname => surname;
            public readonly int[] PenaltyTimes => penalties.ListView;
            public readonly int TotalTime => penalties.ListSum();
            public readonly bool IsExpelled => penalties.ListHas(10);

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
            }

            public void PlayMatch(int time)
            {
                if (time >= 0) { penalties.ListAdd(time); }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) { return; }
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

            public readonly void Print() =>
                Console.WriteLine($"Participant{{name: \"{name}\", surname: \"{surname}\", totalTime: {TotalTime}, isExpelled: {IsExpelled}}}");
        }
    }
}