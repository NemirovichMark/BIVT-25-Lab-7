namespace Lab7.Green
{
    public class Task5
    {
                public struct Student
        {
            // Поля
            private string _name;
            private string _surname;
            private int[] _marks;

            // Свойства

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();

            public double AverageMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) 
                        return 0;
                    double sum = 0;
                    int count = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] >= 2 && _marks[i] <= 5)
                        {
                            sum += _marks[i];
                            count++;
                        }
                    }
                    if (count == 0)
                        return 0;
                    return sum / _marks.Length;
                }
            }

            // Конструктор
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            // Метод
            public void Exam(int mark)
            {
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        if (mark >= 2 && mark <= 5)
                        {
                            _marks[i] = mark;
                        }
                        break;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(Name);
                Console.WriteLine(Surname);
                Console.Write("Оценки: ");
                foreach (int m in _marks)
                    Console.Write(m + " ");
                Console.WriteLine(AverageMark);
                Console.WriteLine();
            }
        }
        public struct Group
        {
            //Поля
            private string _name;
            private Student[] _students;

            // Свойства
            public string Name => _name;
            public Student[] Students => Students.ToArray();


            public double AverageMark
            {
                get
                {
                    if (_students == null || _students.Length == 0) 
                        return 0;
                    double totalSum = 0;
                    int totalCount = 0;
                    for (int i = 0; i < _students.Length; i++)
                    {
                        totalSum += _students[i].AverageMark;
                        totalCount += 1;
                    }
                    return totalSum / totalCount;
                }
            }

            // Конструктор
            public Group(string name)
            {
                _name = name;
                _students = new Student[0];
            }

            // Метод
            public void Add(Student student)
            {
                Student[] newArray = new Student[_students.Length + 1];
                for (int i = 0; i < _students.Length; i++)
                {
                    newArray[i] = _students[i];
                }
                newArray[newArray.Length - 1] = student;
                _students = newArray;
            }
            public void Add(Student[] students)
            {
                if (students == null || students.Length == 0) 
                    return;
                Student[] newArray = new Student[_students.Length + students.Length];
                for (int i = 0; i < _students.Length; i++)
                {
                    newArray[i] = _students[i];
                }
                for (int i = 0; i < students.Length; i++)
                {
                    newArray[_students.Length + i] = students[i];
                }
                _students = newArray;
            }
            public static void SortByAverageMark(Group[] array)
            {
                if (array == null || array.Length == 0) 
                    return;
                for (int i = 0; i < array.Length; i++)
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
                Console.WriteLine(Name);
                Console.WriteLine(AverageMark);
                Console.WriteLine();
            }
        }
    }
}
