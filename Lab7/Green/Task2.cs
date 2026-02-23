using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Lab7.Green
{
    public class Task2
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _exam;
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();
            public double AverageMark
            {
                get
                {
                    if (_marks == null) { return 0; }
                    double sum = 0;
                    for (int i=0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum/_marks.Length;
                }
            }
            public bool IsExcellent
            {
                get
                {
                    if (_marks == null) { return false; }
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] < 4)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            public Student(string name,string srname)
            {
                _name = name;
                _surname = srname;
                _marks = new int[4];
                _exam = 0;
            }
            public void Exam(int mark)
            {
                if (mark < 2 || mark > 5) { return; }
                if (_exam == 4) { return; }
                _marks[_exam]=mark;
                _exam++;
            }
            public static void SortByAverageMark(Student[] array)
            {
                if (array == null) { return; }
                for (int i = 0;i < array.Length-1;i++)
                {
                    for (int j = 0;i<array.Length-1-i;j++)
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
                Console.WriteLine($"Name:{_name}");
                Console.WriteLine($"Surename: {_surname}");
                Console.WriteLine($"AverageMark: {AverageMark}");
                Console.WriteLine($"Excellent: {IsExcellent}");
            }
        }
    }
}
