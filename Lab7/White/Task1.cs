namespace Lab7.White
{
    public class Task1
    {

        public struct Participant
        {
            private string _surname;
            private string _club;
            private double _firstjump;
            private double _secondjump;
            private int _jumpNo;
            public string Surname => _surname;
            public string Club => _club;
            public double FirstJump => _firstjump;
            public double SecondJump => _secondjump;

            public double JumpSum => _firstjump + _secondjump;

            public Participant(string surname, string club)
            {
                _surname = surname;
                _club = club;
                _jumpNo = 0;
            }

            public void Jump(double result)
            {
                _jumpNo++;
                if (_jumpNo == 1)
                {
                    _firstjump = result;
                }
                else if (_jumpNo == 2)
                {
                    _secondjump = result;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                int i = 0;
                while (i < array.Length)
                {
                    if (i == 0 || array[i].JumpSum <= array[i - 1].JumpSum)
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
            public void Print() { }
        }
    }
}
  