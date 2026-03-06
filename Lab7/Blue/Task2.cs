namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            // Поля
            private string _name;
            private string _surname;
            private int[,] _marks;
            // Свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    int[,] copy = new int[2, 5];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            copy[i, j] = _marks[i, j];
                        }
                    }
                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }
            // Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                for (int i = 0;i<2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        _marks[i, j] = 0;
                    }
                }
            }
            // Метод
            public void Jump(int[] result)
            {
                int k1 = 0;
                for (int i = 0; i<5; i++)
                {
                    if (_marks[0,i] != 0)
                    {
                        k1++;
                        break;
                    }
                }
                if (k1 == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _marks[0, i] = result[i];
                    }
                    return;// выходим из метода
                }
                int k2 = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (_marks[1, i] != 0)
                    {
                        k2++;
                        break;
                    }
                }
                if (k2 == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _marks[1, i] = result[i];
                    }
                    return;
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length; j++)
                    {
                        if (array[j - 1].TotalScore < array[j].TotalScore)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }
                }
            }
            public void Print()
            {
                return;
            }
        }
    }
}
