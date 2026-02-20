using System.Net.Http.Headers;

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
            private int _indexOfJump;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                // Создаем копию для возврата, чтобы исходные параметры в массиве не могли быть изменены
                get
                { 
                    double[] copyCoefs = new double[_coefs.Length];
                    Array.Copy(_coefs, copyCoefs, _coefs.Length);
                    return copyCoefs;
                }
            }
            public int[,] Marks
            {
                // Создаем копию для возврата, чтобы исходные параметры в массиве не могли быть изменены
                get
                {
                    int rows = _marks.GetLength(0);
                    int cols = _marks.GetLength(1);

                    int[,] copyMarks = new int[rows, cols];
                    Array.Copy(_marks, copyMarks, _marks.Length);
                    return copyMarks;
                }
            }
            

            public double TotalScore
            {
                get
                {
                    double resSum = 0;
                    int numsOfJumps = 4;
                    int numsOfReferee = 7;
                    

                    for (int row = 0; row < numsOfJumps; row++)
                    {
                        int[] jump = new int[7];
                        int index = 0;
                        double sumForJump = 0;

                        for (int col = 0; col < 7; col++)
                        {
                            jump[index++] = _marks[row, col];
                        }

                        Array.Sort(jump);

                        for (int i = 1; i < numsOfReferee - 1; i++)
                            sumForJump += jump[i];
                        resSum += sumForJump * _coefs[row];
                    }

                    double approxResSum = Math.Round(resSum, 2);
                    return approxResSum;

                }
            }

            public Participant(string name, string surname)
            {

                _name = name;
                _surname = surname;
                const double firstCoef = 2.5;

                _coefs = new double[4];
                for (int i = 0; i < _coefs.Length; i++)
                    _coefs[i] = firstCoef;
                _marks = new int[4, 7];
                _indexOfJump = 0;
                Console.WriteLine(string.Join(" ", _coefs));
            }

            public void SetCriterias(double[] coefs)
            {
                for (int i = 0; i < coefs.Length; i++)
                    _coefs[i] = coefs[i];
            }

            public void Jump(int[] marks)
            {
                int cols = _marks.GetLength(1);
                for (int col = 0; col < cols && _indexOfJump < 4; col++)
                    _marks[_indexOfJump, col] = marks[col];
                _indexOfJump++;
            }

            public static void Sort(Participant[] array)
            {
                var resArray = array.OrderByDescending(x => x.TotalScore).ToArray();
                // Присвоение значений в массив делаем через цикл, потому что array это локальная копия (был бы ref можно было просто приравнять ссылки)
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = resArray[i];
                    
                }
            }

            public void Print()
            {
                Console.WriteLine($" Name: {_name} \n Surname: {_surname} \n Result: {TotalScore}");
                Console.WriteLine();
                Console.WriteLine(string.Join(" ", _coefs));
            }
        }

        
    }
}