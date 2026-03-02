namespace Lab7.Purple
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            public string Name=>_name;
            public string Surname=>_surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return new double[7];
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return new int[7];
                    int[] copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }

            public int TopPlace
            {
                get
                {
                    int mn = int.MaxValue;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        if (mn > _places[i])
                        {
                            mn = _places[i];
                        }
                    }
                    return mn;
                }
            }
            public double TotalMark
            {
                get
                {
                    double sum = 0;
                    for(int i = 0; i < 7; i++)
                    {
                        sum += Marks[i];
                    }
                    return sum;
                }
            }
            public int Score
            {
                get
                {
                    int score = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        score += _places[i];
                    }
                    return score;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[0];
                _places = new int[7];
        }
            public void Evaluate(double result)
            {
                if(_marks.Length < 7)
                {
                    Array.Resize(ref _marks, _marks.Length + 1);
                    _marks[^1] = result;
                }
            }
            public static void SetPlaces(Participant[] participants)
            {
                double[,] array = new double[participants.Length,7];
                // Заполняем массив оценками участников
                for (int i = 0; i < participants.Length; i++)
                {
                    for (int j = 0; j < participants[i]._marks.Length; j++)
                    {
                        array[i, j] = participants[i]._marks[j];
                    }
                }
                for (int i=0; i < 7; i++)
                {
                    int[] places = new int[participants.Length];
                    double[] orig = new double[participants.Length];
                    double[] sorted = new double[participants.Length];
                    for (int j = 0; j < participants.Length; j++)
                    {
                        orig[j] = array[j, i];
                        sorted[j] = array[j, i];
                    }
                    // Сортировка пузырьком
                    for (int j = 0; j < sorted.Length - 1; j++)
                    {
                        for (int m = 0; m < sorted.Length - 1 - j; m++)
                        {
                            if (sorted[m] < sorted[m + 1])
                            {
                                double temp = sorted[m];
                                sorted[m] = sorted[m + 1];
                                sorted[m + 1] = temp;
                            }
                        }
                    }
                    //сопоставляем значение отсортированой и исходной таблиц, чтобы раставить места
                    for (int j = 0; j < participants.Length; j++)
                    {
                        for (int k = 0; k < participants.Length; k++)
                        {
                            if (orig[j] == sorted[k])
                            {
                                places[j] = k + 1;
                            }
                        }
                    }
                    for (int j = 0; j < participants.Length; j++)
                    {
                        array[j, i] = places[j];
                    }
                }
                for (int i = 0; i < participants.Length; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        participants[i]._places[j] = Convert.ToInt32(array[i, j]);
                    }
                }

            }
            public static void Sort(Participant[] array)
            {
                // Сортировка пузырьком
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Score > array[j + 1].Score)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if(array[j].Score == array[j + 1].Score)
                        {
                            int a1 = 0;
                            int a2 = 0;
                            for (int k = 0; k < 7; k++)
                            {
                                if (array[j].Places[k]> array[j + 1].Places[k])
                                {
                                    a1++;
                                }
                                if (array[j].Places[k] < array[j + 1].Places[k])
                                {
                                    a2++;
                                }
                                if (a1 < a2)
                                {
                                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                                }
                            }
                            if (array[j].TotalMark < array[j + 1].TotalMark)
                            {
                                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            }
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Name:{_name}");
                Console.WriteLine($"Surname:{_surname}");
                Console.WriteLine($"Score:{Score}");
                Console.WriteLine($"TopPlace:{TopPlace}");
                Console.WriteLine($"TotalMark:{TotalMark}");
            }
        }
    }
}
