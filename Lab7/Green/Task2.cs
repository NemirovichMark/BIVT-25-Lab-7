using System.Collections;


namespace Lab7.Green
{
    public class Task2
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
                _marks = new int[4];
            }

            public string Name=>_name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();

            public double AverageMark
            {
                get
                {
                    if (_marks == null) return 0;

                    int sum = 0;
                    int count = 0;

                    foreach( int m  in _marks )
                    {
                        if (m != 0)
                        {
                            sum += m;
                            count++;
                        }
                    }
                    if (count==0) return 0;

                    return (double)sum / 4;
                }
            }

            public bool IsExcellent
            {
                get
                {
                    if (_marks == null) return false;
                    foreach( int m in _marks)
                    {
                        if (m < 4) return false;
                    }

                    return true;
                }
            }

            public void Exam(int mark)
            {
                if (_marks == null) return;
                for (int i=0;i< _marks.Length;i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }

            public static void SortByAverageMark(Student[] array)
            {
                if (array == null) return;
                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark));

            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Средний балл: {AverageMark}, Отличник: {IsExcellent}");
            }
        }
    }
}
