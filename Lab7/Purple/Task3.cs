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

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => _marks.ToArray();
            public int[] Places => _places.ToArray();
            public int TopPlace => _topPlace;
            public double TotalMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
                        return 0;

                    double total = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        total += _marks[i];
                    }

                    return total;
                }
            }
            public int Score
            {
                get
                {
                    if (_places == null || _places.Length == 0)
                        return 0;

                    int score = 0;
                    for (int i = 0; i < _places.Length; i++)
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
                _marks = new double[7];
                _places = new int[7];
                _topPlace = 8;
            }

            public void Evaluate(double result)
            {
                if (result < 0.0 || result > 6.0)
                    return;

                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0.0)
                    {
                        _marks[i] = result;
                        return;
                    }
                }
            }
            public static void SetPlaces(Participant[] participants)
            {
                for (int judge = 0; judge < 7; judge++)
                {
                    for (int participant = 0; participant < participants.Length; participant++)
                    {
                        int place = 1;
                        for (int i = 0; i < participants.Length; i++)
                        {
                            if (participants[i]._marks[judge] > participants[participant]._marks[judge])
                                place++;
                        }
                        participants[participant]._places[judge] = place;

                        if (place < participants[participant]._topPlace)
                            participants[participant]._topPlace = place;
                    }
                }

                for (int i = 0; i < participants.Length; i++)
                {
                    for (int j = 1; j < participants.Length; j++)
                    {
                        if (participants[j - 1]._places[6] > participants[j]._places[6])
                            (participants[j - 1]._places[6], participants[j]._places[6]) = (participants[j]._places[6], participants[j - 1]._places[6]);
                    }
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length; j++)
                    {
                        bool swap = false;

                        if (array[j - 1].Score > array[j].Score)
                        {
                            swap = true;
                        }
                        else if (array[j - 1].Score == array[j].Score)
                        {
                            if (array[j - 1].TopPlace > array[j].TopPlace)
                            {
                                swap = true;
                            }
                            else if (array[j - 1].TopPlace == array[j].TopPlace)
                            {
                                if (array[j - 1].TotalMark < array[j].TotalMark)
                                {
                                    swap = true;
                                }
                            }
                        }

                        if (swap)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Participant: {Name} {Surname}");
                Console.WriteLine($"Score: {Score}");
            }
        }
    }
}
