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
            private int _skipped;
            public string Name => _name;
            public string Surname => _surname;
            public int Skipped => _skipped;

            public double AverageMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return default(double);
                    double ans = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        ans += _marks[i];
                    }

                    return ans / _marks.Length;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[0];
                _skipped = 0;
            }

            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    _skipped++;
                    return;
                }
                Array.Resize(ref _marks, _marks.Length + 1);
                _marks[_marks.Length - 1] = mark;
            }

            public static void SortBySkipped(Student[] array)
            {
                if (array == null) return;
                int i = 0;
                while (i < array.Length)
                {
                    if (i == 0 || array[i]._skipped <= array[i - 1]._skipped)
                    {
                        i++;
                    }
                    else
                    {
                        Student tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                        i--;
                    }
                }
            }
            public void Print() { }
        }
    }
}