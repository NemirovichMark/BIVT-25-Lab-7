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
            private int _currentJump;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => _marks.ToArray();
            public int[] Places => _places.ToArray();
            public int TopPlace
            {
                get
                {
                    int topPlace = Int32.MaxValue;
                    foreach(int i  in _places)
                    {
                        topPlace = Math.Min(topPlace, i);
                    }
                    return topPlace;
                }
            }
            public double TotalMark
            {
                get
                {
                    double sum = 0;
                    foreach (double i in _marks)
                    {
                        sum += i;
                    }
                    return sum;
                }
            }
            public int Score
            {
                get
                {
                    int sum = 0;
                    foreach (int i in _places)
                    {
                        sum += i;
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _currentJump = 0;
            }

            public void Evaluate(double result)
            {
                if (_currentJump < 7)
                {
                    _marks[_currentJump++] = result; 
                }
            }
            public static void SetPlaces(Participant[] participants)
            {
                for (int judge = 0; judge < 7;  judge++)
                {
                    for (int i = 0;  i < participants.Length; i++)
                    {
                        for (int j = i; j>0 && participants[j]._marks[judge]> participants[j-1]._marks[judge]; j--)
                        {
                            (participants[j], participants[j - 1]) = (participants[j - 1], participants[j]);
                        }
                    }
                    for (int place = 0; place < participants.Length; place++)
                    {
                        participants[place]._places[judge] = place +1;
                    }
                }
            }
            private static bool Swap(Participant participant1, Participant participant2)
            {
                bool swap = false;
                if (participant1.Score < participant2.Score)
                    swap = true;
                else if (participant1.Score == participant2.Score && participant1.TopPlace < participant2.TopPlace)
                    swap = true;
                else if (participant1.Score == participant2.Score && participant1.TopPlace == participant2.TopPlace && participant1.TotalMark > participant2.TotalMark)
                    swap = true;
                return swap;
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length;i++)
                {
                    for (int j = i; j > 0 && Swap(array[j], array[j-1]);j--)
                    {
                        (array[j], array[j-1]) = (array[j-1], array[j]);
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {this.Score}");
            }
        }
    }
}
