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
            private int _topPlace;
            private double _totalMark;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    int n = _marks.Length;
                    if (n == 0 || _marks == null) return null;
                    double[] copy_marks = new double[n];
                    for (int i = 0; i < n; i++)
                    {
                        copy_marks[i] = _marks[i];
                    }
                    return copy_marks;
                }
            }
            public int[] Places
            {
                get
                {
                    int n = _places.Length;
                    if (n == 0 || _places == null) return null;
                    int[] copy_places = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        copy_places[i] = _places[i];
                    }
                    return copy_places;
                }
            }
            public int TopPlace => _topPlace;
            public double TotalMark => _totalMark;
            public int Score
            {
                get
                {
                    if (_places == null) return 0;
                    return _places.Sum();
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _places = new int[7];
                _marks = new double[7];
                _topPlace = 0;
                _totalMark = 0;


            }
            public void Evaluate(double result)
            {
                int n = _marks.Length;
                if (result < 0 || result > 6.0) return;
                for (int i = 0; i < n; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = result;
                        _totalMark += result;
                        break;
                    }
                }
            }
            public static void SetPlaces(Participant[] participants)
            {
                int n = participants.Length;
                if (n == 0 || participants == null) return;
                for (int judge = 0; judge < 7; judge++)
                {
                    Array.Sort(participants, (a, b) => b._marks[judge].CompareTo(a._marks[judge]));
                    for (int p = 0; p < n; p++)
                    {
                        participants[p]._places[judge] = p + 1;
                        if (judge == 0 || (p+1) < participants[p].TopPlace )
                        {
                            participants[p]._topPlace = p + 1;
                        }
                    }
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                Array.Sort(array, (a, b) =>
                {
                    if (a.Score != b.Score) return a.Score.CompareTo(b.Score); 
                    else if (a.TopPlace != b.TopPlace) return a.TopPlace.CompareTo(b.TopPlace);
                    return b.TotalMark.CompareTo(a.TotalMark); //оценка => убывание
                });
            }
            public void Print()
            {
                Console.WriteLine($"name: {_name}, surname: {_surname}, score: {Score}");
                    
            }
        }
    }
}
