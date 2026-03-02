using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;
            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks => _marks;
            public Participant(string Name, string Surname)
            {
                _name = Name;
                _surname = Surname;
                _marks = new int[5];
                _distance = 0;
                

            }
            public void Jump(int distance, int[] marks)
            {
                _distance = distance;
                _marks = marks;
            }
            public int Result
            {
                get
                {
                    int total = 0;
                    int max = int.MinValue;
                    int min = int.MaxValue;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        total+=_marks[i];
                        if (_marks[i] < min)
                        {
                            min = _marks[i];
                        }
                        if (_marks[i] > max)
                        {
                            max = _marks[i];
                        }
                    }
                    total = total - min - max;
                    if (_distance != 120)
                    {
                        int distBALLS = 60 + (_distance - 120) * 2;
                        if (distBALLS < 0)
                        {
                            distBALLS = 0;
                        }
                        total = total + distBALLS;
                    }
                    else
                    {
                    total = total + 60;
                    }
                    return total;
                }
            }
            public void Print()
            {
                Console.WriteLine($"Участник: {Name} {Surname}, Результат: {Result}");
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].Result < array[j].Result)
                        {
                            Participant temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }
    }
}
