namespace Lab7.Green
{
    public class Task5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _count;
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();
            public double AverageMark
            {
                get
                {
                    if (_marks == null) { return 0; }
                    double sum = 0;
                    for (int i = 0; i < _marks.Length-1; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _marks.Length;
                }
            }
            public Student(string name,string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
                _count = 0;
            }
            public void Exam(int mark)
            {
                if (_count > 4) { return; }
                if (mark < 2 || mark > 5) { return; }
                _marks[_count] = mark;
                _count++;
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
            private int _count;
            public string Name => _name;
            public Student[] Students => _students.ToArray();

            public double AverageMark
            {
                get
                {
                    if (_students == null) { return 0; }
                    double sum = 0;
                    for (int i=0;i< _students.Length - 1; i++)
                    {
                        sum+= _students[i].AverageMark;
                    }
                    return sum / _students.Length;
                }
            }
            public Group(string name)
            {
                _name=name;
                _students=new Student[5];
                _count = 0;
            }
            public void Add(Student student)
            {
                if (_count < _students.Length) { _students[_count++] = student; }
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
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
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
