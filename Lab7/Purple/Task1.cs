namespace Lab7.Purple
{
    public class Task1
    {
        public struct Participant

        {
            //поля
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jump_cnt;



            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    double[] coefs_copy = new double[_coefs.Length];
                    Array.Copy(_coefs, coefs_copy, _coefs.Length);
                    return coefs_copy;
                }
            }
            //для защиты приватных полей от изменений извне
            //(ссылочные типы не обеспечивают инкапсуляцию)
            public int[,] Marks
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return null;

                    int[,] marks_copy = new int[4, 7];
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            marks_copy[i, j] = _marks[i, j];
                        }
                    }

                    return marks_copy;
                }
            }
            public double TotalScore
            {
                get
                {
                    int n = _marks.GetLength(0);
                    int m = _marks.GetLength(1);

                    double sum_gen = 0;
                    for (int i = 0; i < n; i++)
                    {
                        double sum_jump = 0;
                        int row_max = _marks[i, 0];
                        int row_min = _marks[i, 0];
                        for (int j = 0; j < m; j++)
                        {
                            if (_marks[i, j] > row_max)
                            {
                                row_max = _marks[i, j];
                            }
                            if (_marks[i, j] < row_min)
                            {
                                row_min = _marks[i, j];
                            }

                        }


                        for (int j = 0; j < m; j++)
                        {
                            sum_jump += _marks[i, j];

                        }
                        sum_jump -= (row_max + row_min);
                        sum_gen += sum_jump * _coefs[i];
                    }
                    return sum_gen;
                }
            }
            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _jump_cnt = 0;
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        _marks[i, j] = 0;
                    }
                }


            }
            public void SetCriterias(double[] coefs)
            {
                if (coefs.Length == 0 || coefs.Length != _coefs.Length) return;
                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }
            public void Jump(int[] marks)
            {
                if (marks.Length != _marks.GetLength(1) || marks == null) return;
                if (_jump_cnt < marks.Length)
                {
                    for (int j = 0; j < marks.Length; j++)
                    {
                        _marks[_jump_cnt, j] = marks[j];
                    }


                }
                _jump_cnt += 1;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length < 1) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"name: {_name}, surname: {_surname}, total_score: {TotalScore}");
            }
        }
    }
}
