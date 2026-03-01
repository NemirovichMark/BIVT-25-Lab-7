namespace Lab7.Purple
{
    public class Task1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs = new double[4];
            private int[,] _marks = new int[4, 7];
            private double _totalScore;
            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return new double[4];
                    double[] copy = new double[_coefs.Length];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return new int[4, 7];
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public double TotalScore
            {

                get
                {
                    double[] ttScore = new double[4];
                    int[,] marks = new int[4, 7];
                    int[] marks2 = new int[7];
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            marks2[j] = Marks[i, j];
                        }
                        Array.Sort(marks2);
                        for (int j = 0; j < 7; j++)
                        {
                            marks[i, j] = marks2[j];
                        }

                    }

                    for (int i = 0; i < 4; i++)
                    {
                        ttScore[i] = (marks[i, 1] + marks[i, 2] + marks[i, 3] + marks[i, 4] + marks[i, 5]) * Coefs[i];
                    }
                    double sum = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        sum += ttScore[i];
                    }
                    return sum;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = [2.5, 2.5, 2.5, 2.5];
                _marks = new int[4, 7];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        _marks[i, j] = 0;
                    }
                }

                _totalScore = TotalScore;
            }
            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length != 4) return;
                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }
            int currentJump = 0;
            public void Jump(int[] marks)
            {
                if (marks == null || marks.Length != 7 || currentJump >= 4) return;

                for (int j = 0; j < 7; j++)
                {
                    _marks[currentJump, j] = marks[j];
                }
                currentJump++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                // Сортировка пузырьком
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
                Console.WriteLine($"Name:{_name}");
                Console.WriteLine($"Surname:{_surname}");
                Console.WriteLine($"TotalScore:{TotalScore}");
            }
        }
    }
}
