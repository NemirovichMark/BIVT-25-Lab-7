namespace Lab7.Blue
{
    public class Task3
    {
        struct DynamicArrayList
        {
            int[] penalties_buffer = [];
            int penalties_len = 0;

            public DynamicArrayList() { }

            public readonly bool Has(int search_target) => penalties_buffer.Any((item) => item == search_target);

            public readonly int[] View => (int[])penalties_buffer.Clone();

            public readonly int Sum() => penalties_buffer.Sum();

            public void Add(int item)
            {
                var new_buffer = new int[penalties_len + 1];
                if (penalties_len > 0)
                {
                    Array.Copy(penalties_buffer, new_buffer, penalties_len);
                }

                new_buffer[penalties_len] = item;
                penalties_buffer = new_buffer;
                penalties_len += 1;
            }
        }

        public struct Participant
        {
            const int expelled_value = 10;

            readonly string name, surname;
            DynamicArrayList penalties = new();

            public readonly string Name => name;
            public readonly string Surname => surname;
            public readonly int[] PenaltyTimes => penalties.View;
            public readonly int TotalTime => penalties.Sum();
            public readonly bool IsExpelled => penalties.Has(expelled_value);

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
            }

            public void PlayMatch(int time)
            {
                if (time >= 0) { penalties.Add(time); }
            }

            public static void Sort(Participant[]? array)
            {
                if (array == null) { return; }
                Array.Sort(array, (l, r) =>
                {
                    // по возрастанию
                    var c = l.TotalTime.CompareTo(r.TotalTime);
                    if (c != 0) { return c; }

                    // при равных исключенные идут перед неисключенными
                    if (l.IsExpelled && !r.IsExpelled) { return -1; }
                    if (!l.IsExpelled && r.IsExpelled) { return 1; }

                    return 0; // сохраняем порядок
                });
            }

            public readonly void Print() => Console.WriteLine(ToString());

            override public readonly string ToString() =>
                $"Participant{{name: \"{name}\", surname: \"{surname}\", totalTime: {TotalTime}, isExpelled: {IsExpelled}}}";
        }
    }
}