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
            private int _jump_I;
            
            // Свойства
            public string Name => _name;
            public string Surname => _surname;

            public int[,] Marks
            {
                get
                {
                    int rows = _marks.GetLength(0);
                    int cols = _marks.GetLength(1);
                    int[,] copy = new int[rows, cols];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            copy[i, j] += _marks[i, j];
                        }
                    }

                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            total += _marks[i, j];
                        }
                    }

                    return total;
                }
            }
            
            // Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _jump_I = 0;
            }

            public void Jump(int[] result)
            {
                if (_jump_I >= 2) return;
                
                for (int j = 0; j < result.Length; j++)
                {
                    _marks[_jump_I, j] = result[j];
                }

                _jump_I++;
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
                Console.WriteLine($"{_name} {_surname}: {TotalScore}");
            }
        }
    }
}
