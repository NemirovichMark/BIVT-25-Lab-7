namespace Lab7.Green
{
    public class Task4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _jumps;
            private int ind;


            public string Name => _name;
            public string Surname => _surname;
            public double[] Jumps
            {
                get
                {
                    double[] copy = new double[_jumps.Length];
                    for (int i = 0; i < copy.Length; i++)
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
                    double max1 = double.MinValue;
                    for (int i = 0;i < _jumps.Length;i++)
                    {
                        if (max1 < _jumps[i])
                            max1 = _jumps[i];
                    }
                    return max1;
                }
            }


            public Participant(string iname,string isurname)
            {
                _name = iname;
                _surname = isurname;
                _jumps = new double[3];
                ind = 0;
            }

            public void Jump(double result)
            {
                if (ind < 3)
                    _jumps[ind++] = result;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    int j = i;
                    while (j>0 && array[j].BestJump > array[j - 1].BestJump)
                    {
                        (array[j], array[j-1]) = (array[j-1], array[j]);
                        j--;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(string.Join(" ",_jumps));
                Console.WriteLine(BestJump);
            }
        }
    }
}
