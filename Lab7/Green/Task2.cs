using System.Collections;
using System.Collections.Specialized;

namespace Lab7.Green
{
    public class Task2
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
            public int[] Marks
            {
                get
                {
                    int[] copy = new int[_marks.Length];
                    for (int i = 0; i < _marks.Length; i++)
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
                    if (_marks == null || _marks.Length == 0) return 0;
                    double sum = 0;
                    double avermark = 0;
                    int count = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] != 0)
                        {
                            sum += _marks[i];
                            count++;
                        }
                    }
                    if (count == 0)
                        return 0;
                    else
                        return avermark = sum / count;   
                }
            }
            public bool IsExcellent
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return false;
                    int count = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] < 4)
                            return false;
                    }
                    return true;
                }
            }

            // Конструктор
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[4];
            }

            // Метод
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

            public static void SortByAverageMark(Student[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AverageMark < array[j + 1].AverageMark)
                        {
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name}");
                Console.WriteLine($"Фамилия: {Surname}");
                Console.Write($"Оценки: ");
                for (int i = 0; i < _marks.Length ; i++)
                {
                    Console.Write(_marks[i] + " ");
                }
                Console.WriteLine($"Средний балл: {AverageMark:F2}");
                Console.WriteLine($"Отличник: {(IsExcellent ? "да" : "нет")}");
                Console.WriteLine();
            }
        }
    }
}
