namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks = new int[2, 5];
            private int _jumpCount; // счётчик показывает какой прыжок сейчас заполнять (первый или второй) и когда остановиться
            
            public string Name => _name;
            public string Surname => _surname;
            
            // создание копии массива с оценками, чтобы не изменять исходные данные оценок
            public int[,] Marks
            {
                get
                {
                    return (int[,])_marks.Clone(); // возвращаем копию
                }
            }
            
            
            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        { sum += _marks[i, j];}
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];   // автоматически заполняется нулями
                _jumpCount = 0;
            }

            public void Jump(int[] result)
            {
                if (_jumpCount >= 2) return;
                if (result == null) return;
                if (result.Length != 5) return;

                for (int i = 0; i < 5; i++)
                {
                    _marks[_jumpCount, i] = result[i];
                }

                _jumpCount++;
            }
            
            public static void Sort(Participant[] array)
            {
                // Используем встроенную сортировку с компаратором
                Array.Sort(array, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }
            
            public void Print()
            {
                Console.WriteLine("Name: " + _name + ", Surname: " + _surname + ", TotalScore: " + TotalScore);
            }
        }
    }
}
