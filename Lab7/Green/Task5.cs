namespace Lab7.Green
{
    public class Task5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5]; 
            }

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();

            public double AverageMark
            {
                get
                {
                    if (_marks == null) return 0;
                    return _marks.Where(m => m > 0).DefaultIfEmpty(0).Average();
                }
            }

            public void Exam(int mark)
            {
                if (_marks == null) return;

                
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Средний балл: {AverageMark}");
            }
        }
        public struct Group
        {
            private string _name;
            private Student[] _students;

            public Group(string name)
            {
                _name = name;
                _students = new Student[0];  
            }

            public string Name => _name;

            
            public Student[] Students => _students.ToArray();

            public double AverageMark
            {
                get
                {
                    if (_students == null || _students.Length == 0) return 0;

                    
                    double sum = 0;
                    foreach (var student in _students)
                    {
                        sum += student.AverageMark;
                    }
                    return sum / _students.Length;
                }
            }
            public void Add(Student student)
            {
                if (_students == null) _students = new Student[0];

                Array.Resize(ref _students, _students.Length + 1);
                _students[_students.Length - 1] = student;
            }
            public void Add(Student[] students)
            {
                if (students == null) return;
                if (_students == null) _students = new Student[0];

                int oldLength = _students.Length;
                Array.Resize(ref _students, oldLength + students.Length);

                for (int i = 0; i < students.Length; i++)
                {
                    _students[oldLength + i] = students[i];
                }
            }
            public static void SortByAverageMark(Group[] array)
            {
                if (array == null) return;
                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark));
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {_name}, Средний балл: {AverageMark}, Студентов: {_students?.Length ?? 0}");
            }
        }

    }
}
