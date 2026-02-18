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
            private bool _expelled;

            
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _expelled = false;
            }

            

            public string Name => _name;
            public string Surname => _surname;
            public bool IsExpelled => _expelled;
            public int[] Marks => _marks.ToArray();

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

                    if (validMarksCount == 0) return 0;
                    return sum / validMarksCount;
                }
            }

            public void Exam(int mark)
            {
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        if (mark > 2)
                        {
                            _marks[i] = mark;
                        }
                        else
                        {
                            _expelled = true;
                            _marks[i] = mark;
                        }
                        return;
                    }
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
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.WriteLine($"AverageMark: {AverageMark:F2}");
                Console.WriteLine($"Expelled: {_expelled}");
            }
        }
    }
}
