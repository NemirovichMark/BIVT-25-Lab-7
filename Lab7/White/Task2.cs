namespace Lab7.White
{
    public class Task2
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private double _firstJump;
            private double _secondJump;

            private bool _firstJumpSet;
            private bool _secondJumpSet;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;

            public double BestJump
            {
                get
                {
                    return Math.Max(_firstJump, _secondJump);
                }
            }

            // конструктор
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
                if (array == null || array.Length <= 1)
                    return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }
}
