namespace Lab7.Green
{
    public class Task4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _jumps;
            private int _countJump;

            public string Name
            {
                get
                {
                    if (_name == null) return "";
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    if (_surname == null) return "";
                    return _surname;
                }
            }

            public double[] Jumps
            {
                get
                {
                    if (_jumps == null) return new double[0];
                    double[] copy = new double[_jumps.Length];
                    for (int i = 0; i < _jumps.Length; i++)
                    {
                        copy[i] = _jumps[i];
                    }
                    return copy;
                }
            }

            public double BestJump
            {
                get
                {
                    if (_jumps == null || _jumps.Length == 0) return 0;
                    double best = _jumps[0];
                    for (int i = 1; i < _jumps.Length; i++)
                    {
                        if (_jumps[i] > best) best = _jumps[i];
                    }
                    return best;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3];
                _countJump = 0;
            }

            public void Jump(double result)
            {
                if (_countJump >= 3) return;
                _jumps[_countJump] = result;
                _countJump++;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                string jumpsStr = string.Join(", ", Jumps);
                Console.WriteLine($"Спортсмен: {Name} {Surname}, попытки: {jumpsStr}, лучший: {BestJump:F2}");
            }
        }
    }
}
