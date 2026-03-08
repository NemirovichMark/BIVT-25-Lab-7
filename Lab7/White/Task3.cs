using System.Collections;
using System.Collections;

namespace Lab7.White
{
    public class Task3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _grade;
            private int _skipped;

            public string Name => _name;
            public string Surname => _surname;
            public int Skipped => _skipped;

            public double AverageMark
            {
                get
                {
                    if (_grade == null || _grade.Length == 0)
                        return 0;
                    
                    int sum = 0;
                    for (int i = 0; i < _grade.Length; i++)
                    {
                        sum += _grade[i];
                    }
                    return (double)sum / _grade.Length;
                }
            }
            
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _grade = new int[0];
                _skipped = 0;
            }
            
            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    _skipped++;
                }
                else
                {
                    int[] newMarks = new int[_grade.Length + 1];
                    for (int i = 0; i < _grade.Length; i++)
                    {
                        newMarks[i] = _grade[i];
                    }
                    newMarks[_grade.Length] = mark;
                    _grade = newMarks;
                }
            }
            
            public static void SortBySkipped(Student[] array)
            {
                if (array == null || array.Length == 0) return;
                
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Skipped < array[j + 1].Skipped)
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
                string gradesStr = string.Join(" ", _grade);
                Console.WriteLine($"{_name} {_surname} | Пропуски: {_skipped} | Оценки: {gradesStr} | Средний балл: {AverageMark:F2}");
            }
        }
    } // Закрывает класс Task3
} // Закрывает namespace Lab7.White
