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

            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }
            public double AverageMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
                    {
                        return 0;
                    }
                    
                    double sr = 0;
                    
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sr += _marks[i];
                    }
                    sr /= _marks.Length;
                    
                    return sr;
                }
            }
            public int Skipped
            {
                get
                {
                    return _skipped;
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
                }
                else{
                    Array.Resize(ref _marks, _marks.Length + 1);
                    _marks[^1] = mark;
                }
            }

            public static void SortBySkipped(Student[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j].Skipped < array[j + 1].Skipped)
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
