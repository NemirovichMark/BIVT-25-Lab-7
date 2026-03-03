namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            // Поля
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;
            
            // Свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes => _penaltyTimes.ToArray(); // Копия нужна

            public int TotalTime
            {
                get
                {
                    int total = 0;

                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        total += _penaltyTimes[i];
                    }
                    
                    return total;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    bool flag = false;

                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        if (_penaltyTimes[i] == 10)
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
                _penaltyTimes = new int[0];
            }

            public void PlayMatch(int time)
            {
                if (time != 0 && time != 2 && time != 5 && time != 10) return;
                
                Array.Resize(ref _penaltyTimes, _penaltyTimes.Length+1);
                _penaltyTimes[_penaltyTimes.Length - 1] = time;
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
                Console.WriteLine($"В составе {IsExpelled}, {_name}, {_surname}: {TotalTime}");
            }
            
        }
    }
}
