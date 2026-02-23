using System.Runtime.InteropServices;

namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int _jumpNow;
            public  Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2,5];
            }

            public void Print()
            {
                Console.WriteLine($"({_name} {_surname} => {_marks})");
            } 

            public string Name { get  => _name;}
            public string Surname { get => _surname; }
            public int[,] Marks => (int[,])_marks.Clone();

            public readonly int TotalScore => Sum(); 

            private int Sum()
            {
                int sum = 0;
                for (int i = 0; i < _marks.GetLength(0); i++)
                for (int j = 0; j < _marks.GetLength(1); j++)
                    sum += _marks[i,j];
                return sum;
            }

            public void Jump(int[] result)
            {
                if (_jumpNow < 2)
                {
                    for (int i = 0; i < _marks.GetLength(1); i++)
                    {
                        _marks[_jumpNow,i] = result[i];
                    }
                }
                _jumpNow++;
            }

            public static void Sort(Participant[] array)
            {
                
                Array.Sort(array, (l, r) => r.TotalScore.CompareTo(l.TotalScore));
            }



        }
    }
}
