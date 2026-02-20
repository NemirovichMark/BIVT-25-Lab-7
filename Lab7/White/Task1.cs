namespace Lab7.White
{
    public class Task1
    {
        public struct Participant
        {
            private string _surname;
            private string _club;
            private double _firstJump;
            private double _secondJump;
            private bool _IsFirstJump;
            private bool _IsSecondJump;
            
            public string Surname => _surname;
            public string Club => _club;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double JumpSum =>  _firstJump + _secondJump;
            
            public Participant(string surname, string club)
            {
                _surname = surname;
                _club = club;
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
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].JumpSum < array[j + 1].JumpSum)
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
