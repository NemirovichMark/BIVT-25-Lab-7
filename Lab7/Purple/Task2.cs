namespace Lab7.Purple
{
  public class Task2
  {
    public struct Participant
    {
      // Поля
      private string _name;
      private string _surname;
      private int _distance;
      private int[] _marks;

      // Свойства
      public string Name => _name;
      public string Surname => _surname;
      public int Distance => _distance;
      public int[] Marks
      {
        get
        {
          int[] answer = new int[5];
          for (int i = 0; i < 5; i++)
            answer[i] = _marks[i];
          return answer;
        }
      }
      public int Result
      {
        get
        {
          int answer = 60, S = 0, mx = int.MinValue, mn = int.MaxValue;
          for (int i = 0; i < _marks.Length; i++)
          {
            (mx, mn) = (Math.Max(_marks[i], mx), Math.Min(_marks[i], mn));
            S += _marks[i];
          }
          S = S - (mx + mn);
          if (_distance < 120)
          {
            if (answer - (2 * (120 - _distance)) > 0)
              answer -= 2 * (120 - _distance);
            else
              answer = 0;
          }
          else if (_distance > 120)
            answer += 2 * (_distance - 120);
          return answer + S;
        }
      }

      // Методы
      public Participant(string name, string surname)
      {
        _name = name;
        _surname = surname;
        _distance = 0;
        _marks = new int[5] { 0, 0, 0, 0, 0 };
      }
      public void Jump(int distance, int[] marks)
      {
        _distance = distance;
        for (int i = 0; i < marks.Length; i++)
          _marks[i] = marks[i];
        Print();
      }
      public static void Sort(Participant[] array)
      {
        for (int i = 0; i < array.Length; i++)
          for (int j = 0; j < array.Length - i - 1; j++)
            if (array[j].Result < array[j + 1].Result)
              (array[j], array[j + 1]) = (array[j + 1], array[j]);
      }
      public void Print()
      {
        Console.Write($"Name:{_name}  Surname:{_surname}  Distance:{_distance}\nMarks:");
        for (int i = 0; i < _marks.Length; i++)
          Console.Write(_marks[i] + " ");
        Console.WriteLine();
      }
    }
  }
}
