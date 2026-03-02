using System.Text.RegularExpressions;

namespace Lab7.Purple
{
  public class Task4
  {
    public struct Sportsman
    {
      // Поля
      private string _name;
      private string _surname;
      private double _time;

      // Свойства
      public string Name => _name;
      public string Surname => _surname;
      public double Time => _time;

      // Методы
      public Sportsman(string name, string surname)
      {
        _name = name;
        _surname = surname;
        _time = 0;
      }
      public void Run(double time)
      {
        _time = time;
      }
      public void Print()
      {
        Console.Write($"Name:{_name}  Surname:{_surname}  Time:{_time}");
      }
    }

    public struct Group
    {
      // Поля
      private string _name;
      private Sportsman[] _sportsmen;

      // Свойства
      public string Name => _name;
      public Sportsman[] Sportsmen => _sportsmen;
      // Почему должно работать без .ToArray() ?

      // Методы
      public Group(string name)
      {
        _name = name;
        _sportsmen = new Sportsman[0];
      }
      public Group(Group group)
      {
        _name = group.Name;
        _sportsmen = new Sportsman[group._sportsmen.Length];
        Array.Copy(group._sportsmen, _sportsmen, group._sportsmen.Length);
      }
      public void Add(Sportsman sportsman)
      {
        Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
        _sportsmen[_sportsmen.Length - 1] = sportsman;
      }
      public void Add(Sportsman[] sportsman)
      {
        for (int i = 0; i < sportsman.Length; i++)
          Add(sportsman[i]);
      }
      public void Add(Group group)
      {
        Sportsman[] sportsman = group._sportsmen;
        for (int i = 0; i < sportsman.Length; i++)
          Add(sportsman[i]);
      }
      public void Sort()
      {
        for (int i = 0; i < _sportsmen.Length; i++)
          for (int j = 0; j < _sportsmen.Length - i - 1; j++)
            if (_sportsmen[j].Time > _sportsmen[j + 1].Time)
              (_sportsmen[j], _sportsmen[j + 1]) = (_sportsmen[j + 1], _sportsmen[j]);
      }
      public static Group Merge(Group group1, Group group2)
      {
        Group answer = new Group("Финалисты");
        answer.Add(group1);
        answer.Add(group2);
        answer.Sort();
        return answer;
      }
      public void Print()
      {
        Console.Write($"Name:{_name}");
      }
    }
  }
}
