using System;

namespace Lab7.Green
{
    public class Task5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _markCount;

            public string Name => _name;
            public string Surname => _surname;

            public int[] Marks
            {
                get
                {
                    if (_marks == null) return new int[0];
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public double AverageMark
            {
                get
                {
                    if (_marks == null || _markCount == 0) return 0;
                    double sum = 0;
                    for (int i = 0; i < _markCount; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _markCount;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
                _markCount = 0;
            }

            public void Exam(int mark)
            {
                if (_marks != null && _markCount < _marks.Length)
                {
                    if (mark >= 2 && mark <= 5)
                    {
                        _marks[_markCount] = mark;
                        _markCount++;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {AverageMark:F2}");
            }
        }

        public struct Group
        {
            private string _name;
            private Student[] _students;

            public string Name => _name;
            public Student[] Students => _students;

            public double AverageMark
            {
                get
                {
                    if (_students == null || _students.Length == 0) return 0;
                    double sum = 0;
                    foreach (var s in _students)
                    {
                        sum += s.AverageMark;
                    }
                    return sum / _students.Length;
                }
            }

            public Group(string name)
            {
                _name = name;
                _students = new Student[0];
            }

            public void Add(Student student)
            {
                if (_students == null) _students = new Student[0];
                Student[] newArray = new Student[_students.Length + 1];
                Array.Copy(_students, newArray, _students.Length);
                newArray[_students.Length] = student;
                _students = newArray;
            }

            public void Add(Student[] students)
            {
                if (students == null || students.Length == 0) return;
                if (_students == null) _students = new Student[0];

                Student[] newArray = new Student[_students.Length + students.Length];
                Array.Copy(_students, newArray, _students.Length);
                Array.Copy(students, 0, newArray, _students.Length, students.Length);
                _students = newArray;
            }

            public static void SortByAverageMark(Group[] array)
            {
                if (array == null || array.Length < 2) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].AverageMark < array[j + 1].AverageMark)
                        {
                            var temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Group: {_name}, Avg: {AverageMark:F2}");
            }
        }
    }
}
