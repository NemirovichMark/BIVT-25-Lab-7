namespace Lab7.Blue
{
    public class Task2
    {
        /// структура сохраняем данные спортика
        public struct Participant
        {
            // Приватные поля
            private string _name;
            private string _surname;
            private int[,] _balls; // матрица 2x5: 2 прыжка, 5 оценок судей

            /// пчелёнок с баллами
            public Participant(string name, string surname)
            {
                if (name != null)
                {
                    _name = name;
                }
                if (surname != null)
                {
                    _surname = surname;
                }
                // бим бэм матрица с нуликами
                _balls = new int[2, 5];
            }

            /// Свойство только для чтения

            public string Name => _name;
            public string Surname => _surname;  
            public int[,] Marks
            {
                get
                {
                    // бим бэм берем копию и если че меняем её чтоб ориг не трогать
                    int[,] copy = new int[2, 5];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            copy[i, j] = _balls[i, j];
                        }
                    }
                    return copy;
                }
            }
            //гига счет всех баллов
            public int TotalScore
            {
                get
                {
                    if (_balls == null)
                        return 0;

                    int vsego = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            vsego += _balls[i, j];
                        }
                    }
                    return vsego;
                }
            }

            /// Метод для заполнения результатов прыжка
            public void Jump(int[] result)
            {
                //// Проверка входных данных на всякий пожарный
                if (result == null || result.Length != 5)
                    return;

                // Определяем номер прыжка (0 или 1), пока что не прыгал ещё так что -1, у него кредит
                int jumpNumber = -1;

                // Ищем первый незаполненный прыжок
                for (int i = 0; i < 2; i++)
                {
                    bool chetoImeem = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (_balls[i, j] != 0)
                        {
                            chetoImeem = false;
                            break;
                        }
                    }
                    //запоминаем где не имеем ничего и всё
                    if (chetoImeem)
                    {
                        jumpNumber = i;
                        break;
                    }
                }

                if (jumpNumber > -1)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        _balls[jumpNumber, j] = result[j];  // копируем оценки из result в _balls
                    }
                }
            }


            /// Статический метод для сортировки спортсменв 

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1)
                    return;

                // Простая сортировка пузырьком 
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

            /// Метод для вывода информации об участнике
            public void Print()
            {
                return;
            }
        }
    }
}