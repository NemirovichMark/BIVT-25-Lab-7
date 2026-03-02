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

                    int sum = 0;
                    int count = 0;

                    foreach (int m in _marks)
                    {
                        if (m != 0)
                        {
                            sum += m;
                            count++;
                        }
                    }
                    if (count == 0) return 0;

                    return (double)sum / count;
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
                    foreach (var s in _students)
                    {
                        sum += s.AverageMark;
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
                Array.Resize(ref _students, _students.Length + students.Length);
                for (int i = 0; i < students.Length; i++)
                {
                    _students[_students.Length - students.Length + i] = students[i];
                }
            }
            public static void SortByAverageMark(Group[] array)
            {
                
                if (array == null) return;

                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    
                    for (int j = 0; j < n - i - 1; j++)
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
                Console.WriteLine($"Группа: {_name}, Средний балл: {AverageMark}, Студентов: {_students?.Length ?? 0}");
            }
        }

    }
}
