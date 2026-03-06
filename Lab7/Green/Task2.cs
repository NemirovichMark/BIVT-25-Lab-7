using System.Collections;

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
            private int _count = 0;

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

                    double average = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        average += _marks[i];
                    }
                    average /= _marks.Length;
                    return average;
                }
            }
            public bool IsExcellent
            {
                get
                {

                    if (_marks == null || _marks.Length == 0)
                        return false;
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
                // Проинициализировать ВСЕ поля
                _name = name;
                _surname = surname;
                _marks = new int[4];
            }

            // Методы

            public void Exam(int mark)
            {
                if (mark < 2 || mark > 5) 
                    return;
                if (_count<= _marks.Length)
                { 
                    _marks[_count++] = mark;
                }
                   
                

            }
            public static void SortByAverageMark(Student[] array)
            {

                if (array == null) 
                    return; 
                for (int i = 0; i < array.Length - 1; i++)
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
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(string.Join(" ", _marks));
                Console.WriteLine(AverageMark);
                Console.WriteLine(IsExcellent);

            }
        }
    }

}
