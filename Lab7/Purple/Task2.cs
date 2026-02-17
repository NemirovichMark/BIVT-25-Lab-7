using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;

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
                    int[] copy = new int [_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int Result
            {
                get
                {
                    if (_marks == null || _marks.Length < 3) return 0;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    Array.Sort(copy);
                    
                    const int DIST = 120;
                    int sum = 60;
                    for (int i = 1; i < copy.Length - 1; i++)
                    {
                        sum += copy[i];
                    }

                    
                    if (_distance > DIST)
                    {
                        int bonus = (_distance - DIST) * 2;
                        sum += bonus;
                    }
                    else if (_distance < DIST)
                    {
                        int penalty = (DIST - _distance) * 2;
                        sum -= penalty;
                    }
                    return Math.Max(0, sum);
                }
            }
            
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = null;
            }
            public void Jump(int distance, int[] marks)
            {
                _distance = distance;
                if (marks != null && marks.Length > 0)
                {
                    _marks = new int[marks.Length];
                    Array.Copy(marks, _marks, marks.Length);
                }
            }
            
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                var sorted = array.OrderByDescending(x => x.Result).ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] =  sorted[i];
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: Distance={Distance}, Result={Result}");
            }
        }
    }
}
