

namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    int n = _marks.Length;
                    if (_marks == null || n == 0) return null;
                    int[] marks_copy = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        marks_copy[i] = _marks[i];
                    }
                    return marks_copy;
                }
            }
            public int Result
            {
                get
                {
                    int n = _marks.Length;
                    int total_sum = 0;
                    int mx = _marks[0];
                    int mn = _marks[0];
                    for (int i = 0; i < n; i++)
                    {
                        if (_marks[i] < mn)
                            mn = _marks[i];
                        if (_marks[i] > mx)
                            mx = _marks[i];
                        total_sum += _marks[i];

                    }
                    total_sum -= (mx + mn);
                    if (_distance > 120)
                        total_sum += (_distance - 120) * 2 + 60;
                    if (_distance < 120)
                    {
                        int dif  = Math.Max(0, 60 - (120 - _distance) * 2);
                        total_sum += dif;
                    }
                    return total_sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
                _distance = 0;
            }
            public void Jump(int distance, int[] marks)
            {
                if (marks == null || marks.Length != 5) return;
                _distance = distance;
                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }
            }

            public static void Sort(Participant[] array)
            {
                int n = array.Length;
                if (array == null || n < 1) return;
                for (int i = 0; i < n-1; i++)
                {
                    for (int j = 0; j<n-i-1; j++)
                    {
                        if (array[j].Result < array[j+1].Result)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"name: {_name}, surname: {_surname}, Result: {Result}");
            }
        }
    }
}
