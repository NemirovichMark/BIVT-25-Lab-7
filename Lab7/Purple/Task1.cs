namespace Lab7.Purple
{
    public class Task1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;

            private int _currentJump;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs => _coefs.ToArray();
            public int[,] Marks => (int[,])_marks.Clone();

            public double[,] TotalScore
            {
                get
                {
                    return null;
                }
            }

            public Participant(string Name, string Surname)
            {
                if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname)) throw new Exception("Null constructor");
                _name = Name;
                _surname = Surname;
                _coefs = [2.5, 2.5, 2.5, 2.5];
                _marks = new int[4, 7];
                _currentJump = 0;
            }
            public void SetCriterias(double[] coefs)
            {
                bool isA = true;
                //if (coefs.Length == 4)
                //    for (int x = 0; x < _coefs.Length; x++)
                //        if (coefs[x] < 2.5) 
            }
            public void Jump(int[] marks)
            {
                bool isA = true;
                if (marks.Length == 7 && _currentJump < 4)
                    for (int x = 0; x < _marks.GetLength(1); x++)
                        if (marks[x] < 0 || marks[x] > 6) isA = false;
                if (isA)
                    for (int x = 0; x < _marks.GetLength(1); x++)
                        _marks[_currentJump, x] = marks[x];
                _currentJump++;
            }
            public void Print()
            {
                Console.WriteLine($"Имя:{_name}\n" +
                    $"Фамилия:{_surname}\n" +
                    $"Сложность прыжков:{string.Join(' ', _coefs)}");
                Console.WriteLine("Оценки Судей:");
                PrintMatrix(_marks);
            }
            public static void Sort(Participant[] array)
            {

            }
            private void PrintMatrix(int[,] matrix)
            {
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                    for (int x = 0; x < matrix.GetLength(1); x++)
                    {
                        Console.Write($"{matrix[y, x]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}