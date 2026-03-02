namespace Lab7
{
  public class Program
  {
    public static void Main()
    {
      Purple.Task3.Participant p1 = new Purple.Task3.Participant("Виктор", "Полевой");
      double[] a1 = { 5.93, 5.44, 1.20, 0.28, 1.57, 1.86, 5.89 };
      for (int i = 0; i < a1.Length; i++)
        p1.Evaluate(a1[i]);
      Console.WriteLine($"{p1.TotalMark}  {p1.TopPlace}  {p1.Score}");
      Purple.Task3.Participant p2 = new Purple.Task3.Participant("Алиса", "Козлова");
      double[] a2 = { 1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79 };
      for (int i = 0; i < a2.Length; i++)
        p2.Evaluate(a2[i]);
      Console.WriteLine($"{p2.TotalMark}  {p2.TopPlace}  {p2.Score}");
      Purple.Task3.Participant p3 = new Purple.Task3.Participant("Ярослав", "Зайцев");
      double[] a3 = { 2.93, 3.10, 5.46, 4.88, 3.99, 4.79, 5.56 };
      for (int i = 0; i < a3.Length; i++)
        p3.Evaluate(a3[i]);
      Console.WriteLine($"{p3.TotalMark}  {p3.TopPlace}  {p3.Score}");
      Purple.Task3.Participant p4 = new Purple.Task3.Participant("Савелий", "Кристиан");
      double[] a4 = { 4.20, 4.69, 3.90, 1.67, 1.13, 5.66, 5.40 };
      for (int i = 0; i < a4.Length; i++)
        p4.Evaluate(a4[i]);
      Console.WriteLine($"{p4.TotalMark}  {p4.TopPlace}  {p4.Score}");
      Purple.Task3.Participant p5 = new Purple.Task3.Participant("Алиса", "Козлова");
      double[] a5 = { 3.27, 2.43, 0.90, 5.61, 3.12, 3.76, 3.73 };
      for (int i = 0; i < a5.Length; i++)
        p5.Evaluate(a5[i]);
      Console.WriteLine($"{p5.TotalMark}  {p5.TopPlace}  {p5.Score}");
      Purple.Task3.Participant p6 = new Purple.Task3.Participant("Алиса", "Луговая");
      double[] a6 = { 0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68 };
      for (int i = 0; i < a6.Length; i++)
        p6.Evaluate(a6[i]);
      Console.WriteLine($"{p6.TotalMark}  {p6.TopPlace}  {p6.Score}");
      Purple.Task3.Participant p7 = new Purple.Task3.Participant("Александр", "Петров");
      double[] a7 = { 3.78, 3.42, 3.84, 2.19, 1.20, 2.51, 3.51 };
      for (int i = 0; i < a7.Length; i++)
        p7.Evaluate(a7[i]);
      Console.WriteLine($"{p7.TotalMark}  {p7.TopPlace}  {p7.Score}");
      Purple.Task3.Participant p8 = new Purple.Task3.Participant("Мария", "Смирнова");
      double[] a8 = { 1.35, 3.40, 1.85, 2.02, 2.78, 3.23, 3.03 };
      for (int i = 0; i < a8.Length; i++)
        p8.Evaluate(a8[i]);
      Console.WriteLine($"{p8.TotalMark}  {p8.TopPlace}  {p8.Score}");
      Purple.Task3.Participant p9 = new Purple.Task3.Participant("Полина", "Сидорова");
      double[] a9 = { 0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77 };
      for (int i = 0; i < a9.Length; i++)
        p9.Evaluate(a9[i]);
      Console.WriteLine($"{p9.TotalMark}  {p9.TopPlace}  {p9.Score}");
      Purple.Task3.Participant p10 = new Purple.Task3.Participant("Татьяна", "Сидорова");
      double[] a10 = { 3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84 };
      for (int i = 0; i < a10.Length; i++)
        p10.Evaluate(a10[i]);
      Console.WriteLine($"{p10.TotalMark}  {p10.TopPlace}  {p10.Score}");
      Purple.Task3.Participant[] f = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
      Purple.Task3.Participant.SetPlaces(f);
      p1.Print(); Console.WriteLine(p1.Score); p2.Print(); Console.WriteLine(p2.Score); p3.Print(); Console.WriteLine(p3.Score); p4.Print(); Console.WriteLine(p4.Score); p5.Print(); Console.WriteLine(p5.Score);
      p6.Print(); Console.WriteLine(p6.Score); p7.Print(); Console.WriteLine(p7.Score); p8.Print(); Console.WriteLine(p8.Score); p9.Print(); Console.WriteLine(p9.Score); p10.Print(); Console.WriteLine(p10.Score);
      Console.WriteLine("================================================");
      Purple.Task3.Participant.Sort(f);
      p1.Print(); Console.WriteLine(p1.Score); p2.Print(); Console.WriteLine(p2.Score); p3.Print(); Console.WriteLine(p3.Score); p4.Print(); Console.WriteLine(p4.Score); p5.Print(); Console.WriteLine(p5.Score);
      p6.Print(); Console.WriteLine(p6.Score); p7.Print(); Console.WriteLine(p7.Score); p8.Print(); Console.WriteLine(p8.Score); p9.Print(); Console.WriteLine(p9.Score); p10.Print(); Console.WriteLine(p10.Score);
    }
  }
}
