using System.Collections;
using System;

namespace Lab7.Green
{
    public class Task3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _is_expelled;
            private int ind;


            public string Name => _name;
            public string Surname => _surname;
            public bool IsExpelled => _is_expelled;
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
                    double avg = 0;
                    int k = 0;
                    for (int i=0; i < _marks.Length; i++)
                    {
                        if (_marks[i] == 0)
                            k++;
                        
                        avg += _marks[i];
                    }
                    if (k == 3) return 0;
                    return avg/(_marks.Length-k);
                }
            }

            public Student(string iname,string isurname)
            {
                _name = iname;
                _surname = isurname;
                _marks = new int[3];
                ind = 0;
                _is_expelled = false;
            }

            public void Exam(int mark)
            {
                if (_is_expelled || ind >= 3)
                    return;
                if (mark < 2 || mark > 5) 
                    return;

                _marks[ind] = mark;
                if (mark == 2)
                    _is_expelled = true;

                ind++;
            }


            public static void SortByAverageMark(Student[] array)
            {
                if (array != null)
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        int j = i;
                        while (j > 0 && array[j].AverageMark > array[j-1].AverageMark)
                        {
                            (array[j-1], array[j]) = (array[j], array[j-1]);
                            j--;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(string.Join(" ",_marks));
                Console.WriteLine(_is_expelled);
                Console.WriteLine(AverageMark);
            }

        }
    }
}
