using System.Reflection.Metadata.Ecma335;
using static Lab7.Purple.Task1;

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
            private int _jump;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return new double[0];
                    return (from i in _coefs select i).ToArray();
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return new int[0, 0];
                    int[,] clone = new int[4, 7];
                    for(int i = 0; i < 4; i++)
                    {
                        for(int j = 0; j < 7; j++)
                        {
                            clone[i, j] = _marks[i, j];
                        }
                    }
                    return clone;
                }
            }
            public double TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    double sum = 0;
                    for(int i = 0; i < 4; i++)
                    {
                        int localSum = 0;
                        int localMin = 7, localMax = -1;
                        for(int j = 0; j < 7; j++)
                        {
                            localSum += _marks[i, j];
                            localMin = Math.Min(_marks[i, j], localMin);
                            localMax = Math.Max(_marks[i, j], localMax);
                        }
                        localSum -= localMin;
                        localSum -= localMax;
                        sum += (double)localSum * _coefs[i];
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                for(int i = 0; i < 4; i++) _coefs[i] = 2.5;
                _marks = new int[4, 7];
                for(int i = 0; i < 4 * 7; i++) _marks[i % 4, i / 4] = 0;
                _jump = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                if (_coefs == null) return; 
                for(int i = 0; i < 4; i++) _coefs[i] = coefs[i];
            }
            public void Jump(int[] marks)
            {
                if (_marks == null) return;
                for(int i = 0; i < 7; i++) _marks[_jump, i] = marks[i];
                _jump++;
            }
            public static void Sort(Participant[] array)
            {
                var NewArray = (from i in array
                                orderby -i.TotalScore
                                select i).ToArray();
                for(int i = 0;i < NewArray.Length; i++)
                {
                    array[i] = NewArray[i];
                }

            }
            public void Print()
            {
                Console.Write($"{_name, 10} {_surname, 10} - {Math.Round(TotalScore, 3), 7}");
                return;   
            }
            //public void PrintInfo()
            //{
            //    Console.WriteLine($"{Name} {Surname}");
            //    for(int i = 0; i < 4; i++)
            //    {
            //        int min = 0, max = 0;
            //        double sum = 0;
            //        for(int j = 0; j < 7; j++)
            //        {
            //            if (_marks[i, min] > _marks[i, j]) min = j;
            //            if (_marks[i, max] < _marks[i, j]) max = j;
            //            sum += _marks[i, j];
            //        }
            //        sum -= _marks[i, min] + _marks[i, max];
            //        for(int j = 0; j < 7; j++)
            //        {
            //            if(j == min || j == max) Console.ForegroundColor = ConsoleColor.DarkGray;
            //            Console.Write($"{_marks[i, j], 3} ");
            //            Console.ForegroundColor = ConsoleColor.White;
            //        }
            //        Console.Write($" = ");
            //        Console.ForegroundColor= ConsoleColor.Red;
            //        Console.Write($"{Math.Round(sum, 2),3}");
            //        Console.ForegroundColor= ConsoleColor.White;
            //        Console.Write($" * ");
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.Write($"{Math.Round(_coefs[i], 2), 4 } ");
            //        Console.ForegroundColor = ConsoleColor.White;
            //        Console.WriteLine($"{Math.Round(sum * _coefs[i], 3), 6}");
            //    }
            //    Console.WriteLine($"{Math.Round(TotalScore, 3),48}");
            //}
            
        }
    }
}