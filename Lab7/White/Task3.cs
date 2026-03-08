using System.Collections;

namespace Lab7.White
{
    public class Task3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _markCount;
            private int _skipped;

            public string Name => _name;
            public string Surname => _surname;
            public int Skipped => _skipped;

            public double AverageMark
            {
                get
                {
                    if (_markCount == 0)
                        return 0;

                    double sum = 0;
                    for (int i = 0; i < _markCount; i++)
                        sum += _marks[i];

                    return sum / _markCount;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[100];
                _markCount = 0;
                _skipped = 0;
            }

            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    _skipped++;
                }
                else
                {
                    _marks[_markCount] = mark;
                    _markCount++;
                }
            }

            public static void SortBySkipped(Student[] array)
            {
                Array.Sort(array, (a, b) => b.Skipped.CompareTo(a.Skipped));
            }

            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.WriteLine($"Skipped: {_skipped}");

                Console.Write("Marks: ");
                for (int i = 0; i < _markCount; i++)
                    Console.Write(_marks[i] + " ");
                Console.WriteLine();

                Console.WriteLine($"Average mark: {AverageMark}");
                Console.WriteLine("------------------------");
            }
        }
    }
}
