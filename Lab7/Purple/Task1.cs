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
            private int _jumpNumber;

            //свойства

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return new double[0];
                    double[] copy = new double[_coefs.Length];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return new int[0, 0];
                    int rows = _marks.GetLength(0);
                    int cols = _marks.GetLength(1);
                    int[,] copy = new int[rows, cols];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public double TotalScore
            {
                get
                {
                    double res = 0;
                    int mx, mn, podsum;
                    for (int i = 0; i < 4; i++)
                    {
                        podsum = 0;
                        mx = int.MinValue;
                        mn = int.MaxValue;
                        for (int j = 0; j < 7; j++)
                        {
                            podsum += _marks[i, j];
                            mx = Math.Max(_marks[i, j], mx);
                            mn = Math.Min(_marks[i, j], mn);
                        }
                        res += _coefs[i] * (podsum - mn - mx);
                    }
                    return res;
                }   
            }

            //конструктор

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                _marks = new int[4, 7];
                _jumpNumber = 0;
                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = 2.5;
                    for (int j = 0; j < 7; j++)
                    {
                        _marks[i, j] = 0;
                    }
                }
            }

            //методы

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length < 4)
                    return;
                
                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }

            public void Jump(int[] marks)
            {
                if (marks == null || marks.Length < 7 || _jumpNumber > 3)
                {
                    return;
                }
                for (int j = 0; j < 7; j++)
                {
                    _marks[_jumpNumber, j] = marks[j];
                }
                _jumpNumber++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1)
                    return;
                
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
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
                Console.WriteLine($"{_name} {_surname}: {TotalScore}");
            }
        }
    }
}
