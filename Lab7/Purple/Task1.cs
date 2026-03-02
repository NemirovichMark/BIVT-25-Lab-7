namespace Lab7.Purple
{
    public class Task1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpCount; // Счётчик прыжков

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    double[] copy = new double[_coefs.Length];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }

            public int[,] Marks
            {
                get
                {
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public double TotalScore
            {
                get
                {
                    double total = 0;

                    for (int jump = 0; jump < 4; jump++)
                    {
                        // берём оценки прыжка
                        int[] jumpMarks = new int[7];

                        for (int j = 0; j < 7; j++)
                            jumpMarks[j] = _marks[jump, j];

                        // Сортируем чтобы убрать min max
                        Array.Sort(jumpMarks);

                        int sum = 0;

                        for (int i = 1; i < 6; i++)
                            sum += jumpMarks[i];

                        // Умножаем на коэффициент
                        total += sum * _coefs[jump];
                    }

                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;

                _coefs = new double[4];
                _marks = new int[4, 7];

                // Инициализация коэф-тов по дефолту
                for (int i = 0; i < _coefs.Length; i++)
                    _coefs[i] = 2.5;

                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int i2 = 0; i2 < _marks.GetLength(1); i2++)
                    {
                        _marks[i, i2] = 0;
                    }
                }

                _jumpCount = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                for (int i = 0; i < _coefs.Length; i++)
                    _coefs[i] = coefs[i];
            }

            public void Jump(int[] marks)
            {
                int line = _jumpCount++; // строка в матрице

                for (int i2 = 0; i2 < marks.Length; i2++)
                {
                    _marks[line, i2] = marks[i2];
                }
            }

            public static void Sort(Participant[] array)
            {
                Participant[] sorted = array.OrderByDescending(p => p.TotalScore).ToArray();

                // Явно переприсваиваем каждый элемент (важно для структур!)
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = sorted[i];
                }
            }

            // Вывод информации
            public void Print()
            {
                // выводим инфу
                Console.WriteLine($"{Surname} {Name}: {TotalScore}");
            }

        }
    }
}
