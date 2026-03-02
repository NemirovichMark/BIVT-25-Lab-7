namespace Lab7.Green
{
    public class Task5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();
            public double AverageMark => _marks.Average();

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
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

            public void Print()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Surname: {Surname}");
                Console.WriteLine($"Marks: {Marks}");
                Console.WriteLine($"Average mark: {AverageMark}");
            }
        }

        public struct Group
        {
            private string _name;
            private Student[] _students;

            public string Name => _name;
            public Student[] Students => _students.ToArray();
            public double AverageMark => _students.Average(x => x.AverageMark);

            public Group(string name)
            {
                _name = name;
                _students = new Student[0];
            }

            public void Add(Student student)
            {
                Array.Resize(ref _students, _students.Length + 1);
                _students[_students.Length - 1] = student;
            }

            public void Add(Student[] students)
            {
                int old = _students.Length;
                Array.Resize(ref _students, old + students.Length);
                
                for (int i = 0; i < students.Length; i++)
                    _students[old + i] = students[i];
            }
            public static void SortByAverageMark(Group[] array)
            {
                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark));
            }

            public void Print()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Average mark: {AverageMark}");
            }
        }
    }
}
