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
                    Array.Copy(_penalty, copy, _penalty.Length);
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    int ans = 0;
                    foreach (int val in _penalty) ans += val;
                    return ans;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    foreach (int val in _penalty)
                    {
                        if (val == 10) return true;
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
                if (time == 0 || time == 2 || time == 5 || time == 10)
                {
                    Array.Resize(ref _penalty, _penalty.Length + 1);
                    _penalty[_penalty.Length - 1] = time;
                }
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
                return;
            }

        }
    }
}
