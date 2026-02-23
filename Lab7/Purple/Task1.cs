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
            private int _ijump;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs => (double[])_coefs.Clone();
            public int[,] Marks => (int[,])_marks.Clone();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] {2.5, 2.5, 2.5, 2.5};
                _marks = new int[4, 7];
                _ijump = 0;
            }

            public double TotalScore
            {
                get
                {
                    double total = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        int[] array = new int[7];

                        for (int j = 0; j < 7; j++)
                        {
                            array[j] = _marks[i, j];
                        }

                        Array.Sort(array);
                        int sum = 0;

                        for (int j = 1; j < 6; j++)
                        {
                            sum += array[j];
                        }

                        total += sum * Coefs[i];
                    }

                    return total;
                }
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null) return;

                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }

            public void Jump(int[] marks)
            {
                if (marks == null) return;

                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[_ijump, i] = marks[i];
                }

                _ijump++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} | {TotalScore}");
            }
        }
    }
}
