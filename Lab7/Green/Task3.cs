using System.Collections;

namespace Lab7.Green
{
    public class Task3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _isExpelled;
            private int _examCount;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _isExpelled = false;
                _examCount = 0;
            }

            public string Name
            {
                get
                {
                    if (_name == null) return "";
                    return _name;
                }
            }

            public string Surname
            {
                get
                {
                    if (_surname == null) return "";
                    return _surname;
                }
            }

            public int[] Marks
            {
                get
                {
                    if (_marks == null) return new int[0];
                    int[] copy = new int[_marks.Length];
                    for (int i = 0; i < _marks.Length; i++)
                        copy[i] = _marks[i];
                    return copy;
                }
            }

            public bool IsExpelled => _isExpelled;

            public double AverageMark
            {
                get
                {
                    if (_marks == null) return 0;
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
                    if (count == 0) return 0;
                    return sum / count;
                }
            }

            public void Exam(int mark)
            {
                if (_examCount >= 3) return;

                _marks[_examCount] = mark;
                _examCount++;

                if (mark == 2)
                {
                    _isExpelled = true;
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
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                string marksStr = string.Join(", ", Marks);
                string expelledText;
                if (_isExpelled)
                    expelledText = "да";
                else
                    expelledText = "нет";
                Console.WriteLine($"Студент: {Name} {Surname}, оценки: {marksStr}, средний балл: {AverageMark:F2}, отчислен: {expelledText}");
            }
        }
    }
}
