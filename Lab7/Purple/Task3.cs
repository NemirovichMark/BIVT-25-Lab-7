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
            private int _score;
            private int _countOfMarks;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    var newArr = new double[_marks.Length];
                    Array.Copy(_marks, newArr, _marks.Length);
                    return newArr;
                }
            }
            public int[] Places
            {
                get
                {
                    var newArr = new int[_places.Length];
                    Array.Copy(_places, newArr, _places.Length);
                    return newArr;
                }
            }
            public int TopPlace => _topPlace;
            public double TotalMark => _totalMark;
            public int Score
            {
                get { return _places.Sum(); }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _countOfMarks = 0;
                _topPlace = 0;
                _totalMark = 0;
            }

            public void Evaluate(double result)
            {
                if (_countOfMarks >= 7) return;
                _marks[_countOfMarks++] = result;
            }

            public static void SetPlaces(Participant[] participants)
            {
                int n = participants.Length;

                for (int sudia = 0; sudia < 7; sudia++)
                {
                    int[] ids = new int[n];
                    for (int i = 0; i < n; i++)
                        ids[i] = i;

                    Array.Sort(ids, (x, y) => participants[y]._marks[sudia].CompareTo(participants[x]._marks[sudia]));

                    for (int place = 0; place < n; place++)
                    {
                        int participantIndex = ids[place];
                        participants[participantIndex]._places[sudia] = place + 1;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    participants[i]._topPlace = participants[i]._places.Min();
                    participants[i]._totalMark = participants[i]._marks.Sum();
                }

                Array.Sort(participants, (a, b) => a._places[6].CompareTo(b._places[6]));
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, CompareParticipants);
            }

            private static int CompareParticipants(Participant a, Participant b)
            {
                if (a.Score != b.Score)
                    return a.Score.CompareTo(b.Score);

                if (a.TopPlace != b.TopPlace)
                    return a.TopPlace.CompareTo(b.TopPlace);

                return b.TotalMark.CompareTo(a.TotalMark);
            }

            public void Print()
            {
                Console.WriteLine($"{Surname} {Name}: {Score}");
            }
        }

    }
}
