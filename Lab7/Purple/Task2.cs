using System;
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
            public int[] Marks => _marks.ToArray();

            public int Result
            {
                get
                {
                    int minMark = _marks[0];
                    int maxMark = _marks[0];
                    int sumMarks = 0;

                    foreach (var m in _marks)
                    {
                        sumMarks += m;
                        if (m < minMark) minMark = m;
                        if (m > maxMark) maxMark = m;
                    }
                    int styleScore = sumMarks - minMark - maxMark;

                    int distanceScore = 60 + (_distance - 120) * 2;

                    int total = styleScore + distanceScore;
                    return total < 0 ? 0 : total;
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
                for (int i = 0; i < 5; i++)
                {
                    _marks[i] = marks[i];
                }
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    Participant key = array[i];
                    int j = i - 1;

                    while (j >= 0 && array[j].Result < key.Result)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = key;
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Surname} {Name}: {Result}");
            }
        }
    }
}
