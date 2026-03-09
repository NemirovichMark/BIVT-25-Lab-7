namespace Lab7.White
{
    public class Task2
    {
        public struct Participant{
        private string _name;
        private string _surname;
        private double _firstjump;
        private double _secondjump;
        private int _jumpNo;
        public string Name => _name;
        public string Surname => _surname;
        public double FirstJump => _firstjump;
        public double SecondJump => _secondjump;

        public double BestJump
        {
            get
            {
                if (_firstjump >= _secondjump) return _firstjump;
                return _secondjump;
            }
        }

        public Participant(string name, string surname)
        {
            _name = name;
            _surname = surname;
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
                if (i == 0 || array[i].BestJump <= array[i - 1].BestJump)
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

    
