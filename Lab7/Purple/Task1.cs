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
            
            public string Name =>  _name;
            public string Surname => _surname;

            public double[] Coefs
            {
                get
                {
                    if (_coefs.Length == 0 || _coefs == null) return null;
                    double[] copy = new double[_coefs.Length];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (_marks.Length == 0 || _marks == null) return null;
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
                    double result = 0;
                    for (int jump = 0; jump < 4; jump++)
                    {
                        int[] jumpMarks = new int[7];
                        for (int judge = 0; judge < 7; judge++)
                        {
                            jumpMarks[judge] = _marks[jump, judge];
                        }

                        Array.Sort(jumpMarks);
                        int sum = 0;
                        for (int i = 1; i <= 5; i++)
                        {
                            sum += jumpMarks[i];
                        }

                        result += sum * _coefs[jump];
                    }
                    return result;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];

            }
            public void SetCriterias(double[] coefs)
            {
                Array.Copy(coefs, _coefs, _coefs.Length);
            }
            int jumpNumber = 0;
            public void Jump(int[] marks)
            {
                if (jumpNumber < marks.Length)
                {
                    for (int judge = 0; judge < 7; judge++)
                    {
                        _marks[jumpNumber, judge] = marks[judge];
                    }
                }
                jumpNumber++;
            }
            public void Print()
            {
                Console.WriteLine(Name);
                Console.WriteLine(Surname);
                Console.WriteLine(TotalScore);
                
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                var sorted = array.OrderByDescending(participant => participant.TotalScore).ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] =  sorted[i];
                }
            }
        }
    }
}   
