namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks = new int[5];
            private int _result;
            private double _totalScore;
            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return new int[5];
                    int[] copy = new int[5];
                    Array.Copy(_marks, copy, 5);
                    return copy;
                }
            }
            public int Result
            {
                get
                {
                    Array.Sort(_marks);
                    int sum = 0;
                    int d = 60 - (120 - Distance) * 2;
                    if (d < 0) d = 0;
                    sum = Marks[1] + Marks[2] + Marks[3] + d;
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
                if (marks == null || marks.Length != 5) return;
                for (int i = 0; i < 5; i++)
                {
                    _marks[i] = marks[i];
                }
                _distance = distance;
            }
            public static void Sort(Participant[] array)
            {
                // Сортировка пузырьком
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Result < array[j + 1].Result)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Name:{_name}");
                Console.WriteLine($"Surname:{_surname}");
                Console.WriteLine($"Result:{Result}");
            }
        }
    }
}
