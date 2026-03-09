using System.Collections;
using System.Collections;

namespace Lab7.Green
{
    public class Task2
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
            public double AverageMark => _marks.Average(); // среднее значение оценок студента
            
            public bool IsExcellent // возвращает значение, все ли оценки по предметам "4" и выше
            {
                get
                {
                    for(int i = 0;i < _marks.Length; i++)
                    {
                        if (_marks[i] < 4) return false;
                    }
                    return true;
                }
            }
            // конструктор
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[4];
            }

            public void Exam(int mark) // заменяет оценку по предмету новой оценкой
            {

                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    }
                    ;
                }
            }
            public static void SortByAverageMark(Student[] array) // для сортировки массива структур в порядке убывания среднего балла
            {

                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark));
            }
            public void Print() // для вывода информации о необходимых полях структуры
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Surname: {Surname}");
                Console.WriteLine($"Marks: {Marks}");
                Console.WriteLine($"Average mark: {AverageMark}");
                Console.WriteLine($"Is excellent: {IsExcellent}");

            }
        }

        }
}

