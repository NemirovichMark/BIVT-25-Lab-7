namespace Lab7.White
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double _firstJump;
            private double _secondJump;
            private bool _firstJumpSet;
            private bool _secondJumpSet;

            public string Name => _name;
            public string Surname => _surname;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;

            public double BestJump
            {
                get
                {
                    double best = 0;
                    if (_firstJumpSet && _firstJump > best)
                        best = _firstJump;
                    if (_secondJumpSet && _secondJump > best)
                        best = _secondJump;
                    return best;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _firstJump = 0;
                _secondJump = 0;
                _firstJumpSet = false;
                _secondJumpSet = false;
            }

            public void Jump(double result)
            {
                if (_firstJumpSet == false)
                {
                    _firstJump = result;
                    _firstJumpSet = true;
                }
                else if (_secondJumpSet == false)
                {
                    _secondJump = result;
                    _secondJumpSet = true;
                }
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.BestJump.CompareTo(a.BestJump));
            }

            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.WriteLine($"First jump: {_firstJump}");
                Console.WriteLine($"Second jump: {_secondJump}");
                Console.WriteLine($"Best jump: {BestJump}");
                Console.WriteLine("------------------------");
            }
        }
    }
}
