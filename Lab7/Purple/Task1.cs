using System;

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
            private int _jumpCount;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs => _coefs.ToArray();
            public int[,] Marks => (int[,])_marks.Clone();

            public double TotalScore
            {
                get
                {
                    double total = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        int min = int.MaxValue;
                        int max = int.MinValue;
                        double sum = 0;

                        for (int j = 0; j < 7; j++)
                        {
                            int val = _marks[i, j];
                            sum += val;
                            if (val < min) min = val;
                            if (val > max) max = val;
                        }

                        total += (sum - min - max) * _coefs[i];
                    }
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _jumpCount = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                for (int i = 0; i < 4; i++) _coefs[i] = coefs[i];
            }

            public void Jump(int[] marks)
            {
                for (int i = 0; i < 7; i++)
                {
                    _marks[_jumpCount, i] = marks[i];
                }
                _jumpCount++;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    Participant key = array[i];
                    int j = i - 1;

                    while (j >= 0 && array[j].TotalScore < key.TotalScore)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = key;
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {TotalScore:F2}");
            }
        }
    }
}
