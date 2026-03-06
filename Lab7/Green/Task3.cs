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
            private bool _isExpelled;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _isExpelled = false;
            }

            public string Name => _name;
            public string Surname => _surname;
            public bool IsExpelled => _isExpelled;

            public int[] Marks
            {
                get
                {
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public double AverageMark
            {
                get
                {
                    int sum = 0;
                    int count = 0;

                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] > 0)
                        {
                            sum += _marks[i];
                            count++;
                        }
                    }

                    if (count == 0) return 0;
                    return (double)sum / count;
                }
            }

            public void Exam(int mark)
            {
                if (_isExpelled) return;

                int index = Array.FindIndex(_marks, m => m == 0);
                if (index == -1) return; 

                _marks[index] = mark;

                if (mark == 2)
                    _isExpelled = true;
            }

            public static void SortByAverageMark(Student[] array)
            {
                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark));
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name}");
                Console.WriteLine($"Фамилия: {Surname}");
                Console.WriteLine($"Средняя: {AverageMark}");
                Console.WriteLine($"Отчислен: {IsExpelled}");
            }
        }
    }
}