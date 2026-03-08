namespace Lab7.White
{
    public class Task4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _scores;
            private int _scoreCount;

            public string Name => _name;
            public string Surname => _surname;

            public double[] Scores
            {
                get
                {
                    double[] result = new double[_scoreCount];
                    for (int i = 0; i < _scoreCount; i++)
                        result[i] = _scores[i];
                    return result;
                }
            }

            public double TotalScore
            {
                get
                {
                    double sum = 0;
                    for (int i = 0; i < _scoreCount; i++)
                        sum += _scores[i];
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _scores = new double[100];
                _scoreCount = 0;
            }

            public void PlayMatch(double result)
            {
                _scores[_scoreCount] = result;
                _scoreCount++;
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }

            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.Write("Scores: ");
                for (int i = 0; i < _scoreCount; i++)
                    Console.Write(_scores[i] + " ");
                Console.WriteLine();
                Console.WriteLine($"Total score: {TotalScore}");
                Console.WriteLine("------------------------");
            }
        }
    }
}
