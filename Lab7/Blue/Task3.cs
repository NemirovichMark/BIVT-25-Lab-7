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
                    Array.Copy(_penaltyTimes, copy, _penaltyTimes.Length);
                    
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    int sum = 0;

                    foreach (var time in _penaltyTimes)
                        sum += time;

                    return sum;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    foreach (var t in _penaltyTimes)
                        if (t == 10)
                            return true;

                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
            }

            public void PlayMatch(int time)
            {
                if (time == -1)
                    return;
                
                int[] newArray = new int[_penaltyTimes.Length + 1];

                Array.Copy(_penaltyTimes, newArray, _penaltyTimes.Length);

                newArray[^1] = time;
                _penaltyTimes = newArray;
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => a.TotalTime.CompareTo(b.TotalTime));
            }
            
            public void Print() { }
            
        } 

    }
    
}