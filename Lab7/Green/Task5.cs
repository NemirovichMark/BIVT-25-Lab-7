using System.Xml.Linq;

namespace Lab7.Green
{
    public class Task5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _markCounter;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();

            public double AverageMark
            {
                get
                {
                    double sum = 0;
                    for(int i = 0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    sum /= _marks.Length;
                    return sum;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            public void Exam(int mark)
            {
                if (mark < 2 || mark > 5) return;
                if (_markCounter < 5)
                {
                    _marks[_markCounter++] = mark;
                }
            }
            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.WriteLine($"AverageMark: {AverageMark}");
            }
        }

        public struct Group
        {
            private string _name;
            private Student[] _students;
            private int _studentCount;
            public string Name => _name;

            public Student[] Students => _students.ToArray();

            public double AverageMark
            {
                get
                {
                    if (_studentCount == 0) return 0;
                    double sum = 0;
                    for (int i = 0; i < _students.Length; i++)
                    {
                        sum += _students[i].AverageMark;
                    }
                    sum /= _students.Length;
                    return sum;
                }
            }
            public Group(string Name)
            {
                _name = Name;
                _students = new Student[10];
                _studentCount = 0;
            }

            public void Add(Student student)
            {
                if (_studentCount < _students.Length)
                {
                    _students[_studentCount++] = student;
                }
            }

            public void Add(Student[] students)
            {
                foreach (var student in students) { Add(student); }
            }
            public static void SortByAverageMark(Group[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AverageMark < array[j + 1].AverageMark)
                        {
                            Group temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($" Group: {_name}");
                Console.WriteLine($"Average mark: {AverageMark}");
            }
        }
    }
}
