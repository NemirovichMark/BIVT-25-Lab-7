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

            public int[] Marks
            {
                get
                {
                    int[] m = new int[_marks.Length];
                    Array.Copy(_marks, m, _marks.Length);
                    return m;
                }
            }

            public double AverageMark
            {
                get
                {
                    int sum = 0;
                    foreach (int m in _marks)
                        sum += m;

                    return sum / 4.0;
                }
            }

            public bool IsExcellent
            {
                get
                {
                    foreach (int m in _marks)
                        if (m < 4) return false;

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
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        return;
                    }
                }
            }

            public static void SortByAverageMark(Student[] arr)
            {
                Array.Sort(arr, (a, b) => b.AverageMark.CompareTo(a.AverageMark));
            }

            public void Print()
            {

                Console.WriteLine($"Имя: {Name}");
                Console.WriteLine($"Фамилия: {Surname}");
                Console.WriteLine($"Средняя: {AverageMark}");
                Console.WriteLine($"Все ли выше 4: {IsExcellent}");

            }
        }
    }
}