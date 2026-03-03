namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            //Поля
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;
            //Свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks => _marks.ToArray();
            public int Result
            {
                get
                {
                    int sum = 60, minMark = 100, maxMark = -100;
                    foreach (int mark in _marks)
                    {
                        sum += mark;
                        minMark = Math.Min(minMark, mark);
                        maxMark = Math.Max(maxMark, mark);
                    }
                    sum -= minMark + maxMark;
                    sum += (_distance - 120) * 2;
                    sum = Math.Max(sum, 0);
                    return sum;
                }
            }
            //Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }
            public void Jump(int distance, int[] marks)
            {
                _distance = distance;
                for (int i = 0; i<5; i++)
                {
                    _marks[i] = marks[i];
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j > 0 && array[j].Result > array[j - 1].Result; j--)
                    {
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {this.Result}");
            }
        }
    }
}
