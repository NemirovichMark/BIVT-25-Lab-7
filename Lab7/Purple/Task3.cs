using System;

namespace Lab7.Purple
{
    public class Task3
    {
        public struct Participant
        {
            // ПОЛЯ
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _topPlace;
            private double _totalMark;
            private int _judgesNumber; // хранит количество оценок

            // СВОЙСТВА
            public string Name => _name;
            public string Surname => _surname;

            public double[] Marks
            {
                get
                {
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get
                {
                    int[] copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }
            public int TopPlace => _topPlace;
            public double TotalMark => _totalMark;

            public int Score
            {
                get
                {
                    int res = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        res += _places[i];
                    }
                    return res;
                }
            }

            // КОНСТРУКТОР
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7]; // 7 судей
                _places = new int[7];
                _topPlace = int.MaxValue; // максимально возможное место
                _totalMark = 0;
                _judgesNumber = 0; // начальное количество оценок
            }

            // МЕТОД ДЛЯ ДОБАВЛЕНИЯ ОЦЕНКИ
            public void Evaluate(double result)
            {
                if (_judgesNumber < _marks.Length)
                {
                    _marks[_judgesNumber] = result;
                    _judgesNumber++;
                }
            }

            // МЕТОД ДЛЯ УСТАНОВКИ МЕСТ
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0)
                    return;

                int n = participants.Length;

                // Обнуляем значения
                for (int i = 0; i < n; i++)
                {
                    participants[i]._totalMark = 0;
                    participants[i]._topPlace = int.MaxValue; // максимальное возможное место
                    Array.Clear(participants[i]._places, 0, 7);
                }

                // Для каждого судьи
                for (int judge = 0; judge < 7; judge++)
                {
                    // Создаем массив для хранения индексов и оценок
                    double[] judgeMarks = new double[n];
                    int[] indices = new int[n];

                    for (int i = 0; i < n; i++)
                    {
                        indices[i] = i; // сохраняем индексы участников
                        judgeMarks[i] = participants[i]._marks[judge]; // сохраняем оценки
                    }

                    // Сортируем индексы по убыванию оценок
                    Array.Sort(judgeMarks, indices);

                    // Устанавливаем места (1 - лучшее)
                    for (int place = 0; place < n; place++)
                    {
                        int participantIndex = indices[n - 1 - place]; // обратный порядок
                        participants[participantIndex]._places[judge] = place + 1;

                        if (place + 1 < participants[participantIndex]._topPlace)
                        {
                            participants[participantIndex]._topPlace = place + 1;
                        }
                    }
                }

                // Суммируем оценки
                for (int i = 0; i < n; i++)
                {
                    participants[i]._totalMark = 0; // обнуляем
                    for (int j = 0; j < 7; j++)
                    {
                        participants[i]._totalMark += participants[i]._marks[j];
                    }
                }
            }

            // СТАТИЧЕСКИЙ МЕТОД ДЛЯ СОРТИРОВКИ
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1)
                    return;

                for (int i = 1; i < array.Length; i++)
                {
                    Participant current = array[i];
                    int j = i - 1;

                    // Найти правильное место для current элемента
                    while (j >= 0 && (array[j].Score > current.Score || (array[j].Score == current.Score && array[j].TopPlace > current.TopPlace) || (array[j].Score == current.Score && array[j].TopPlace == current.TopPlace && array[j].TotalMark < current.TotalMark)))
                    {
                        j--;
                    }

                    // Вставить current элемент на правильное место
                    if (j + 1 != i) // Если позиция изменилась
                    {
                        // Сдвигаем элементы вправо, чтобы освободить место для current
                        Participant temp = current; // Сохраняем текущий элемент
                        for (int k = i; k > j + 1; k--)
                        {
                            array[k] = array[k - 1]; // Сдвигаем элемент
                        }
                        array[j + 1] = temp; // Вставляем текущий элемент на правильное место
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {Score}");
            }
        }
    }
}
