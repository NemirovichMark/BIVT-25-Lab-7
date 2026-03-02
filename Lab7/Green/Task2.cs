using System.Collections;

namespace Lab7.Green
{
    public class Task2
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();
            public double AverageMark  => _marks.Average();
            public bool IsExcellent
            {
                get
                {
                    foreach (int mark in _marks)
                    {
                        if (mark < 4)
                            return false;
                    }
                    return true;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[4];
            }

            public void Exam(int mark)
            {
                for (int i = 0; i < _marks.Length; i++)
                {   
                    if(_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    };
                }
            }
            
            public static void SortByAverageMark(Student[] array)
            {
                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark));
            }

            public void Print()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Surname: {Surname}");
                Console.WriteLine($"Marks: {Marks}");
                Console.WriteLine($"Average mark: {AverageMark}");
                Console.WriteLine($"Is excellent: {IsExcellent}");
            }
        }
    }
}
