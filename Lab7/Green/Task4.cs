namespace Lab7.Green
{
    public class Task4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;

            // 3 прыжка
            private double[] _jumps;

            public Participant(string name, string surname)
            {
                _name = name == null ? "" : name;
                _surname = surname == null ? "" : surname;

                _jumps = new double[3];
            }

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }

            public double[] Jumps
            {
                get
                {
                    // Копия массива что бы не могли изменить
                    double[] copy = new double[_jumps.Length];
                    for (int i = 0; i < _jumps.Length; i++)
                        copy[i] = _jumps[i];
                    return copy;
                }
            }

            public double BestJump
            {
                get
                {
                    double best = 0;
                    for (int i = 0; i < _jumps.Length; i++)
                        if (_jumps[i] > best) best = _jumps[i];
                    return best;
                }
            }

            public void Jump(double result)
            {
                // Записываю в первую свободную ячейку
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
                // Пузырьковая сортировка
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
                Console.WriteLine($"{Name} {Surname} {BestJump}");
            }
        }
    }
}
