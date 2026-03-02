namespace Lab7.White
{
    public class Task2
    {
        public struct Participant
        {
            //Поля
            private string _name;
            private string _surname;
            private double first_jump;
            private double second_jump;
            private bool flag_first_jump;
            private bool flag_second_jump;

            //Свойства
            public string Name => _name;
            public string Surname => _surname;
            public double FirstJump => first_jump;
            public double SecondJump => second_jump;
            public double BestJump => Math.Max(first_jump,second_jump);
            //Конструктор 
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }

            //Методы
            public void Jump(double result)
            {
                if (!flag_first_jump)
                {
                    first_jump = result;
                    flag_first_jump = true;
                }
                else if (!flag_second_jump)
                {
                    second_jump = result;
                    flag_second_jump = true;
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
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
