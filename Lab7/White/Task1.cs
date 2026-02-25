namespace Lab7.White
{
    public class Task1
    {
        public struct Participant
        {
            //создаем поля
            private string _surname;
            private string _club;
            private double _firstjump;
            private double _secondjump;


            //свойства только для чтения 
            public string Surname=>_surname;
            public string Club => _club;
            public double FirstJump => _firstjump;
            public double SecondJump => _secondjump;

            public double JumpSum
            {
                get
                {
                    return _firstjump + _secondjump;
                }
            }
            //создаем конструктор 
            public Participant(string surname,string club)
            {
                //проинициализируем 2 строки поля
                _surname = surname;
                _club = club;
            }
            //создаем метод
            public void Jump(double result)
            {
                if (_firstjump==0)
                {
                    _firstjump = result;
                }
                else if (_secondjump==0)
                {
                    _secondjump = result;
                }

            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0)
                    return;
                // сорт по убыванию
                for (int i = 0; i < array.Length; i++)
                {
                    for(int j = 1;j<array.Length;j++)
                    {
                        if (array[j - 1].JumpSum < array[j].JumpSum)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }

                }
            }
            public void Print()
            {
                Console.WriteLine(_surname);
                Console.WriteLine(_club);
                Console.WriteLine(_firstjump);
                Console.WriteLine(_secondjump);
                Console.WriteLine(JumpSum);
            }
        }
    }
}
