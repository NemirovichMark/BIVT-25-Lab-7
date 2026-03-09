using System;

namespace Lab7.White  
{
    public class Task2  
    {
public struct Participant
{
    private string name;
    private string surname;
    private double firstJump;
    private double secondJump;

    public string Name => name;
    public string Surname => surname;
    public double FirstJump => firstJump;
    public double SecondJump => secondJump;

    public double BestJump
    {
        get { return Math.Max(firstJump, secondJump); }
    }

    public Participant(string name, string surname)
    {
        this.name = name ?? "";
        this.surname = surname ?? "";
        firstJump = 0;
        secondJump = 0;
    }

    public void Jump(double result)
    {
        if (firstJump == 0)
            firstJump = result;
        else if (secondJump == 0)
            secondJump = result;
    }

    public static void Sort(Participant[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i].BestJump < array[j].BestJump)
                {
                    Participant temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    public void Print()
    {
        Console.WriteLine($"{name} {surname} {BestJump}");
    }
}
    }
}

