namespace Lab7.Green
{
    public class Task4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _jumps;

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3];
            }

            public string Name => _name;
            public string Surname => _surname;

            public double[] Jumps => (double[])_jumps.Clone();

            public double BestJump
            {
                get
                {
                    double best = 0;
                    foreach (var jump in _jumps)
                        best = Math.Max(best, jump);
                    return best;
                }
            }

            public void Jump(double result)
            {
                for (int i = 0; i < _jumps.Length; i++)
                {
                    if (_jumps[i] == 0)
                    {
                        _jumps[i] = result;
                        return;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.BestJump.CompareTo(a.BestJump));
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name}");
                Console.WriteLine($"Фамилия: {Surname}");
                Console.WriteLine($"Прыжок: {BestJump}");
            }
        }
    }
}