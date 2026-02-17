using System.Security.Cryptography.X509Certificates;

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

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    double[] result = new double[4];
                    for (int i = 0; i<result.Length; i++)
                    {
                        result[i] = _coefs[i];
                    }
                    return result;
                }
            }
            public int[,] Marks
            {
                get
                {
                    int[,] result = new int[4, 7];
                    for (int i = 0; i < result.GetLength(0); i++)
                    {
                        for (int j = 0; j < result.GetLength(1); j++)
                        {
                            result[i,j] = _marks[i,j];
                        }
                    }
                    return result;
                }
            }

            public double TotalScore
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    double sumTotal = 0;
                    for (int k = 0; k < _coefs.Length; k++)
                    {
                        int sum = 0;
                        int min = _marks[k, 0];
                        int minIndex = 0;
                        int max = _marks[k, 0];
                        int maxIndex = 0;
                        // Находим минимальную и максимальную оценку
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            if (_marks[k, j] < min)
                            {
                                min = _marks[k, j];
                                minIndex = j;
                            }
                            if (_marks[k, j] > max)
                            {
                                max = _marks[k, j];
                                maxIndex = j;
                            }
                        }
                        // Находим сумму оценок без минимальной и максимальной
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            if (j != minIndex && j != maxIndex)
                            {
                                sum += _marks[k, j];
                            }
                        }
                        sumTotal += sum * _coefs[k]; // Оценка за все прыжки спортсмена
                    }
                    return sumTotal;
                }
                
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0}
                };
            }
            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length == 0) return;
                _coefs = new double[coefs.Length];
                for (int i = 0; i < coefs.Length; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }
            int count = 0;
            public void Jump(int[] marks)
            {
                if (marks == null || marks.Length == 0) return;
                for (int j = 0; j < marks.Length; j++)
                {
                    _marks[count, j] = marks[j];
                }
                count++;
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i<array.Length; i++)
                {
                    for (int j = i; j < array.Length; j++) {
                        if (array[i].TotalScore < array[j].TotalScore)
                        {
                            (array[i], array[j]) = (array[j], array[i]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {_marks} {_coefs}");
            }
        }
    }
}
