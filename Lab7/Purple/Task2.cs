using System.Linq;

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

            public int[] Marks
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return null;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int Result
            {
                get
                {
                    int distScore = 0;
                    if (_distance == 120)
                    {
                        distScore = 60;
                    }
                    else if (_distance > 120)
                    {
                        distScore = 60 + (_distance - 120) * 2;
                    }
                    else
                    {
                        distScore = 60 - (120 - _distance) * 2;
                        if (distScore < 0) distScore = 0;
                    }

                    return _marks.Sum() - _marks.Max() - _marks.Min() + distScore;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                _distance = distance;
                if (marks.Length == 5 || marks != null)
                {
                    _marks = marks;
                }
                else return;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].Result < array[j + 1].Result)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Participant: {_surname} {_name}");
                Console.WriteLine($"Distance: {_distance}");
                Console.WriteLine($"Result: {Result}");
            }
        }
    }
}
