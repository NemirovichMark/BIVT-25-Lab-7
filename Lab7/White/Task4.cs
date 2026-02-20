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
                    if(_scores == null || _scores.Length == 0)
                        return new double[0];
                    double[] copy = new double[_scores.Length];
                    for( int i = 0; i<_scores.Length; i++)
                    {
                        copy[i] = _scores[i];
                    }
                    return copy;
                }

            }
            public double TotalScore
            {
                get
                {
                    double total = 0;
                    for(int i = 0; i < _scores.Length; i++)
                    {
                        total+=_scores[i];
                    }
                    return total;
                }
            }
            public Participant(string name,string surname)
            {
                _name = name;
                _surname = surname;
                _scores = [];
            }
            public void PlayMatch (double result)
            {
                if ( result != 1 || result != 0.5 || result != 0)
                {
                    Console.Write("The result must be 1, 0.5 or 0");
                }
                else
                {
                    int currentLength = _scores.Length;
                    Array.Resize(ref _scores, currentLength + 1);
                    _scores[currentLength] = result;
                }

            }
            public static void Sort(Participant[] array)
            {
                for(int i = 0; i < array.Length - 1; i++)
                {
                    for( int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.WriteLine("Scores: ");
                for (int i = 0; i < _scores.Length; i++)
                {
                    Console.WriteLine($"{i+1}° Game: {_scores[i]}");

                }
                Console.WriteLine($"Total Score: {TotalScore}");
                Console.WriteLine("------------------------");
            }
        }
    }
}