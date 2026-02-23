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
                    if (_marks == null) return new int[0];
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int Result
            {
                get
                {
                    if (_marks == null)
                        return 0;
                    int mn = int.MaxValue, mx = int.MinValue;
                    int sum = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        sum += _marks[i];
                        mn = Math.Min(mn, _marks[i]);
                        mx = Math.Max(mx, _marks[i]);
                    }
                    sum -= (mn + mx);
                    sum += (_distance - 120) * 2 + 60;
                    if (sum < 0)
                        sum = 0;
                    return sum;
                }
            }

            //конструктор

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
                for(int i = 0; i < 5; i++)
                {
                    _marks[i] = 0; 
                }
            }

            //методы

            public void Jump(int distance, int[] marks)
            {
                _distance = distance;
                if (marks == null || marks.Length != 5)
                {
                    return;
                }
                for (int i = 0; i < 5; i++)
                {
                    _marks[i] = marks[i];
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1)
                    return;
                int i = 1;
                int j = 2;
                while (i < array.Length)
                {
                    if (i == 0 || array[i].Result <= array[i - 1].Result)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                       (array[i - 1], array[i]) = (array[i], array[i - 1]);
                       i--;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {Result}");
            }
        }
    }
}
