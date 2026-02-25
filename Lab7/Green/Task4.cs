namespace Lab7.Green
{
    public class Task4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _tries;
            private int _count;
            public string Name => _name;
            public string Surname => _surname;
            public double[] Jumps => _tries.ToArray();
            public double BestJump
            {
                get
                {
                    double best = double.MinValue;
                    for (int i=0;i<_tries.Length;i++)
                    {
                        if (_tries[i] > best)
                        {
                            best = _tries[i];
                        }
                    }
                    return best;
                }
            }
            public Participant(string name,string surname)
            {
                _name = name;
                _surname = surname;
                _tries = new double[3];
                _count = 0;
            }
            public void Jump(double result)
            {
                if (_count > 2) { return; }
                _tries[_count]=result;
                _count++;
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length-1; i++)
                {
                    for (int j=0;j<array.Length-1-i;j++)
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
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.WriteLine($"BestJump: {BestJump}");
            }
        }
    }
}
