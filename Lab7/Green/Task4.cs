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
            public double[] Jumps => _jumps.ToArray();


            public double BestJump
            {
                get
                {
                    if (_jumps == null) return 0;
                    return _jumps.Max();  
                }
            }
            public void Jump(double result)
            {
                if (_jumps == null) return;
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
                
                if (array == null) return;

                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
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
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Лучший прыжок: {BestJump}");
            }

        }
    }
}
