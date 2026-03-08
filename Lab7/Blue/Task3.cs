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
            public int[] PenaltyTimes => (int[])_penaltytimes.Clone();
            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    foreach (int mark in _penaltytimes)
                    {
                        sum += mark;
                    }
                    return sum;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    foreach (int mark in _penaltytimes)
                    {
                    
                        if (mark == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public Participant(string Name, string Surname)
            {
                _name = Name;
                _surname = Surname;
                _penaltytimes = new int[0];
            }
            public void PlayMatch(int time)
            {
                if (time == 0 || time == 2 || time == 5 || time == 10)
                {
                    Array.Resize(ref _penaltytimes, _penaltytimes.Length + 1);
                    _penaltytimes[_penaltytimes.Length - 1] = time;
                }
            }
            public static void Sort(Participant[] array)
            {
                var sorted = array.OrderBy(p => p.TotalTime).ToArray();

                Array.Copy(sorted, array, array.Length);
            }
            public void Print()
            {
                Console.WriteLine($"Name: {_name}\nSurname: {_surname}\n");
                foreach (int i in _penaltytimes)
                {
                    Console.WriteLine(i);
                }
            }
    }


    }
}
