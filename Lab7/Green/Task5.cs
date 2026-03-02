namespace Lab7.Green
{
    public class Task5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int ind;


            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    int[] copy = new int[_marks.Length];
                    for (int i = 0; i < copy.Length; i++)
                    {
                        copy[i] = _marks[i];
                    }
                    return copy;
                }
            }
            public double AverageMark
            {
                get
                {
                    double avg = 0;
                    for(int i = 0; i < _marks.Length; i++)
                    {
                        avg += _marks[i];
                    }
                    return avg/_marks.Length;
                }
            }

            public Student(string iname,string isurname)
            {
                _name = iname;
                _surname = isurname;
                _marks = new int[5];
                ind = 0;
            }

            public void Exam(int mark)
            {
                if (ind < 5 && mark > 1 && mark < 6)
                    _marks[ind++] = mark;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(string.Join(" ",_marks));
                Console.WriteLine(AverageMark);
            }
        }
        public struct Group
        {
            private string _name;
            private Student[] _students;
            private int ind;
            public string Name => _name;
            public Student[] Students => _students.ToArray();
            
            public double AverageMark
            {
                get
                {
                    double avg = 0; 
                    int c = 0;
                    int[] array;
                    for(int i=0; i < _students.GetLength(0); i++)
                    {
                        array = _students[i].Marks;
                        for (int j = 0; j < array.Length; j++)
                        {
                            avg += array[j];
                            c++;
                        }
                    }
                    return avg / c;
                }
            }


            public Group(string iname)
            {
                _name = iname;
                _students = new Student[0];
                ind = 0;
            }
            public void Add(Student student)
            {
                Array.Resize(ref _students, _students.Length+1);
                _students[_students.Length-1]=student;
            }


            public void Add(Student[] array)
            {
                ind=_students.Length;
                Array.Resize(ref _students, _students.Length+array.Length);
                for (int i = ind,k=0; i < _students.Length; i++,k++)
                {
                    _students[i] = array[k];
                }
            }

            public static void SortByAverageMark(Group[] array)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    int j = i;
                    while (j>0 && array[j].AverageMark > array[j - 1].AverageMark)
                    {
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        j--;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(_name);
                for (int i=0;i < _students.Length;i++)
                {
                    _students[i].Print();
                }
            }
        }
    }
}
