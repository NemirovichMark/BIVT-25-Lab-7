using System.Collections;

namespace Lab7.Green
{
    public class Task3
    {
        public struct Student
        {
            // Поля 
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _isexpelled;

            // Свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();
            public bool IsExpelled => _isexpelled;

            public double AverageMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    double sum = 0;
                    int count = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] > 0)
                        {
                            sum += _marks[i];
                            count++;
                        }
                    }
                    if (count == 0)
                        return 0;
                    return sum / count;
                }
            }

            // Конструктор
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _isexpelled = false;
            }

            // Метод
            public void Exam(int mark)
            {
                if (_isexpelled)
                    return;
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        if (mark == 2)
                            _isexpelled = true;
                        break;
                    }
                }
            }

            public static void SortByAverageMark(Student[] array)
            {
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
                Console.WriteLine($"Имя: {Name} {Surname}");
                Console.Write("Оценки: ");
                foreach (int m in _marks)
                    Console.Write(m + " ");
                Console.WriteLine($"Средний балл: {AverageMark}");
                Console.WriteLine($"Статус: {(IsExpelled ? "Отчислен" : "Учится")}");
                Console.WriteLine();
            }
        }
    }
    
}
