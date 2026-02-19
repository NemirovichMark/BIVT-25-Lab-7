namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            // Поля приват
            private string _name;          
            private string _surname;        
            private int[] _penaltyTimes;  

            public Participant(string name, string surname)
            {
                // Проверяем имя на null, если не null - сохраняем, если null - пустая строка
                if (name != null)
                    _name = name;
                else
                    _name = "";
                if (surname != null)
                    _surname = surname;
                else
                    _surname = "";
                _penaltyTimes = new int[0];
            }

            //читаем штучки
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    // Создаем копию массива (чтобы внешний код не мог изменить оригинал)
                    int[] copy = new int[_penaltyTimes.Length];
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                        copy[i] = _penaltyTimes[i];
                    return copy;
                }
            }

            // Свойство для подсчета общего штрафного времени
            public int TotalTime
            {
                get
                {
                    // Если нет массива - время 0
                    if (_penaltyTimes == null)
                        return 0;

                    // Суммируем все штрафные минуты
                    int vsegoSidel = 0;
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                        vsegoSidel += _penaltyTimes[i];
                    return vsegoSidel;
                }
            }

            // Был на 10-ти минутке?
            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTimes == null)
                        return false;

                    // Ищем 10 минут в массиве
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                        if (_penaltyTimes[i] == 10)
                            return true;  // Нашли  -  исключен
                    return false;
                }
            }

            //  +штраф time
            public void PlayMatch(int time)
            {
                if (time != 0 && time != 2 && time != 5 && time != 10) // Чек чтоб время было как нвдо
                    return;

                // Создаем новый массив на 1 элемент больше старого и копипастим данные, добавляя в конец штуку и меняем массив
                int[] newPenaltyTimes = new int[_penaltyTimes.Length + 1];
                for (int i = 0; i < _penaltyTimes.Length; i++)
                    newPenaltyTimes[i] = _penaltyTimes[i];
                newPenaltyTimes[_penaltyTimes.Length] = time;
                _penaltyTimes = newPenaltyTimes;
            }

            public static void Sort(Participant[] array)
            {
                // Проверка на пустой массив или 1 элемент
                if (array == null || array.Length <= 1)
                    return;
                // пузырек по возрастанию
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.Write($"{Name} {Surname} ");

                if (_penaltyTimes != null)
                {
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                        Console.Write(_penaltyTimes[i] + " ");
                }
                Console.WriteLine($"{TotalTime} {IsExpelled}");
            }
        }
    }
}