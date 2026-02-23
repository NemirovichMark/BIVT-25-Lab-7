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
            private int _marksCount;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => _marks.ToArray();
            public int[] Places => _places.ToArray(); 
            public int TopPlace => _topPlace;
            public double TotalMark => _totalMark;

            public int Score
            {
                get
                {
                    int sum = 0;
                    foreach (var p in _places) sum += p;
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _topPlace = 0;
                _totalMark = 0;
                _marksCount = 0;
            }

            public void Evaluate(double result)
            {
                if (_marksCount < 7)
                {
                    _marks[_marksCount] = result;
                    _totalMark += result;
                    _marksCount++;
                }
            }

            public static void SetPlaces(Participant[] participants)
            {
                int n = participants.Length;
                for (int j = 0; j < 7; j++)
                {
                    int[] indices = new int[n];
                    for (int i = 0; i < n; i++) indices[i] = i;

                    Array.Sort(indices, (a, b) => participants[b].Marks[j].CompareTo(participants[a].Marks[j]));

                    for (int rank = 0; rank < n; rank++)
                    {
                        int participantIndex = indices[rank];
                        int place = rank + 1;
                        participants[participantIndex]._places[j] = place;

                        if (j == 0 || place < participants[participantIndex]._topPlace)
                        {
                            participants[participantIndex]._topPlace = place;
                        }
                    }
                }

                Array.Sort(participants, (a, b) => a._places[6].CompareTo(b._places[6]));
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    Participant key = array[i];
                    int j = i - 1;

                    while (j >= 0 && ShouldSwap(array[j], key))
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = key;
                }
            }

            private static bool ShouldSwap(Participant left, Participant right)
            {
                if (left.Score > right.Score) return true;
                if (left.Score < right.Score) return false;

                if (left.TopPlace > right.TopPlace) return true;
                if (left.TopPlace < right.TopPlace) return false;

                if (left.TotalMark < right.TotalMark) return true;

                return false;
            }

            public void Print()
            {
                Console.WriteLine($"{Surname} {Name}: Score {Score}, Top {TopPlace}, Total {TotalMark:F2}");
            }
        }
    }
}
