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
            private int _ind;


            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    int[] copy = new int[_marks.Length];
                    for (int i = 0; i < copy.Length; i++)
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
                    for (int i=0;i< _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _marks.Length;
                }
            }

            public bool IsExcellent
            {
                get
                {
                    for (int i=0; i < _marks.Length; i++)
                    {
                        if (_marks[i] < 4)
                            return false;
                    }
                    return true;
                }
            }

            public Student(string iname,string isuranme)
            {
                _name=iname;
                _surname=isuranme;
                _marks=new int[4];
                _ind = 0;
            }



            public void Exam(int mark)
            {
                if (_ind < _marks.Length)
                {
                    _marks[_ind] = mark;
                    _ind++;
                }
            }
            public static void SortByAverageMark(Student[] array)
            {
                if (array != null)
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        int j = i;
                        while (i > 0 && array[i].AverageMark > array[i - 1].AverageMark)
                        {
                            (array[i], array[i - 1]) = (array[i - 1], array[i]);
                            i--;
                        }
                        i = j;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(AverageMark);
                Console.WriteLine(IsExcellent);
            }

        }
    }
}
