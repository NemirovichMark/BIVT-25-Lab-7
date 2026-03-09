using System;
using System.Linq;

namespace Lab7.Green
{
    public class Task4
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private double[] _jumps;

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Jumps => _jumps.ToArray();
            public double BestJump => _jumps.Max();

            // конструктор
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
                Array.Sort(array, (a, b) => b.BestJump.CompareTo(a.BestJump));
            }

            public void Print()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Surname: {Surname}");
                Console.WriteLine($"Best jump: {BestJump}");
            }
        }
    }
}
