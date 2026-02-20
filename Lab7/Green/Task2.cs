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
            private int _examCount;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[4];
                _examCount = 0;
            }
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks.ToArray();

            public double AverageMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
                        return 0;

                    double sum = 0;
                    
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] > 0)
                        {
                            sum += _marks[i];
                            
                        }
                    }
                    double AvMark = sum / _marks.Length;
                    
                    return AvMark;
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
            

            
            public void Exam(int mark)
            {
                
                if (mark < 2 || mark > 5)
                {
                    return;
                }

                if (_examCount >= 4)
                {
                    return;
                }

                _marks[_examCount] = mark;
                _examCount++;
            }

            public static void SortByAverageMark(Student[] array)
            {
                if (array == null || array.Length == 0)
                    return;


                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
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
                Console.WriteLine($"Name:{_name}");
                Console.WriteLine($"Surename: {_surname}");
                Console.WriteLine($"AverageMark: {AverageMark}");
                Console.WriteLine($"Excellent: {IsExcellent }"); 
            }
        }
    }
}
