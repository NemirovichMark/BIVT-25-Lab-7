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
            }
            public double BestJump
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
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].BestJump < array[j].BestJump)
                        {
                            (array[i], array[j]) = (array[j], array[i]);
                        }
                    }
                }
            }
            public void Print()
            {
                return;
            }
        }
    }
}
    
    }

}
