using System.Security.Cryptography;

namespace Lab7.Purple
{
    public class Task1
    {
        
        public struct Participant
        {

            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _num_jump;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs.Length == 0 || _coefs == null) return null;
                    else
                    {
                        return _coefs.ToArray();
                    }
                }


            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) == 0) return null;
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            copy[i, j] = _marks[i, j];
                        }
                    }
                    return copy;
                }


            }
            public double TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    else
                    {

                        double res = 0;

                        for (int i = 0; i < _marks.GetLength(0); i++)
                        {
                            double locmax = double.MinValue;
                            double locmin = double.MaxValue;
                            double locres = 0;
                            for (int j = 0; j < _marks.GetLength(1); j++)
                            {
                                locres += _marks[i, j];
                                if (_marks[i, j] > locmax)
                                {

                                    locmax = _marks[i, j];
                                }
                                if (_marks[i, j] < locmin)
                                {

                                    locmin = _marks[i, j];
                                }
                            }
                            res += (locres - locmax - locmin) * _coefs[i];

                        }
                        return res;
                    }
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _num_jump = 0;

            }
            public void SetCriterias(double[] coefs)
            {
                if (_coefs == null) return;
                else
                {
                    for ( int i = 0; i < _coefs.Length; i++)
                    {
                        _coefs[i] = coefs[i];
                    }
                }
            }
            public void Jump(int[] marks)
            {

                if (4 > _num_jump)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        _marks[_num_jump, j] = marks[j];
                    }

                }
                _num_jump++;

            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                var s = array.OrderByDescending(participant => participant.TotalScore).ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = s[i];
                }

            }
            public void Print()
            {
                Console.WriteLine(Name);
                Console.WriteLine(Surname);
                Console.WriteLine(TotalScore);
            }
        }
    }
}