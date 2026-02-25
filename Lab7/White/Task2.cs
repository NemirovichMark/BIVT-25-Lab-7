namespace Lab7.White
{
    public class Task2
    {
        public struct Participant
        {
            //создаем поля
            private string _name;
            private string _surname;
            private double _firstjump;
            private double _secondjump;

            //свойства 
            public string Name => _name;
            public string Surname => _surname;
            public double FirstJump => _firstjump;
            public double SecondJump => _secondjump;

            public double BestJump
            {
                get
                {
                    if(_firstjump == 0 && _secondjump==0)
                        return 0;
                    else if (_firstjump !=0&&_secondjump ==0)
                        return FirstJump;
                    else if (_secondjump !=0 && _firstjump==0)
                        return SecondJump;
                    else
                        return Math.Max(_firstjump,_secondjump);

                }
            }
            //конструктор из 2 строк поля
            public Participant(string name,string surname)
            {
                _name= name;
                _surname= surname;
            }
            //метод
            public void Jump(double result)
            {
                if (_firstjump == 0)
                {
                    _firstjump = result;
                }
                else if (_secondjump == 0)
                {
                    _secondjump = result;
                }

            }
            public static void Sort(Participant[] array)
            {
                if (array == null|| array.Length==0)
                    return ;
                for (int i = 0; i < array.Length; i++)
                {
                    for(int j = 1;j< array.Length; j++)
                    {
                        if (array[j - 1].BestJump < array[j].BestJump)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);

                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(_firstjump);
                Console.WriteLine(_secondjump);
                Console.WriteLine(BestJump);
            }
        }

    }
}
