using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7.White
{
 public class Task4
 {
     public struct Participant
{
    private string name;
    private string surname;
    private double[] scores;
    private int count;

    public string Name => name;
    public string Surname => surname;
    public double[] Scores => scores;

    public double TotalScore
    {
        get
        {
            double sum = 0;
            for (int i = 0; i < count; i++)
                sum += scores[i];
            return sum;
        }
    }

    public Participant(string name, string surname)
    {
        this.name = name ?? "";
        this.surname = surname ?? "";
        scores = new double[100];
        count = 0;
    }

    public void PlayMatch(double result)
    {
        scores[count] = result;
        count++;
    }

    public static void Sort(Participant[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i].TotalScore < array[j].TotalScore)
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
        Console.WriteLine($"{name} {surname} Score:{TotalScore}");
    }
  }
}
}
