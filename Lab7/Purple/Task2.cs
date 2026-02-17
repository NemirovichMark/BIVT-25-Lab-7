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
                    int[] result = new int[5];
                    Array.Copy(_marks, result, 5);
                    return result;
                }
            }

            public int Result
            {
                get
                {
                    int sum = 0;
                    int min = _marks[0];
                    int minIndex = 0;
                    int max = _marks[0];
                    int maxIndex = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (min > _marks[i])
                        {
                            min = _marks[i];
                            minIndex = i;
                        }
                        if (max < _marks[i])
                        {
                            max = _marks[i];
                            maxIndex = i;
                        }
                    }
                    for (int i = 0; i<_marks.Length; i++)
                    {
                        if (i!=minIndex && i!=maxIndex)
                        {
                            sum += _marks[i];
                        }
                    }
                    if (_distance == 120) sum += 60;
                    if (_distance>120)
                    {
                        sum += 60;
                        int dist = _distance;
                        while (dist-120>0)
                        {
                            sum += 2;
                            dist--;
                        }
                    }
                    if (_distance<120)
                    {
                        int dist = _distance;
                        sum += 60;
                        while (sum>0 && 120-dist>0)
                        {
                            sum -= 2;
                            dist++;
                        }
                    }
                    return sum;
                }

            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }
            public void Jump(int distance, int[] marks)
            {
                if (marks == null || marks.Length == 0) return;
                _distance = distance;
                _marks = new int[5];
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i].Result < array[j].Result)
                        {
                            (array[i], array[j]) = (array[j], array[i]);
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
