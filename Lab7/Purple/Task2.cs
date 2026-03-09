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
            public int[] Marks => _marks.ToArray();

            public double Result
            {
                get
                {
                    if (_marks == null) return 0;

                    int sum = 0;
                    int min = _marks[0];
                    int max = _marks[0];

                    for (int i = 0; i < 5; i++)
                    {
                        sum += _marks[i];
                        if (_marks[i] < min) min = _marks[i];
                        if (_marks[i] > max) max = _marks[i];
                    }

                    sum -= min + max;

                    double distancePoints = 60 + (_distance - 120) * 2;
                    if (distancePoints < 0) distancePoints = 0;

                    return sum + distancePoints;
                }
            }

            public Participant(string name, string surname)
            {
                this._name = name;
                this._surname = surname;
                this._distance = 0;
                this._marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                if (marks.Length != 5) return;

                this._distance = distance;
                for (int i = 0; i < 5; i++)
                    this._marks[i] = marks[i];
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.Result.CompareTo(a.Result));
            }

            public void Print()
            {
                Console.WriteLine($"{_surname} {_name} - {Result:F2}");
            }
        }
    }
}
