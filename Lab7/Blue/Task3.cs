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
                    if (_penaltytimes == null)
                    {
                        return new int[0];
                    }
                    int[] copy = new int[_penaltytimes.Length];
                    Array.Copy(_penaltytimes, copy, _penaltytimes.Length);
                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    if (_penaltytimes == null)
                    {
                        return 0;
                    }
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
                    if (_penaltytimes == null)
                    {
                        return false;
                    }
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        if (_penaltytimes[i] == 10)
                        {
                            return true;
                        }
                    }
                    return false;
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
                if (time != 0 && time != 2 && time != 5 && time != 10) return;

                if (_penaltytimes == null)
                {
                    _penaltytimes = new int[0];
                }

                int[] updated_times = new int[_penaltytimes.Length + 1];

                for (int i = 0; i < _penaltytimes.Length; i++)
                {
                    updated_times[i] = _penaltytimes[i];
                }

                updated_times[_penaltytimes.Length] = time;

                _penaltytimes = updated_times;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Спортсмен: {Surname} {Name} | Итоговое время: {TotalTime}");
            }



        }
    }
}