namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    int[] copy = new int[_penaltyTimes.Length];
                    Array.Copy(_penaltyTimes, copy, _penaltyTimes.Length);

                    return copy;
                }
            }

            public int TotalTime => _penaltyTimes.Sum(); // Суммарное штрафное время

            public bool IsExpelled => _penaltyTimes.Any(time => time == 10); // Исключен ли игрок если был штраф 10 минут

            // Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
            }

            public void PlayMatch(int time) // добавляем штрафное время за матч
            {
                if (time != 0 && time != 2 && time != 5 && time != 10)
                    return;

                int[] newArray = new int[_penaltyTimes.Length + 1];

                Array.Copy(_penaltyTimes, newArray, _penaltyTimes.Length);

                newArray[^1] = time;
                _penaltyTimes = newArray;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1)
                    return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {PenaltyTimes}");
            }
        }
    }
}
