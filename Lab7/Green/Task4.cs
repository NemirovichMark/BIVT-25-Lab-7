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
                
                Array.Sort(array, (a, b) => b.BestJump.CompareTo(a.BestJump));
            }

            
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Лучший прыжок: {BestJump}");
            }

        }
    }
}
