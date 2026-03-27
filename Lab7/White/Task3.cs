using System.Collections.Generic;   
using System.Linq;                 

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

            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new List<int>();
                this.skipped = 0;
            }

            public string Name => name;
            public string Surname => surname;
            public int Skipped => skipped;

            public double AverageMark => marks.Count == 0 ? 0 : marks.Average();

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
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j+1].skipped > array[j].skipped)
                        {
                            (array[j], array[j+1]) = (array[j+1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(name + " " + surname);
                Console.WriteLine("Пропуски: " + skipped);
                Console.WriteLine("Средний балл: " + AverageMark.ToString("F2"));
                Console.WriteLine();
            }
        }
    }
}
