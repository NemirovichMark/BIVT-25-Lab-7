namespace Lab7.Purple
{
    public class Task1
    {
        public struct Participant
        {
            //Поля
            private int _currentjump;
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            //Свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs => _coefs.ToArray();
            public int[,] Marks
            {
                get
                {
                    return (int[,])_marks.Clone();
                }
            }
            public double TotalScore
            {
                get
                {
                    double score = 0;
                    for(int jump = 0; jump < 4;  jump++)
                    {
                        int JumpScore = 0;
                        int HighestMark = -100, LowestMark = 100;
                        for (int mark = 0; mark < 7; mark++)
                        {
                            JumpScore += _marks[jump, mark];
                            if (_marks[jump, mark] > HighestMark)
                            {
                                HighestMark = _marks[jump, mark];
                            }
                            if (_marks[jump, mark] < LowestMark)
                            {
                                LowestMark = _marks[jump, mark];
                            }
                        }
                        score += (JumpScore - HighestMark - LowestMark) * _coefs[jump];
                    }
                    return score;
                }
            }
            //Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] {2.5,2.5,2.5,2.5};
                _marks = new int[4, 7]
                {
                    {0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0 }
                };
                _currentjump = 0;
            }
            //Методы
            public void SetCriterias(double[] coefs)
            {
                _coefs = coefs;
            }
            public void Jump(int[] marks)
            {
                for (int mark = 0; mark < 7;  mark++)
                {
                    _marks[_currentjump, mark] = marks[mark];
                }
                _currentjump++;
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j>0 && array[j].TotalScore > array[j-1].TotalScore;j--)
                    {
                        (array[j], array[j-1])=(array[j-1], array[j]);
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}\n Фамилия:{_surname}\nРезультат:{TotalScore}");
            }
        }
    }
}
