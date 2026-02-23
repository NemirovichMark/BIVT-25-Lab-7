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
            public int[] Marks => (int[])_marks.Clone();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = [0, 0, 0, 0, 0];
            }

            public int Result {
                get
                {
                    Array.Sort(_marks);
                    int sum = 0;

                    for (int i = 1; i < _marks.Length - 1; i++)
                    {
                        sum += _marks[i];
                    }

                    if (_distance == 120)
                    {
                        sum += 60;
                    } else if (_distance < 120 && 60 - (120 - _distance) * 2 > 0)
                    {
                        sum += 60 - (120 - _distance) * 2;
                    } else if (_distance > 120)
                    {
                        sum += 60 + (_distance - 120) * 2;
                    }

                    return sum;
                }
            }
            
            public void Jump(int distance, int[] marks)
            {
                if (marks == null) return;

                _distance = distance;
                _marks = (int[])marks.Clone();
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                
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
                Console.WriteLine($"{_surname} | {Result}");
            }
        }
    }
}
