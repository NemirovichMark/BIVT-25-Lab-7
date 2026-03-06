namespace Lab7.Green
{
    public class Task5
    {
        public struct Student 
        {
            // поля
            private string _name;
            private string _surname;
            private int[] _marks;

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();
            public double AverageMark => _marks.Average();

            // конструктор
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }
            public void Exam(int mark) // заменяет оценку по предмету новой оценкой
            {
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0) // если место пусто, то заполняем оценкой только это место
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }
            public void Print() // для вывода информации 
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Surname: {Surname}");
                Console.WriteLine($"Marks: {Marks}");
                Console.WriteLine($"AverageMark: {AverageMark}");
            }


        }
        public struct Group
        {
            // поля
            private string _name;
            private Student[] _students;

            // свойства
            public string Name => _name;
            public Student[] Students => _students.ToArray();
            public double AverageMark => _students.Average(x => x.AverageMark);

            // конструктор
            public Group(string name)
            {
                _name = name;
                _students = new Student[0];
            }

            public void Add(Student student) // позволяет добавить одного и несколько
                                             // студентов в группу соответственно.
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
            public static void SortByAverageMark(Group[] array) // для сортировки массива структур
                                                                // в порядке убывания среднего балла в группе.
            {
                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark)); // от b к a
            }

            public void Print()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Average mark: {AverageMark}"); // для вывода информации о необходимых полях структуры
            }
        }

    }
}
