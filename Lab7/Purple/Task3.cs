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
            private int _markIndex;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => (double[])_marks.Clone();
            public int[] Places => (int[])_places.Clone();
            public int TopPlace => _places.Min();
            public double TotalMark => _marks.Sum();
            public int Score => _places.Sum();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _markIndex = 0;
            }

            public void Evaluate(double result)
            {
                if (result < 0 || result > 6) return;
                _marks[_markIndex++] = result;
            }
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                int judges = participants[0]._marks.Length;
                int numberOfParticipants = participants.Length;
                for (int i = 0; i < judges; i++)
                {
                    var ranked = Enumerable.Range(0, numberOfParticipants)
                        .OrderByDescending(idx => participants[idx]._marks[i])
                        .ThenBy(idx => idx)
                        .ToArray();
                    for (int place = 0; place < numberOfParticipants; place++)
                    {
                        participants[ranked[place]]._places[i] = place+1;
                    }
                }
                var sorted = participants
                    .OrderBy(p => p._places[judges-1])
                    .ToArray();
                Array.Copy(sorted, participants, participants.Length);
            }

            public static void Sort(Participant[] array)
            {
                // if (array == null) return;
                // var sorted = array
                //     .OrderBy(p => p.Score)
                //     .ThenBy(p => p.TopPlace)
                    // .ThenByDescending(p => p.TotalMark)
                //     .ToArray();
                // Array.Copy(sorted, array, array.Length);
                // не работает :(
                int n = array.Length;
                for (int i = 0; i < n-1; i++)
                {
                    for (int j = 0; j < n-i-1; j++)
                    {
                        if (Compare(array[j], array[j+1]) > 0)
                        {
                            (array[j], array[j+1]) = (array[j+1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                System.Console.WriteLine($"{_name} {_surname} {_marks} {_places} {_topPlace} {_totalMark}");
            }

            private static int Compare(Participant a, Participant b)
            {
                int cmp = a.Score.CompareTo(b.Score);
                if (cmp != 0) return cmp;

                cmp = a.TopPlace.CompareTo(b.TopPlace);
                if (cmp != 0) return cmp;

                return b.TotalMark.CompareTo(a.TotalMark);
            }
        }
    }
}