namespace Lab7.Purple
{
    public class Task3
    {
        public struct Participant
        {

            //поля 

            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _topPlace;
            private double _totalMark;
            private int _judgsNumber = 0;

            //свойства

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return new double[0];
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return new int[0];
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
                    if (_places == null || _places.Length != 7)
                    {
                        return 0;
                    }
                    for (int i = 0; i < _places.Length; i++)
                    {
                        res += _places[i];
                    }
                    return res;
                }
            }

            //конструктор

            public Participant(string name, string surname)
            {
                _surname = surname;
                _name = name;
                _marks = new double[7];
                _places = new int[7];
                _topPlace = int.MaxValue;
                _totalMark = 0;

            }

            //методы

            public void Evaluate(double result)
            {
                if (_judgsNumber >= _marks.Length)
                {
                    return;
                }
                else _marks[_judgsNumber] = result;
                _judgsNumber ++;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0)
                {
                    return;
                }
                int n = participants.Length;
                int[] indices = new int[n];
                for (int judge = 0; judge < 7; judge++)
                {
                    for (int i = 0; i < n; i++)
                        indices[i] = i;

                    int idx = 1;
                    int jdx = 2;

                    while (idx < n)
                    {
                        if (idx == 0 || participants[indices[idx]]._marks[judge] <= participants[indices[idx - 1]]._marks[judge])
                        {
                            idx = jdx;
                            jdx++;
                        }
                        else
                        {
                            (indices[idx], indices[idx - 1]) = (indices[idx - 1], indices[idx]);
                            idx--;
                        }
                    }
                    for (int place = 0; place < n; place++)
                    {
                        int originalIdx = indices[place];
                        participants[originalIdx]._places[judge] = place + 1;
                        
                        if (place + 1 < participants[originalIdx]._topPlace)
                        {
                            participants[originalIdx]._topPlace = place + 1;
                        }
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < 7; j++)
                    {
                        sum += participants[i]._marks[j];
                    }
                    participants[i]._totalMark = sum;
                }
                int a = 1;
                int b = 2;
                
                while (a < n)
                {
                    if (a == 0 || participants[a]._places[6] >= participants[a - 1]._places[6])
                    {
                        a = b;
                        b++;
                    }
                    else
                    {
                        (participants[a - 1], participants[a]) = (participants[a], participants[a - 1]);
                        a--;
                        }
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 1)
                {
                    return;
                }
                int i = 1;
                int j = 2;
                while (i < array.Length)
                {
                    if (i == 0 || array[i - 1].Score < array[i].Score || 
                    array[i - 1].Score == array[i].Score && array[i - 1].TopPlace < array[i].TopPlace ||
                    array[i - 1].Score == array[i].Score && array[i - 1].TopPlace == array[i].TopPlace && 
                    array[i - 1].TotalMark >= array[i].TotalMark)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        i--;
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
