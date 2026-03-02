using static System.Formats.Asn1.AsnWriter;

namespace Lab7.White
{
    public class Task4
    {
        public struct Participant
        {
            //Поля
            private string _name;
            private string _surname;
            private double[] _scores;

            //Свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Scores
            {
                get
                {
                    double[] w = new double[_scores.Length];
                    Array.Copy(_scores, 0, w, 0, _scores.Length);
                    return w;
                }
            }
            public double TotalScore
            {
                get
                {
                    double x = 0;
                    for (int i=0; i < _scores.Length; i++) x+= _scores[i];
                    return x;
                }
            }

            //Конструктор 
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _scores = new double[0];
            }
            //Методы
            public void PlayMatch(double result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
                
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
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
