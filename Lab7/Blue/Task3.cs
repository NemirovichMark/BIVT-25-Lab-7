namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            
            private string _name;
            private string _surname;
            private int[] _penaltytimes;

            
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    int[] copy = new int[_penaltytimes.Length];
                    for (int i = 0; i < copy.Length; i++)
                    {
                        copy[i] = _penaltytimes[i];
                    }
                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        sum += _penaltytimes[i];
                    }
                    return sum;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    bool f = false;
                    for (int i = 0; i < PenaltyTimes.Length; i++)
                    {
                        if (PenaltyTimes[i] == 10)
                        {
                            f = true;
                        }
                    }
                    return f;
                }
            }

            
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltytimes = new int[0];
            }

            public void PlayMatch(int time)
            {
                if (time != 0 && time != 2 && time != 5 && time != 10)
                {
                    return;
                }
                int[] array = new int[_penaltytimes.Length + 1];
                for (int i = 0; i < _penaltytimes.Length; i++)
                {
                    array[i] = _penaltytimes[i];
                }
                array[array.Length - 1] = time;
                _penaltytimes = array;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length; j++)
                    {
                        if (array[j].TotalTime < array[j - 1].TotalTime)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{IsExpelled},имя {_name}, фамилия: {_surname}, время: {TotalTime}");
            }
        }
    }
}
