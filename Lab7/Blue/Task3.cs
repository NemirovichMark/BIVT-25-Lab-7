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
            public int[] PenaltyTimes =>  (int[])_penaltyTimes.Clone();
            

            public int TotalTime => _penaltyTimes.Sum();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = [];
            }

            public bool IsExpelled
            {
                get {
                    bool isExpelled = true;
                    if (_penaltyTimes == null || _penaltyTimes.Length == 0)
                        return !isExpelled;

                    foreach (var time in _penaltyTimes)
                    {
                        if (time >= 10)
                            return isExpelled;
                    }

                    return !isExpelled;
                }
            }

            public void PlayMatch(int time)
            {
                if (time < 0)
                    return;

                Array.Resize(ref _penaltyTimes, _penaltyTimes.Length + 1);
                _penaltyTimes[^1] = time;
            }

            public static void Sort(Participant[] array)
            {
               var sorted = array
                .OrderBy(p => p.TotalTime)
                .ToArray();

                Array.Copy(sorted, array, array.Length);
            }

            public void Print()
            {
                return;
            }
        }
    }
}
