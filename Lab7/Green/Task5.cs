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
                    var copy = new int[_markCount];
                    Array.Copy(_marks, copy, _markCount);
                    return copy;
                }
            }

            public double AverageMark
            {
                get
                {
                    if (_markCount == 0) return 0;
                    double sum = 0;
                    for (int i = 0; i < _markCount; i++)
                        sum += _marks[i];
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
                if (_markCount < _marks.Length && mark >= 2 && mark <= 5)
                {
                    _marks[_markCount++] = mark;
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}");
                Console.WriteLine($"Фамилия: {_surname}");
                Console.WriteLine($"Среднее: {AverageMark:F2}");
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
                    if (_students.Length == 0) return 0;
                    double sum = 0;
                    foreach (var s in _students)
                        sum += s.AverageMark;
                    return sum / _students.Length;
                }
            }

            public Group(string name)
            {
                _name = name;
                _students = Array.Empty<Student>();
            }

            public void Add(Student student)
            {
                var newArray = new Student[_students.Length + 1];
                Array.Copy(_students, newArray, _students.Length);
                newArray[^1] = student;
                _students = newArray;
            }

            public void Add(Student[] students)
            {
                if (students == null || students.Length == 0) return;
                var newArray = new Student[_students.Length + students.Length];
                Array.Copy(_students, newArray, _students.Length);
                Array.Copy(students, 0, newArray, _students.Length, students.Length);
                _students = newArray;
            }

            public static void SortByAverageMark(Group[] groups)
            {
                Array.Sort(groups, (a, b) => b.AverageMark.CompareTo(a.AverageMark));
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {_name}");
                Console.WriteLine($"Среднее: {AverageMark:F2}");
            }
        }
    }
}