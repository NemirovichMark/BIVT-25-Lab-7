namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int [,] _marks = new int[2,5]; // матрица оценок по двум прыжкам
            private int _jumpCount; // счётчик показывает какой сейчас прыжок(первый или второй)

            // свойства
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
            public double TotalScore // общая сумма баллов
            {
                get
                {
                    double sum = 0;
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 5; j++)
                            sum += _marks[i, j];
                    return sum;
                }
            }
            //конструктор
            public Participant(string name, string surname) // фамилия, имя, матрица из нулей
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5]; 
            }

            //добавление оценок за прыжок
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
                if (array == null || array.Length <= 1)
                    return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {TotalScore}");
            }
        }
    }
}
