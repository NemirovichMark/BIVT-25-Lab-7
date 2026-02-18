namespace Lab7.White
{
    public class Task4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _score;
            
            public string Name => _name;
            public string Surname => _surname;

            public double[] Scores
            {
                get
                {
                    double[] copy = new double[_score.Length];
                    Array.Copy(_score, 0, copy, 0, _score.Length);
                    return copy;
                }
            }
            public double TotalScore
            {
                get
                {
                    double sum = 0;
                    for (int i = 0; i < _score.Length; i++)
                    {
                        sum += _score[i];
                    }
                    return sum;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _score = new double[0];
            }
            public void PlayMatch(double result)
            {
                Array.Resize(ref _score, _score.Length + 1);
                _score[^1] = result;
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                return;
            }
        }
    }
}
