namespace Lab7.Purple
{
    public class Task3

    {
        public class Program
        {
            static void Mains(string[] args)
            {
                Participant D = new Participant("ben", "loh");
                Participant A = new Participant("вова", "ut");
                Participant B = new Participant("rrr", "utr");
                Participant C = new Participant("utyyf", "utr");
                Participant[] participant = new Participant[] { A, B, C, D};
                
            }
        }
        public struct Participant
        {

            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _topplace;
            private double _totalmark;
            private int _nummark;



            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => _marks.ToArray();
            public int[] Places => _places.ToArray();

            public int TopPlace => _topplace;
            public double TotalMark => _totalmark;


            public int Score
            {
                get
                {
                    if (_places == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        sum += _places[i];
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
                _nummark = 0;
                _totalmark = 0;
                _topplace = int.MaxValue;
            }

            public void Evaluate(double result)
            {
                if (_nummark < 7)
                {
                    _marks[_nummark] = result;
                    _nummark++;
                    _totalmark += result;
                }

            }


            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                for (int sud = 0;sud < 7;sud++)
                {
                    for (int i = 0; i < participants.Length -1; i++)
                    {
                        for (int j = 0; j < participants.Length - i - 1; j++)
                        {
                            if (participants[j]._marks[sud] < participants[j+1]._marks[sud])
                            {
                                (participants[j], participants[j + 1]) = (participants[j + 1], participants[j]);
                            }

                        }
                    }
                    for (int i = 0; i < participants.Length; i++)
                    {
                        participants[i]._places[sud] = i + 1;
                        if (sud == 0 || (i + 1) < participants[i]._topplace)
                        {
                            participants[i]._topplace = i + 1;
                        }
                    }
                }
            }
           
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for ( int i =  0; i < array.Length-1; i++ )
                {
                    for (int j = 0; j < array.Length-i-1; j ++)
                    {
                        if (array[j].Score > array[j+1].Score)
                        {
                            (array[j], array[j+1]) = (array[j+1], array[j]);
                        }
                        else if (array[j].Score == array[j + 1].Score)
                        {
                            if (array[j].TopPlace > array[j + 1].TopPlace)
                            {
                                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            }
                            else if (array[j].TopPlace == array[j + 1].TopPlace)
                            {
                                if (array[j].TotalMark < array[j + 1].TotalMark)
                                {
                                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                                }
                            }
                        }
                    }
                }


            }

            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(Score);
                Console.WriteLine(TotalMark);

            }





        }
    }
}