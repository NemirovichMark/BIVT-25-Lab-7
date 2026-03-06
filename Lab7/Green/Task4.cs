namespace Lab7.Green
{
    public class Task4

    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private double [] _jumps;

            //  свойства
            public string Name => _name;
            public string Surname => _surname;
            public double [] Jumps => _jumps.ToArray();
            public double BestJump => _jumps.Max();
            
            // конструктор
            public Participant(string name,string surname)
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3]; // массив из трех попыток
            }
            public void Jump(double result) // заполняет результат очередного
                                            // прыжка в массиве данными.
            {
                for (int i = 0; i < _jumps.Length; i++)
                {
                    if (_jumps[i] == 0) // если прыжка не было, то заполняем место
                    {
                        _jumps[i] = result; // заполняем элемент массива значением прыжка
                        break;
                    }
                }
            }
            public static void Sort(Participant[] array) // по убыванию лучшего результата спортсмена
            {
                Array.Sort(array, (a, b) => b.BestJump.CompareTo(a.BestJump)); // от большего к меньшему
            }
            public void Print()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Surname: {Surname}");
                Console.WriteLine($"Jumps: {Jumps}");
                Console.WriteLine($"Best jump: {BestJump}");
            }

        }
    }
}
