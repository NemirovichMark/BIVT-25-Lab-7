using System;

namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            private string _Name;
            private string _Surname;
            private int[] _PenaltyTimes;
            private bool _IsExpelled;

            public string Name => _Name;
            public string Surname => _Surname;
            public bool IsExpelled => _IsExpelled;

            public int[] PenaltyTimes
            {
                get
                {
                    if (_PenaltyTimes == null)
                        return null;
                    
                    int[] copy = new int[_PenaltyTimes.Length];
                    Array.Copy(_PenaltyTimes, copy, _PenaltyTimes.Length);
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_PenaltyTimes == null)
                        return 0;
                    
                    int sum = 0;
                    for (int i = 0; i < _PenaltyTimes.Length; i++)
                    {
                        if (_PenaltyTimes[i] != -1)
                            sum += _PenaltyTimes[i];
                    }
                    return sum;
                }
            }

            public Participant(string Name, string Surname)
            {
                _Name = Name; 
                _Surname = Surname;
                _PenaltyTimes = [];
                _IsExpelled = false;
            }

            public void PlayMatch(int time)
            {
               if (time == -1)
                    return;
                if (time == 10)
                    _IsExpelled = true;

                int[] newTimes = new int[_PenaltyTimes.Length + 1];
                Array.Copy(_PenaltyTimes, newTimes, _PenaltyTimes.Length);
                newTimes[_PenaltyTimes.Length] = time;
                _PenaltyTimes = newTimes;
                
                
            }

            public static void Sort(Participant[] array)
            {
                if (array == null)
                    return;

                Array.Sort(array, (a, b) => a.TotalTime.CompareTo(b.TotalTime));
            }

            public void Print()
            {
                Console.WriteLine($"Name: {_Name}\nSurname: {_Surname}\nIsExpelled: {_IsExpelled}\nTotalTime: {TotalTime}");
            }
        }
    }
}