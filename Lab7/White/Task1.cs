namespace Lab7.White
{
    public class Task1
    {
        public struct Participant
        {
             // Поля
            private string _surname;
            private string _club;
            private double _firstJump;
            private double _secondJump;
            private bool _firstJumpSet;     // Necesario para saber si ya se estableció
            private bool _secondJumpSet;    // Necesario para saber si ya se estableció
            // Свойства
            public string Surname => _surname;
            public string Club => _club;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double JumpSum
            {
                get
                {
                    double sum = _firstJump + _secondJump;
                    return sum;
                }
            }
            // Конструстор
            public Participant(string surname,string club)
            {
                _surname = surname;
                _club = club;
                _firstJump = 0;
                _secondJump = 0;
                _firstJumpSet = false;      // Inicialmente no hay primer salto
                _secondJumpSet = false;     // Inicialmente no hay segundo salto
            }
            public void Jump(double result)
            {
                if (!_firstJumpSet)
                {
                    _firstJump = result;
                    _firstJumpSet = true;
                }
                else if (!_secondJumpSet)
                {
                    _secondJump = result;
                    _secondJumpSet = true;
                }
            }
            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.JumpSum.CompareTo(a.JumpSum));
            }
            public void Print()
            {
                Console.WriteLine($"Suername: {_surname}");
                Console.WriteLine($"Club: {_club}");
                Console.WriteLine($"First jump: {_firstJump:F2}");
                Console.WriteLine($"Second jump: {_secondJump:F2}");
                Console.WriteLine($"Sum: {JumpSum:F2}");
                Console.WriteLine("------------------------");
            }
        }

    }
}