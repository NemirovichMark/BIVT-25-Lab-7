using System;

namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int _jumpCount;

            public string Name => _name;
            public string Surname => _surname;

            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return new int[2, 5];
                    return (int[,])_marks.Clone();
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _jumpCount = 0;
            }


            public void Jump(int[] result)
            {
                if (result == null || result.Length != 5 || _jumpCount >= 2) return;

                for (int i = 0; i < 5; i++)
                {
                    _marks[_jumpCount, i] = result[i];
                }

                _jumpCount++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
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
                Console.WriteLine($"Спортсмен: {Surname} {Name} | Итоговый балл: {TotalScore}");
            }
        }
    }
}