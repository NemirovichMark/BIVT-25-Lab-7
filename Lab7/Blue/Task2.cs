namespace Lab7.Blue
{
    public class Task2
    {

        public struct Participant
        {

            private string _name;

            private string _surname;

            private int[,] _marks;
            
            private int _jumpNumber;

            public string Name => _name;
            public string Surname => _surname;

            public int[,] Marks
            {
                get
                {
                    int[,] copy = new  int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            sum += _marks[i, j];
                        }
                    }

                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _jumpNumber = 0;
            }
            
            public void Jump(int[] result)
            {
                if (_jumpNumber >= _marks.GetLength(0))
                    return;
                
                for (int i = 0; i <result.Length; i++)
                {
                    _marks[_jumpNumber, i] = result[i];
                }
                
                _jumpNumber++;
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }
            
            public void Print() {}
            
        }
        
    }
    
}