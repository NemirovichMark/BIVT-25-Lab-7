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
                    if (_marks == null) return null;
                    int[] marks = new int[_marks.Length];
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        marks[i] = _marks[i];
                    }

                    return marks;
                }
            }
            public int Result
            {
                get
                {
                    int score = 0;
                    int imax = 0;
                    for (int i = 1; i < _marks.Length; i++)
                    {
                        if (_marks[i] > _marks[imax])
                        {
                            imax = i;
                        }
                    }

                    int imin = 0;
                    for (int i = 1; i < _marks.Length; i++)
                    {
                        if (_marks[i] < _marks[imin])
                        {
                            imin = i;
                        }
                    }

                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (i == imax || i == imin) continue;
                        score += _marks[i];
                    }

                    int b = 60;
                    if ((_distance - 120) > 0)
                    {
                        b += (_distance - 120) * 2;
                    }
                    else
                    {
                        b -= (120 - _distance) * 2;
                    }

                    if (b < 0) b = 0;
                    score += b;
                    return score;
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
                _distance = distance;
                if (marks == null || marks.Length != _marks.Length) return;
                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }
            }
            
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                int i = 0;
                while (i < array.Length)
                {
                    if (i == 0 || array[i].Result <= array[i - 1].Result)
                    {
                        i++;
                    }
                    else
                    {
                        Participant tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                        i--;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Name: {Name},\nSurname: {Surname},\nResult: {Result}");
            }
        }
    }
}
