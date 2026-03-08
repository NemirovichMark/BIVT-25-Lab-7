namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;
            private int _matchCount;

            public string Name => _name;
            public string Surname => _surname;

            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null) return new int[0];
                    
                    int[] copy = new int[_matchCount];
                    Array.Copy(_penaltyTimes, copy, _matchCount);
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null) return 0;
                    
                    int sum = 0;
                    
                    for (int i = 0; i < _matchCount; i++)
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
                    if (_penaltyTimes == null) return false;
                    
                    for (int i = 0; i < _matchCount; i++)
                    {
                        if (_penaltyTimes[i] == 10) return true;
                    }
                    return false;
                }
            }
            
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[30]; 
                _matchCount = 0;
            }

            public void PlayMatch(int time)
            {
                
                if ((time == 0 || time == 2 || time == 5 || time == 10) && _matchCount < _penaltyTimes.Length)
                {
                    _penaltyTimes[_matchCount] = time;
                    _matchCount++;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].TotalTime > array[j].TotalTime)
                        {
                            (array[i], array[j]) = (array[j], array[i]);
                        }
                    }
                }
            }

            public void Print()
            {
                
                Console.Write($"{Name} {Surname} {TotalTime} ");
                
                if (_penaltyTimes != null)
                {
                    for (int i = 0; i < _matchCount; i++)
                    {
                        Console.Write($"{_penaltyTimes[i]} ");
                    }
                }
                
                Console.WriteLine();
            }
        }
    }
}
