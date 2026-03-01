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


            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3]; 
                _isExpelled = false;
            }

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray(); 
            public bool IsExpelled => _isExpelled;

            public double AverageMark
            {
                get
                {
                    if (_marks == null) return 0;
                    return _marks.Where(m => m > 0).DefaultIfEmpty(0).Average();
                }
            }
            public void Exam(int mark)
            {
                if (_marks == null) return;

                
                if (_isExpelled) return;

                
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;  

                        if (mark == 2)
                        {
                            _isExpelled = true;  
                        }
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
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Средний балл: {AverageMark}, Отчислен: {_isExpelled}");
            }
        }
    }
}
