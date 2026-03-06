using System.Collections;

namespace Lab7.Green
{
    public class Task3
    {
        public struct Student
        {
            // поля
            private string _name; // Устанавливаются в конструкторе,читаются через свойства
            private string _surname;
            private int[] _marks;
            private bool _status = false;

            // свойства

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray(); // получаем копию массива
            public bool IsExpelled => _status;

            public double AverageMark // возвращает среднее значение оценок студента
            {
                get
                {
                    int validMarksCount = 0;
                    double sum = 0;

                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] > 0) // если оценка есть, то суммируем значения и считаем кол-во
                        {
                            sum += _marks[i];
                            validMarksCount++;
                        }
                    }

                    if (validMarksCount == 0) // если оценок нет
                        return 0;

                    return sum / validMarksCount;
                }
            }

            public Student(string name, string surname) // конструктор, принимает 2 строковых поля
            {
                _name = name; // сохраняет переданное имя в ранее созданное поле _name
                _surname = surname;
                _marks = new int[3]; // 3 экзамена сдают студенты, 3 места для оценок
            }
            public void Exam(int mark) // заменяет оценку по предмету
                                       // новой оценкой, если эта оценка выше «2». 
            {
                if (_status) return;// сразу проверим, не отчислился ли
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        if (mark > 2) // если оценка больше 2, то заполняем в массив оценок _marks
                        {
                            _marks[i] = mark;
                            break;
                        }

                        if (mark == 2) // если оценка == 2, то отчислен
                        {
                            _status = true; // отчислен? да
                            _marks[i] = mark;
                            break;
                        }
                    }
                }
            }
            public static void SortByAverageMark(Student[] array) // метод для сортировки массива
                                                                  //  в порядке убывания среднего балла.
            {
                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark)); // от b к a
            }
            public void Print() // для вывода информации о необходимых полях структуры
            {
                Console.WriteLine($"Name: {Name}"); 
                Console.WriteLine($"Surname: {Surname}");
                Console.WriteLine($"Marks: {Marks}");
                Console.WriteLine($"Average mark: {AverageMark}");
                Console.WriteLine($"Is expelled: {IsExpelled}");
            }
        }
    }
}
