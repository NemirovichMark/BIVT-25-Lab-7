using System.Runtime.InteropServices.Marshalling;

namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    if(_marks == null) return new int [0];
                    return (from i in _marks select i).ToArray();
                }
            }
            public int Result
            {
                get
                {
                    if (_marks == null) return 0;
                    int ans;
                    ans = (_distance >= 120 ? 60 + (_distance - 120) * 2 : 60+(_distance - 120) * 2);
                    int minMark = 21, maxMark = 0;
                    for(int i = 0; i < 5; i++)
                    {
                        minMark = Math.Min(_marks[i], minMark);
                        maxMark = Math.Max(_marks[i], maxMark);
                        ans += _marks[i];
                    }
                    return Math.Max(ans - minMark - maxMark, 0);
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }

            public void Jump(int dist, int[] marks)
            {
                if (_marks == null) return;
                _distance = dist;
                for(int i = 0; i < 5; i++) _marks[i] = marks[i];
            }

            public static void Sort(Participant[] arr)
            {
                var copy = (from i in arr
                           orderby -i.Result
                           select i).ToArray();
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = copy[i];
                }
                //arr[0].Print(arr);
            }
            public void Print()
            {
                Console.Write($"{_name, 10} {_surname, 10} - {Result}");
                return;
            }
            
        }
    }
}