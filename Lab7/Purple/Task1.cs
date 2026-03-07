using System.Security.Cryptography.X509Certificates;

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
        private int _currentJump;       

        
        public string Name => _name;
        public string Surname => _surname;
        public double[] Coefs => _coefs.ToArray();
            public int[,] Marks
            {
                get
                {
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < copy.GetLength(0); i++)
                    {
                        for (int j = 0; j < copy.GetLength(1); j++)
                        {
                            copy[i,j] = _marks[i, j];
                        }
                    }
                    return copy;
                }
            }
            


            public double TotalScore
            {
                get
                {
                    

                    double total = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        int sum = 0;
                        int min = _marks[i, 0];
                        int max = _marks[i, 0];

                        for (int j = 0; j < 7; j++)
                        {
                            int mark = _marks[i, j];
                            sum += mark;

                            if (mark < min) min = mark;
                            if (mark > max) max = mark;
                        }

                        sum -= min + max;
                        total += sum * _coefs[i];
                    }

                    return total;
                }
            }


            public Participant(string name, string surname)
        {
            _name = name;
            _surname = surname;

            _coefs = new double[4];
            _marks = new int[4, 7];
            _currentJump = 0;

            
            for (int i = 0; i < 4; i++)
                _coefs[i] = 2.5;

            
        }

        
        public void SetCriterias(double[] coefs)
        {
            

            for (int i = 0; i < 4; i++)
                _coefs[i] = coefs[i];
        }

       
        public void Jump(int[] marks)
        {
            

            if (_currentJump >= 4)
                throw new InvalidOperationException("Все 4 прыжка уже выполнены");

            for (int i = 0; i < 7; i++)
                _marks[_currentJump, i] = marks[i];

            _currentJump++;
        }

        
        public static void Sort(Participant[] array)
        {
            Array.Sort(array, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
        }

        // Вывод информации
        public void Print()
        {
            Console.WriteLine($"{_surname} {_name} - Итог: {TotalScore:F2}");
        }
    
        
        
        
        
        
        
        
        }






}
}
