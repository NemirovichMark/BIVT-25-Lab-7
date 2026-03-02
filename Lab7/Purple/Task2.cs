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
                    int[] marks = new int[5];
                    for (int i = 0; i < 5; i++) marks[i] = _marks[i];
                    return marks;
                }
            }
            public double Result
            {
                get
                {
                    double result = 0;
                    int sum = 0;
                    int worstMark = Int32.MaxValue;
                    int bestMark = Int32.MinValue;
                    for (int i = 0; i < 5; i++)
                    {
                        sum += _marks[i];
                        if (_marks[i] < worstMark) worstMark = _marks[i];
                        if (_marks[i] > bestMark) bestMark = _marks[i];
                    }
                    sum = sum - worstMark - bestMark;
                    int extraPoints = 60 + (_distance - 120) * 2;
                    if (extraPoints < 0) extraPoints = 0;
                    result = sum + extraPoints;
                    return result;
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
                if (marks == null) return;
                _distance = distance;
                for (int i = 0; i < 5; i++)
                {
                    _marks[i] = marks[i];
                }
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Result < array[j + 1].Result)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {_marks} {_distance}");
            }
        }
    }
}
