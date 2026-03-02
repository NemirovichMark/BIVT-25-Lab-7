namespace Lab7.White
{
    public class Task3
    {
        public struct Student
        {
            //Поля
            private string _name;
            private string _surname;
            private int _skip;
            private int[] _marks;

            //Свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Skipped => _skip;
            public double AverageMark
            {
                get
                {
                    if (_marks.Length == 0) return 0;
                    double avg = 0;
                    for (int i = 0; i < _marks.Length; i++) avg += _marks[i];
                    avg /= _marks.Length;
                    return avg;
                }
            }

            //Конструктор 
            public Student(string name, string surname)
            {
                _name=name;
                _surname=surname;
                _marks = new int[0];
            }
            //Методы
            public void Lesson(int mark)
            {
                if (mark == 0) _skip++;
                else
                {
                    Array.Resize(ref _marks, _marks.Length + 1);
                    _marks[_marks.Length - 1] = mark;
                }
            }
            public static void SortBySkipped(Student[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].Skipped < array[j + 1].Skipped)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                return;
            }
        }
    }
}
