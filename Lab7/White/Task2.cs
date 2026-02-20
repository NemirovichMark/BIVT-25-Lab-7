namespace Lab7.White
{
    public class Task2
    {
        public struct Participant
        {
            private string _surname;
            private string _name;
            private double _firstJump;
            private double _secondJump;
            private bool _IsFirstJump;
            private bool _IsSecondJump;
            
            public string Surname => _surname;
            public string Name => _name;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double BestJump
            {
                get
                {
                    if (_firstJump > _secondJump)
                    {
                        return _firstJump;
                    }
                    else
                    {
                        return _secondJump;
                    }
                }
            }
            public Participant(string name, string surname)
            {
                _surname = surname;
                _name = name;
                _firstJump = 0;
                _secondJump = 0;
                _IsFirstJump = false;
                _IsSecondJump = false;
            }
            public void Jump(double result)
            {
                if (!_IsFirstJump)
                {
                    _firstJump = result;
                    _IsFirstJump = true;
                }
                else if (!_IsSecondJump)
                {
                    _secondJump = result;
                    _IsSecondJump = true;
                }
            }
    
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
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
