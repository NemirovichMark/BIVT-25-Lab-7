namespace Lab7.White
{
    public class Task4
    {

        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _scores;
            public string Name => _name;
            public string Surname => _surname;

            public double[] Scores
            {
                get
                {
                    if (_scores == null) return null;
                    double[] scores = new double[_scores.Length];
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        scores[i] = _scores[i];
                    }

                    return scores;
                }
            }

            public double TotalScore
            {
                get
                {
                    if (_scores == null) return default(double);
                    double ans = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        ans += _scores[i];
                    }

                    return ans;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _scores = new double[0];
            }

            public void PlayMatch(double result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                int i = 0;
                while (i < array.Length)
                {
                    if (i == 0 || array[i].TotalScore <= array[i - 1].TotalScore)
                    {
                        i++;
                    }
                    else
                    {
                        Participant tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                        i--;
                    }
                }
            }
            public void Print() { }
        }
    }
}
