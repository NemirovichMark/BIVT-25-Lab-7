namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int count;
            
            public string Name => _name;
            public string Surname => _surname;

            public int[,] Marks
            {
                get
                {
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    foreach(int mark in _marks) total += mark;
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                count = 0;
            }

            public void Jump(int[] result)
            {
                if (count < 2 && result.Length == 5)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        _marks[count, k] = result[k];
                    }
                    count++;
                }
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
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
