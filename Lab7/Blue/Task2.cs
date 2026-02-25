using System;

namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _Name;
            private string _Surname;
            private int[,] _Marks;
            private int _jumpCount;

            public string Name => _Name;
            public string Surname => _Surname;

            public int[,] Marks
            {
                get
                {
                    if (_Marks == null)
                        return null;
                    
                    int rows = _Marks.GetLength(0);
                    int cols = _Marks.GetLength(1);
                    int[,] copy = new int[rows, cols];
                    
                    for (int i = 0; i < rows; i++)
                        for (int j = 0; j < cols; j++)
                            copy[i, j] = _Marks[i, j];
                    
                    return copy;
                }
            }

            public int TotalScore 
            {
                get
                {
                    if (_Marks == null)
                        return 0;

                    int score = 0;
                    foreach (int el in _Marks)
                        score += el;
                    return score;
                }
            }

            public Participant(string Name, string Surname)
            {
                _Name = Name ;
                _Surname = Surname ;
                _Marks = new int[2, 5];
                _jumpCount = 0;
            }

            public void Jump(int[] result)
            {
                if (result == null || _Marks == null)
                    return;
                
                if (_jumpCount >= 2)
                    return;

                for (int j = 0; j < Math.Min(5, result.Length); j++)
                {
                    _Marks[_jumpCount, j] = result[j];
                }

                _jumpCount++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null)
                    return;
                
                Array.Sort(array, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {Name}\nФамилия: {Surname}\nБаллы: {TotalScore}");
            }
        }
    }
}