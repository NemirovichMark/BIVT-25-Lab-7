using System.Xml.Linq;

namespace Lab7.Green
{
    public class Task2
    {
        public struct Student
        {
            private string _surname;
            private string _name;
            private int[] _marks;

            public string Surname => _surname;
            public string Name => _name;
            public int[] Marks => _marks.ToArray();
            public double AverageMark => _marks.Average();
            public bool IsExcellent
            {
                get
                {
                    foreach (int mark in _marks)
                    {
                        if (mark < 4) return false;
                    }
                    return true;
                }
            }

            public Student(string name, string surname)
            {
                _surname = surname;
                _name = name;
                _marks = new int[4];
            }

            public void Exam(int mark)
            {
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }
            public static void SortByAverageMark(Student[] array)
            {
                for(int i =0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].AverageMark < array[j+1].AverageMark)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                return;
            }
        }
    }
}
