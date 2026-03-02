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
            private bool _status = false;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();
            public bool IsExpelled => _status;

            public double AverageMark
            {
                get
                {
                    int validMarksCount = 0;
                    double sum = 0;

                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] > 0)
                        {
                            sum += _marks[i];
                            validMarksCount++;
                        }
                    }

                    if (validMarksCount == 0) 
                        return 0;

                    return sum / validMarksCount;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
            }

            public void Exam(int mark)
            {
                if (_status)
                    return;
                
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        if(mark > 2)
                        {
                            _marks[i] = mark;
                            break;
                        }

                        if (mark == 2)
                        {
                            _status = true;
                            _marks[i] = mark;
                            break;
                        }
                    }
                }
            }

            public static void SortByAverageMark(Student[] array)
            {
                Array.Sort(array, (a, b) => b.AverageMark.CompareTo(a.AverageMark));
            }

            public void Print()
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
