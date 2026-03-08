namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            //fields
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;

            //parameters
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes => (int[])_penaltyTimes.Clone();
            public int TotalTime
            {
                get
                {
                    int summ = 0;
                    foreach (int i in _penaltyTimes)
                    {
                        summ += i;
                    }
                    return summ;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    foreach (int i in _penaltyTimes)
                    {
                        if (i >= 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            //methods
            public void PlayMatch(int time)
            {
                if (time >= 0)
                {
                    Array.Resize(ref _penaltyTimes, _penaltyTimes.Length + 1);
                    _penaltyTimes[_penaltyTimes.Length - 1] = time;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array != null && array.Length != 0)
                {
                    Array.Sort(array, (a, b) => a.TotalTime.CompareTo(b.TotalTime));
                }
            }

            public void Print()
            {
                System.Console.WriteLine($"Name: {Name}, Surname: {Surname}, Penalty times: {PenaltyTimes}");
            }

            //constructor
            public Participant(string Name, string Surname)
            {
                _name = Name;
                _surname = Surname;
                _penaltyTimes = new int[0];
            }
        }
    }
}