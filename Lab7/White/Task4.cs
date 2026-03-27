namespace Lab7.White
{
    public class Task4
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private double[] scores;
            public string Name => name;
            public string Surname => surname;
            public double[] Scores
            {
                get
                {
                    double[] copy = new double[scores.Length];
                    Array.Copy(scores, copy, scores.Length);
                    return copy;
                }
            }
            
            public double TotalScore => scores.Sum();
            
            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.scores = new double[0];
            }

            public void PlayMatch(double result)
            {
                Array.Resize(ref scores, scores.Length+1);
                scores[^1] = result;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j+1], array[j]);
                        }
                    }
                }
            }

            public void Print() { }
        }
    }
}
