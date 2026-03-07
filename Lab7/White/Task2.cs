using System.Collections.Immutable;
using System.Collections.Specialized;

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

            public string Name => _name;
            public string Surname => _surname;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;

            public double BestJump
            {
                get
                {
                    if (FirstJump < SecondJump)
                        return SecondJump;
                    else
                        return FirstJump;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _firstJump = 0;
                _secondJump = 0;

            }

            public void Jump(double result)
            {
                if (_firstJump == 0)
                {
                    _firstJump = result;
                }
                else if (_secondJump == 0)
                {
                    _secondJump = result;
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j+1].BestJump)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;

                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} +{_surname}+{_firstJump}+{_secondJump}");
            }




        }
    }
   


    


}
