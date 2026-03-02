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
                    double sum = 0;
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
                    {
                        return 0;
                    }
                    else
                    {
                        return sum / count;
                    }
                }
            }
            public bool IsExcellent
            {
                get
                {
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] < 4)
                            return false;
                    }
                    return true;
                }
            }
            
            
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[4];
            }
            
            public void Exam(int mark)
            {
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break; // выходим из цикла, чтобы не заполнить все предметы
                    }
                }
            }
            
            public static void SortByAverageMark(Student[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
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
                Console.WriteLine($"Студент: {_name} {_surname}");
                Console.Write("Оценки: ");
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] != 0)
                    {
                        Console.Write(_marks[i] + " ");
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"Средний балл: {AverageMark:F2}");
                Console.WriteLine($"Все оценки 4 и выше: {IsExcellent}");
                Console.WriteLine();
            }
        }
    }
}
