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
            private int _jumpIndex;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    var coefs = new double[4];
                    for (int i = 0; i<4; i++)
                        coefs[i] = _coefs[i];
                    
                    return coefs;
                }
                
            }
            public int[,] Marks
            {
                get
                {
                    var marks = new int[4,7];
                    for (int i =0;i<4;i++)
                        for (int j =0;j<7;j++)
                            marks[i,j] = _marks[i,j];
                    
                    return marks;
                }
            }
            public double TotalScore
            {
                get
                {
                    double total = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        double sum = 0;
                        int min = int.MaxValue;
                        int max = int.MinValue;
                        for (int j = 0; j < 7; j++)
                        {
                            if (_marks[i,j]<min) min = _marks[i,j];
                            if (_marks[i,j]>max) max = _marks[i,j];
                            sum += _marks[i,j];
                        }
                        sum -= min+max;
                        total += sum * _coefs[i];
                    }
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4]{2.5,2.5,2.5,2.5};
                _marks = new int[4,7];
                _jumpIndex = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs.Length!=4|| coefs == null) return;
                for(int i = 0; i < 4; i++)
                    if (coefs[i]<2.5 || coefs[i]>3.5) return;
                
                for (int i = 0; i < 4; i++)
                    _coefs[i] = coefs[i];
            }
            public void Jump(int[] marks)
            {
                if (_jumpIndex>=4) return;
                if (marks.Length!=7 || marks == null) return;
                for (int i =0;i<7;i++)
                    if (marks[i]<0 || marks[i]>6) return;

                for (int i =0;i<7;i++)
                    _marks[_jumpIndex,i] = marks[i];
                
                _jumpIndex++;
            }
            public  static  void  Sort(Participant[] array)
            {
                if (array.Length<2 || array == null) return;
                int l = 1;
                while (l < array.Length)
                {
                    if (l == 0 || array[l-1].TotalScore >= array[l].TotalScore) l++;
                    else
                    {
                        (array[l-1],array[l]) = (array[l],array[l-1]);
                        l--;
                    }
                }
            }
            
            public void Print ()
            {
                System.Console.WriteLine("__________Participant___________");
                System.Console.WriteLine($"Name: {_name}; Surname: {_surname}");
                System.Console.WriteLine($"Coef: {string.Join(" ",_coefs)}");
                System.Console.WriteLine($"TotalScore: {TotalScore}");
                System.Console.WriteLine("Marks: ");
                System.Console.WriteLine();
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        System.Console.Write($"{_marks[i,j],5}");
                    }
                    System.Console.WriteLine();
                }
            }
        }
    }
}
