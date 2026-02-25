using System.Collections;

namespace Lab7.White
{
    public class Task3
    {
        public struct Student
        {
            private string name;
            private string surname;
            private List<int> marks;
            private int skipped;

            public string Name => name;
            public string Surname => surname;
            public int Skipped => skipped;
            public double AverageMark
            {
                get
                {
                    if (marks == null || marks.Count == 0)
                        return 0;

                    double sum = 0;
                    foreach (int mark in marks)
                    {
                        sum += mark;
                    }
                    return sum / marks.Count;
                }
            }

            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                marks = new List<int>();
                skipped = 0;
            }

            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    skipped++;
                }
                else
                {
                    marks.Add(mark);
                }
            }

            public static void SortBySkipped(Student[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
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
                Console.WriteLine($"Name: {name}, Surname: {surname}, Skipped: {skipped}, AverageMark: {AverageMark:F2}");
            }
        }
    }
}