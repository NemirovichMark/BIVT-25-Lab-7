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
                for (int i = 0; i < 5; i++)
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
                Console.WriteLine("Фамилия:" + Surname);
                Console.WriteLine("Имя:" + Name);
                Console.WriteLine("Средняя оценка:" + AverageMark);
            }
        }

        public struct Group
        {
            private string _name;
            private Student[] _student;

            public string Name => _name;
            public Student[] Students => _student.ToArray();

            public double AverageMark
            {
                get
                {
                    double sum = 0;

                    for (int i = 0; i < Students.Length; i++)
                    {
                        sum += _student[i].AverageMark;
                    }

                    if (_student.Length == 0)
                    {
                        return 0;
                    }

                    return sum / Students.Length;
                }
            }

            public Group(string goup)
            {
                _name = goup;
                _student = new Student[0];
            }

            public void Add(Student student)
            {
                Array.Resize(ref _student, _student.Length + 1);
                _student[_student.Length - 1] = student;
            }
            public void Add(Student[] students)
            {
                int oldLength = _student.Length;
                Array.Resize(ref _student, _student.Length + students.Length);
                for (int i = 0; i < _student.Length; i++)
                {
                    _student[oldLength + i] = students[i];
                }
            }

            public static void SortByAverageMark(Group[] array)
            {
                int n = array.Length;

                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
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
                Console.WriteLine("Имя:" + Name);
                Console.WriteLine("Средняя оценка:" + AverageMark);
            }
        }
    }
}