namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {

            // Поля
            private string _name;
            private string _surname;
            private int[] _PenaltyTimes;
            // Свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    int[] copy = new int[_PenaltyTimes.Length];
                    Array.Copy(_PenaltyTimes, 0, copy, 0, _PenaltyTimes.Length);
                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _PenaltyTimes.Length; i++)
                    {
                        sum += _PenaltyTimes[i];
                    }
                    return sum;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    bool flag = false;
                    for (int i = 0; i < _PenaltyTimes.Length; i++)
                    {
                        if (_PenaltyTimes[i] == 10)
                        {
                            flag = true;
                        }
                    }
                    return flag;
                }
            }
            // Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _PenaltyTimes = new int[0];
            }
            // Метод
            public void PlayMatch(int time)
            {
                if (time != 0 && time != 2 && time != 5 && time != 10) return;
                Array.Resize(ref _PenaltyTimes, _PenaltyTimes.Length+1);
                _PenaltyTimes[^1] = time; 
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length; j++)
                    {
                        if (array[j - 1].TotalTime > array[j].TotalTime)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }
                }
            }
            public void Print()
            {
                return;
            }
        }
    }
}
