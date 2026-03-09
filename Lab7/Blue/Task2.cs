namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int _attemptCount;

            public string Name => _name;
            public string Surname => _surname;

            public int[,] Marks
            {
                get
                {
                    int rows = _marks.GetLength(0);
                    int cols = _marks.GetLength(1);
                    int[,] copy = new int[rows, cols];
                    
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            copy[i, j] = _marks[i, j];
                        }
                    }
                    
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    int rows = _marks.GetLength(0);
                    int cols = _marks.GetLength(1);
                    
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            total += _marks[i, j];
                        }
                    }
                    
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _attemptCount = 0;
            }

            public void Jump(int[] result)
            {
                if (result == null) return;
                
                if (_attemptCount < 2 && result.Length == 5)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        _marks[_attemptCount, j] = result[j];
                    }
                    _attemptCount++;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name},{Surname},{TotalScore}");
            }
        }
    }
}
