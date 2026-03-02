namespace Lab7.Green
{
    public class Task4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _jumps;
            public string Name => _name;
            public string Surname => _surname;
            public double[] Jumps
            {
                get
                {
                    double[] copy = new double[_jumps.Length];
                    for (int i = 0; i < _jumps.Length; i++)
                    {
                        copy[i] = _jumps[i];
                    }
                    return copy;
                }
            } public double BestJump
            {
                get
                {
                    double best = 0;
                    for (int i = 0; i < _jumps.Length; i++)
                    {
                        if (_jumps[i] > best)
                        {
                            best = _jumps[i];
                        }
                    }
                    return best;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3];
            }
            public void Jump(double result)
            {
                for (int i = 0; i < _jumps.Length; i++)
                {
                    if (_jumps[i] == 0)
                    {
                        _jumps[i] = result;
                        break;
                    }
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
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
                Console.WriteLine("Участник: " + _name + " " + _surname);
                Console.WriteLine("Прыжки: " + _jumps[0] + " " + _jumps[1] + " " + _jumps[2]);
                Console.WriteLine("Лучший прыжок: " + BestJump);
                Console.WriteLine();
            }
        }
    }
}
