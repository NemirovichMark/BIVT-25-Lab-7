using System.Security.Cryptography.X509Certificates;

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
            private int _marksCount;
            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => _marks;
            public int[] Places => _places;
            public int TopPlace
            {
                get
                {
                    int min = int.MaxValue;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        if (_places[i] < min)
                            min = _places[i];
                    }
                    return min;
                }
            }
            
            public double TotalMark
            {
                get
                {
                    double sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sum+= _marks[i];
                    }
                    return sum;
                }
            }
            public int Score
            {
                get
                {
                    int res = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        res+=_places[i];
                    }
                    return res;
                }
            }
            public Participant(string Name, string Surname)
            {
                _name = Name;
                _surname = Surname;
                _marks = new double[7];
                _places = new int[7];
                _marksCount = 0;
            }
            public void Evalute(double result)
            {
                if (_marksCount < 7)
                {
                    _marks[_marksCount] = result;
                    _marksCount++;
                }
            }
            public  static  void SetPlaces(Participant[]  participants)
            {
                for (int j = 0; j < 7; j++)
                {
                    for (int i = 0; i < participants.Length; i++)
                    {
                        int place = 1;
                        for (int k = 0; k < participants.Length; k++)
                        {
                            if (participants[k].Marks[j] > participants[i].Marks[j])
                            {
                                place++;
                            }
                        }
                        participants[i].Places[j] = place;
                    }
                }
                for (int x = 0; x < participants.Length; x++)
                {
                    for (int y = x + 1; y < participants.Length; y++)
                    {
                        if (participants[x].Places[6] > participants[y].Places[6])
                        {
                            (participants[x], participants[y]) = (participants[y], participants[x]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Участник: {Name} {Surname}, Итоговая оценка: {TotalMark}, Сумма мест: {Score}, Лучшее место: {TopPlace}");
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].Score > array[j].Score)
                        {
                            (array[i], array[j]) = (array[j], array[i]);
                        }
                        else if (array[i].Score == array[j].Score && array[i].TopPlace > array[j].TopPlace)
                        {
                            (array[i], array[j]) = (array[j], array[i]);
                        }
                        else if (array[i].Score == array[j].Score && array[i].TopPlace == array[j].TopPlace && array[i].TotalMark < array[j].TotalMark)
                        {
                            (array[i], array[j]) = (array[j], array[i]);
                        }
                    }
                }
            }
        }
    }
}