namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _panaltyTimes;

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes => (int[])_panaltyTimes.Clone();

            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _panaltyTimes.Length; i++)
                        sum += _panaltyTimes[i];
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _panaltyTimes = new int[0];
            }

            public bool IsExpelled
            {
                get
                {
                    if (_panaltyTimes.Length == 0)
                        return false;

                    for (int i = 0; i < _panaltyTimes.Length; i++)
                    {
                        if (_panaltyTimes[i] >= 10)
                            return true;
                    }

                    return false;
                }
            }

            public void PlayMatch(int time)
            {
                if (time < 0)
                    return;

                int[] newArr = new int[_panaltyTimes.Length + 1];
                for (int i = 0; i < _panaltyTimes.Length; i++)
                    newArr[i] = _panaltyTimes[i];
                newArr[newArr.Length - 1] = time;
                _panaltyTimes = newArr;
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