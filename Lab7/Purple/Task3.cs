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

            private int _countMarks = 0;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks {
                get
                {
                    double[] copyArray = new double[_marks.Length];
                    Array.Copy(_marks, copyArray, _marks.Length);
                    return copyArray;
                }
            }

            public int[] Places
            {
                get
                {
                    int[] copyArray = new int[_places.Length];
                    Array.Copy(_places, copyArray, _places.Length);
                    return copyArray;
                }
            }

            public int TopPlace => _places.Min();
            public double TotalMark => _marks.Sum();
            public int Score => _places.Sum();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _topPlace = 0;
                _totalMark = 0;
            }

            public void Evaluate(double result)
            {
                _marks[_countMarks] = result;
                _countMarks++;
            }


            //referee 1    2   n     places[]
            //parp_1.marks   [2,5; 4,5 ...]   0  => 1  => logic by marks
            //parp_2.marks   [1,1; 2,1 ...]   0  => 1  => logic by marks
            public static void SetPlaces(Participant[] participants)
            {
                for (int referee = 0; referee < 7; referee++)
                {
                    for (int partp = 0; partp < participants.Length; partp++)
                    {
                        //Прибавим 1, так как места у каждого судьи начинает с 1 и заканчиваются 7
                        participants[partp]._places[referee] += 1;
                        for (int j = 0; j < participants.Length; j++)
                        {
                            if (participants[partp]._marks[referee] < participants[j]._marks[referee])
                                participants[partp]._places[referee] += 1;
                        }
                    }
                }

                var sortedArray = participants.OrderBy(x => x._places[^1]).ToArray();

            }

            public static void Sort(Participant[] participants)
            {
                var sortedArray = participants.OrderBy(x => x.Score).ThenBy(x => x.TopPlace).ThenByDescending(x => x.TotalMark).ToArray();
                for (int i = 0; i < participants.Length; i++)
                {
                    participants[i] = sortedArray[i];
                }
            }

            public void Print()
            {
                Console.WriteLine(string.Join(" ", _places));
                Console.WriteLine(TopPlace);
                Console.WriteLine(TopPlace);
                Console.WriteLine(Score);
            }
        }

    }
}