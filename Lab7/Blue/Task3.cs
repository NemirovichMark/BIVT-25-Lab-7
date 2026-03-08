namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penalty;
            
            public string Name => _name;
            public string Surname => _surname;

            public int[] PenaltyTimes
            {
                get
                {
                    int[] copy = new int[_penalty.Length];
                    for (int i = 0; i < _penalty.Length; i++)
                    {
                        copy[i] = _penalty[i];
                    }
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _penalty.Length; i++)
                    {
                        sum += _penalty[i];
                    }
                    return sum;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    for (int i = 0; i < _penalty.Length; i++)
                    {
                        if (_penalty[i] == 10) return true;
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penalty = new int[0];
            }

            public void PlayMatch(int time)
            {
                if (time != 0 && time != 2 && time != 5 && time != 10) return;
                
                int[] newPenalty = new int[_penalty.Length + 1];
                for (int i = 0; i < _penalty.Length; i++)
                {
                    newPenalty[i] = _penalty[i];
                }
                newPenalty[newPenalty.Length - 1] = time;
                _penalty = newPenalty;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
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
                return;
            }
        }
    }
}
