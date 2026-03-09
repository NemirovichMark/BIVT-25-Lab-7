using System;


namespace Lab7.White
{
   public class Task3
   {
   public struct Student
{
    private string name;
    private string surname;
    private int[] marks;
    private int count;
    private int skipped;

    public string Name => name;
    public string Surname => surname;
    public int Skipped => skipped;

    public double AverageMark
    {
        get
        {
            if (count == 0) return 0;

            int sum = 0;
            for (int i = 0; i < count; i++)
                sum += marks[i];

            return (double)sum / count;
        }
    }

    public Student(string name, string surname)
    {
        this.name = name ?? "";
        this.surname = surname ?? "";
        marks = new int[100];
        count = 0;
        skipped = 0;
    }

    public void Lesson(int mark)
    {
        if (mark == 0)
            skipped++;
        else
        {
            marks[count] = mark;
            count++;
        }
    }

    public static void SortBySkipped(Student[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i].Skipped < array[j].Skipped)
                {
                    Student temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    public void Print()
    {
        Console.WriteLine($"{name} {surname} Avg:{AverageMark} Skipped:{skipped}");
    }
  }
}
}

