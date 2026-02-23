using System.Collections;

namespace Lab7.Green
{
    public class Task3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _weak;
            private int _count;
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();
            public bool IsExpelled => _weak;
            public double AverageMark
            {
                get
                {
                    if (_marks == null) { return 0; }
                    double sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _marks.Length;
                }
            }
            
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _weak = false;
                _count = 0;
            }
            public void Exam(int mark)
            {
                if (_weak == true) { return; }
                if (_count > 2) { return; }
                if (mark < 2 || mark > 5) { return; }
                if (mark > 2)
                {
                    _marks[_count]=mark;
                    _count++;
                }
                if (mark == 2)
                {
                    _weak = true;
                }
            }
            public static void SortByAverageMark(Student[] array)
            {
                for (int i = 0;i < array.Length-1;i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AverageMark < array[j + 1].AverageMark)
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
                Console.WriteLine($"AverageMark: {AverageMark}");
                Console.WriteLine($"Expelled: {_weak}");
            }
        }
    }
}
