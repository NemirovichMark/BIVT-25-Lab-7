using System.Runtime.Serialization.Formatters;

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
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        copy[i] = _penaltyTimes[i];
                    }
                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        sum += _penaltyTimes[i];
                    }
                    return sum;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        if (_penaltyTimes[i] == 10)
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
                _penaltyTimes = new int[0];
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length - i; j++)
                    {
                        if (array[j - 1].TotalTime > array[j].TotalTime)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }
                }
            }

            public void PlayMatch(int time)
            {
                if (time != 0 && time != 2 && time != 5 && time != 10)
                {
                    return;
                }
                Array.Resize(ref _penaltyTimes, _penaltyTimes.Length + 1);
                _penaltyTimes[_penaltyTimes.Length - 1] = time;
            }

            public void Print()
            {
                return;
            }
        }
    }
}
