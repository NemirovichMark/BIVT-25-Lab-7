using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

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
            private int _jumpNo;
            public string Name => _name;
            public string Surname => _surname;

            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] coefs = new double[_coefs.Length];
                    for (int i = 0; i < _coefs.Length; i++)
                    {
                        coefs[i] = _coefs[i];
                    }

                    return coefs;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            marks[i, j] = _marks[i, j];
                        }
                    }

                    return marks;
                }
            }
            public double TotalScore
            {
                get
                {
                    double sum = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        int jmax = 0;
                        for (int j = 1; j < _marks.GetLength(1); j++)
                        {
                            if (_marks[i, j] > _marks[i, jmax])
                            {
                                jmax = j;
                            }
                        }

                        int jmin = 0;
                        for (int j = 1; j < _marks.GetLength(1); j++)
                        {
                            if (_marks[i, j] < _marks[i, jmin])
                            {
                                jmin = j;
                            }
                        }

                        double tmp = 0;
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            if (j == jmax || j == jmin) continue;
                            tmp += _marks[i, j];
                        }

                        sum += tmp * _coefs[i];
                    }
                
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _jumpNo = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length != _coefs.Length) return;
                for (int i = 0; i < coefs.Length; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }
            
            public void Jump(int[] marks)
            {
                if (marks == null || marks.Length != _marks.GetLength(1)) return;
                if (_jumpNo < 4)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        _marks[_jumpNo, j] = marks[j];
                    }

                    _jumpNo++;
                }
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

            public void Print()
            {
                Console.WriteLine($"Name: {Name}\nSurname: {Surname},\nTotalScore: {TotalScore}");
            }
        }
    }
}
