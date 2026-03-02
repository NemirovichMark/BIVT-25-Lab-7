using System.Runtime.InteropServices;
using static Lab7.Purple.Task1;

namespace Lab7.Purple
{
  public class Task1
  {
    public struct Participant
    {
      // Поля
      private string _name;
      private string _surname;
      private double[] _coefs;
      private int[,] _marks;

      // Свойства
      public string Name => _name;
      public string Surname => _surname;
      public double[] Coefs
      {
        get {
          double[] answer = new double[4];
          for (int i = 0; i < _coefs.Length; i++)
            answer[i] = _coefs[i];
          return answer;
        }
      }
      public int[,] Marks
      {
        get
        {
          int[,] answer = new int[4, 7];
          for (int i = 0; i < answer.GetLength(0); i++)
            for (int j = 0; j < answer.GetLength(1); j++)
              answer[i, j] = _marks[i, j];
          return answer;
        }
      }
      public double TotalScore
      {
        get
        {
          double answer = 0;
          for (int i = 0; i < _marks.GetLength(0); i++)
          {
            double S = 0, mx = int.MinValue, mn = int.MaxValue;
            for (int j = 0; j < _marks.GetLength(1); j++)
            {
              (mx, mn) = (Math.Max(_marks[i, j], mx), Math.Min(_marks[i, j], mn));
              S += _marks[i, j];
            }
            S = S - (mx + mn);
            S = S * _coefs[i];
            answer += S;
          }
          return answer;
        }
      }

      // Методы
      public Participant(string name, string surname)
      {
        _name = name;
        _surname = surname;
        _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
        _marks = new int[4, 7];
        
      }
      public void SetCriterias(double[] coefs)
      {
        for (int i = 0; i < coefs.Length; i++)
          _coefs[i] = coefs[i];
      }
      int counter = 0;
      public void Jump(int[] marks)
      {
        for (int i = 0; i < marks.Length; i++)
          _marks[counter, i] = marks[i];
        counter++;
        if (counter >= 4) counter = 0;
      }
      public static void Sort(Participant[] array)
      {
        for (int i = 0; i < array.Length; i++)
          for (int j = 0; j < array.Length - i - 1; j++)
            if (array[j].TotalScore < array[j + 1].TotalScore)
              (array[j], array[j + 1]) = (array[j + 1], array[j]);
      }
      public void Print()
      {
        Console.Write($"Name:{_name}  Surname:{_surname}\nCoefs:");
        for (int i = 0; i < _coefs.Length; i++)
          Console.Write(_coefs[i] + " ");
        Console.Write("\nMarks:");
        for (int i = 0; i < _marks.GetLength(0); i++)
        {
          for (int j = 0; j < _marks.GetLength(1); j++)
            Console.Write(_marks[i, j] + " ");
          Console.WriteLine();
        }
        Console.WriteLine();
      }
    }
  }
}
